using suic_grabulab2;

    using (ApplicationContext db = new ApplicationContext())
        
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    var stocks = new List<Stock>
    {
        new() { Town = "Rome" },
        new() { Town = "Berlin" },
        new() { Town = "Milan" },
        new() { Town = "Moscow" }
    };

    var cars = Generator.GetCars(stocks);

    db.Stocks.AddRange(stocks);
    db.Cars.AddRange(cars);
    db.SaveChanges();

    Console.WriteLine("Alfa Romeo на складе.");
    var z1 = db.Cars.Where(p => p.Name == "Alfa Romeo").Where(p => p.IsStock == true).ToList();
    foreach (var z in z1)
    {
        Console.WriteLine($"{z.Name} {z.Cost}$ ");
    }

Console.WriteLine();

Console.WriteLine("Склады с BMW:");
var z2 = db.Cars.Where(p => p.Name.Contains("BMW")).Select(p => p.Stock).Distinct().ToList();
foreach (var z in z2)
{
    Console.WriteLine($"{z.Town}");
}

Console.WriteLine();

Console.WriteLine("Машины дешевле 10000$:");
var z3 = db.Cars.Where(p => p.Cost < 10000).ToList();
foreach (var z in z3)
{
    Console.WriteLine($"{z.Name} {z.Cost}$ {z.DataRelease} года.");
}

Console.WriteLine();

Console.WriteLine("Машины в наличие:");
var z4 = db.Cars.Where(p => p.Remark != "").OrderBy(p => p.Name).ToList();
foreach (var z in z4)
{
    Console.WriteLine($"{z.Name} {z.Cost}$ {z.DataRelease} года. Пометка: {z.Remark}");
}

Console.WriteLine();

Console.WriteLine("Склады с машинами 2000-2005 г:");
var z5 = db.Cars.Where(p => p.DataRelease >= 2000 && p.DataRelease <= 2005).GroupBy(c => c.Stock.Town)
    .Select(g => new { Name = g.Key, Count = g.Count() }).ToList();
foreach (var z in z5)
{
    Console.WriteLine(z.Name + " " + z.Count);
}

Console.WriteLine();

Console.WriteLine("Машины до 2000 года:");
var z6 = db.Cars.Where(p => p.DataRelease < 2000).OrderBy(p => p.DataRelease).ToList();
foreach (var z in z6)
{
    Console.WriteLine($"{z.Name} {z.Cost}$ {z.DataRelease} года");
}

Console.WriteLine();

Console.WriteLine("Вся база.TXT");
Otchet DBRep = new Otchet() { DateBase = db };
DBRep.WriteAllReport();
Console.ReadKey();
}

