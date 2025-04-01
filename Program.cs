const string PATH = "..\\..\\..\\src\\valami.txt";

Console.WriteLine("hello world!");

Console.WriteLine("Wanna' read valami.txt? y/n");

if (Console.ReadKey(true).KeyChar == 'y')
{
    StreamReader sr = new("valami.txt");
    Console.WriteLine(sr.ReadLine());
}

Console.WriteLine("press ESC to exit");

while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;


