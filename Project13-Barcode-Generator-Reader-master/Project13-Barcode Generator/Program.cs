// See https://aka.ms/new-console-template for more information

using BarcodeLib;
using Project13_Barcode_Generator;

Barcode barcode =Process.CreateAndSaveBarcode("777");
Console.WriteLine(Process.ReadBarcode(barcode));

barcode = Process.CreateAndSaveBarcode("11");
Console.WriteLine(Process.ReadBarcode(barcode));

barcode = Process.CreateAndSaveBarcode("111");
Console.WriteLine(Process.ReadBarcode(barcode));

barcode = Process.CreateAndSaveBarcode("1111");
Console.WriteLine(Process.ReadBarcode(barcode));