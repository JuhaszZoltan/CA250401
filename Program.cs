using CA250401;

const string HOZAM = "C:\\Users\\juhas\\source\\repos\\CA250401\\src\\hozam.txt";
const string JOLTEJELOK = "C:\\Users\\juhas\\source\\repos\\CA250401\\src\\joltejelok.txt";
List<Tehen> happyCows = [];

using StreamReader sr = new(HOZAM);
while (!sr.EndOfStream)
{
    var tmp = sr.ReadLine().Split(';');
    string tehenId = tmp[0];
    int napSorszam = int.Parse(tmp[1]);
    int tejMennyiseg = int.Parse(tmp[2]);
    Tehen tehen = new(tehenId);

    if (!happyCows.Contains(tehen)) happyCows.Add(tehen);
    happyCows[happyCows.IndexOf(tehen)].TejMennyisegRogzit(napSorszam, tejMennyiseg);
}

Console.WriteLine($"tehenek száma: {happyCows.Count}");

var joltejelok = happyCows.Where(t => t.AtlagosFejesiMennyiseg != -1);

using StreamWriter sw = new(JOLTEJELOK);
foreach (var tehen in joltejelok)
{
    sw.WriteLine($"{tehen.ID} {tehen.AtlagosFejesiMennyiseg}");
}
Console.WriteLine($"{joltejelok.Count()} sor került az állományba");


Console.Write("írd be egy tehén azonosítóját: ");
string keresettID = Console.ReadLine();

if (!happyCows.Any(t => t.ID == keresettID))
    Console.WriteLine("\tnincs ilyen azonosítójú tehén!");
else
{
    int leszarmazottak = happyCows.Count(t => t.ID.StartsWith(keresettID) && t.ID != keresettID);
    Console.WriteLine($"\t{keresettID} leszármazottjainak száma: {leszarmazottak}");
}

//Ember e1 = new() { Name = "Laci", Age = 12 };
//Ember e2 = new() { Name = "Laci", Age = 12 };

//Tehen t1 = new("33");
//Tehen t2 = new("33");

//Console.WriteLine(t1 == t2);