// See https://aka.ms/new-console-template for more information

using ToWinFromFromAPI;

HalperAPI halper = new HalperAPI("https://localhost:7296/api/Country");
Console.WriteLine("id:"); int id = int.Parse(Console.ReadLine());
var res = await halper.Get(id);
Console.WriteLine(res.Name+"    "+ res.Description);
Console.WriteLine("Hello, World!");
