using SzenzorApp;

List<Szenzor> szenzors = new List<Szenzor>();
int hibasSorokSzama = 0;

foreach (string sor in File.ReadAllLines("szenzorok.txt").Skip(1))
{
    if (string.IsNullOrWhiteSpace(sor))
    {
        hibasSorokSzama++;
        continue;
    }
    string[] sorok = sor.Split("|");
    if (sorok.Length != 4)
    {
        hibasSorokSzama++;
        continue;
    }
    if (sorok[0] != "S" && sorok[0] != "K") {
        hibasSorokSzama++;
        continue;
    }
    if (!int.TryParse(sorok[2], out int fogyasztomW) || !int.TryParse(sorok[2], out int felbontasMP))
    {
        hibasSorokSzama++;
        continue;
    }
    if (sorok[0] == "S")
    {
        Szenzor szenzor = new Szenzor(sorok[0], fogyasztomW);
        szenzors.Add(szenzor);
    }
    else
    {
        Szenzor kameraSzenzor = new Szenzor(sorok[0], fogyasztomW, felbontasMP);
        szenzors.Add(kameraSzenzor);
    }
}


Console.WriteLine($"Sikeresen beolvasott szenzorok: {szenzors.Count} db");
Console.WriteLine($"Kiszűrt hibás sorok száma: {hibasSorokSzama} db");
Console.WriteLine();

Console.WriteLine("Beolvasott szenzorok listája:");
foreach (var termek in szenzors)
{
    Console.WriteLine(termek);
}

Console.WriteLine("Kameraszenzorok külön elemzése:");
foreach (var termek in szenzors.kameraSzenzor)
{
    Console.WriteLine(termek);
}

Console.WriteLine();
Console.WriteLine($"Összesített napi energiaigény (24 óra): {} mWh");
Console.WriteLine($"Szenzor példányok száma (static): {Szenzor.OsszesSzenzorSzama} db");
