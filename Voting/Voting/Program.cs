using System;
using System.Collections.Generic;
using System.Linq;

namespace VotingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            VotingSystem votingSystem = new VotingSystem();
            votingSystem.StartVoting();
        }
    }

    class VotingSystem
    {
        private List<Category> categories;
        private List<User> users;

        public VotingSystem()
        {
            // Pre-defined kategoriler
            categories = new List<Category>
            {
                new Category("Aksiyon Filmleri"),
                new Category("Komedi Filmleri"),
                new Category("Dram Filmleri"),
                new Category("Bilim Kurgu Filmleri")
            };

            users = new List<User>();
        }

        public void StartVoting()
        {
            Console.WriteLine("=== VOTING UYGULAMASI ===\n");

            while (true)
            {
                Console.Write("Kullanıcı adınızı giriniz: ");
                string username = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(username))
                {
                    Console.WriteLine("Geçerli bir kullanıcı adı giriniz!\n");
                    continue;
                }

                User currentUser = users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

                if (currentUser == null)
                {
                    Console.Write("Kullanıcı bulunamadı. Kayıt olmak ister misiniz? (E/H): ");
                    string cevap = Console.ReadLine()?.ToUpper();

                    if (cevap == "E")
                    {
                        currentUser = new User(username);
                        users.Add(currentUser);
                        Console.WriteLine($"{username} sisteme kayıt edildi.\n");
                    }
                    else
                    {
                        Console.WriteLine("Oylama iptal edildi.\n");
                        continue;
                    }
                }

                Console.WriteLine("\nOylamaya sunulan kategoriler:");
                for (int i = 0; i < categories.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {categories[i].Name}");
                }

                Console.Write("\nOy vermek istediğiniz kategori numarasını giriniz: ");
                if (int.TryParse(Console.ReadLine(), out int secim) && secim > 0 && secim <= categories.Count)
                {
                    Category selectedCategory = categories[secim - 1];
                    selectedCategory.AddVote(currentUser);
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim!\n");
                    continue;
                }

                Console.Write("\nYeni bir kullanıcı oy verecek mi? (E/H): ");
                string devam = Console.ReadLine()?.ToUpper();
                if (devam == "H")
                {
                    ShowResults();
                    break;
                }

                Console.Clear();
            }
        }

        private void ShowResults()
        {
            Console.WriteLine("\n=== OYLAMA SONUÇLARI ===\n");
            int toplamOy = categories.Sum(c => c.VoteCount);

            foreach (var category in categories)
            {
                double yuzde = toplamOy == 0 ? 0 : (category.VoteCount * 100.0 / toplamOy);
                Console.WriteLine($"{category.Name} → Oy: {category.VoteCount} | %{yuzde:F2}");
            }

            Console.WriteLine($"\nToplam Oy: {toplamOy}");
            Console.WriteLine("\nProgram sonlandı. Teşekkürler!");
        }
    }

    class Category
    {
        public string Name { get; }
        private HashSet<string> Voters { get; }

        public int VoteCount => Voters.Count;

        public Category(string name)
        {
            Name = name;
            Voters = new HashSet<string>();
        }

        public void AddVote(User user)
        {
            if (Voters.Contains(user.Username))
            {
                Console.WriteLine($"{user.Username}, bu kategoriye zaten oy vermiş!");
            }
            else
            {
                Voters.Add(user.Username);
                Console.WriteLine($"{user.Username}, {Name} kategorisine oy verdi.\n");
            }
        }
    }

    class User
    {
        public string Username { get; }

        public User(string username)
        {
            Username = username;
        }
    }
}
