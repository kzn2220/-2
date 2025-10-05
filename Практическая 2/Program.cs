using Практическая_2;

Console.WriteLine("море вводить с кавычками");

string input1 = Console.ReadLine();
string input2 = Console.ReadLine();
string input3 = Console.ReadLine();

Sea ConvertSea(string input)
{
    var parts = new List<string>();
    bool f = false;
    string currentPart = "";

    foreach (char c in input.Trim())
    {
        if (c == '"')
        {
            f = !f;
            continue;
        }

        if (c == ' ' && !f)
        {
            if (!string.IsNullOrEmpty(currentPart))
            {
                parts.Add(currentPart);
                currentPart = "";
            }
        }
        else
        {
            currentPart += c;
        }
    }

    if (!string.IsNullOrEmpty(currentPart))
    {
        parts.Add(currentPart);
    }

    string name = parts[0];
    double depth = double.Parse(parts[1]);
    double salinity = double.Parse(parts[2]);

    return new Sea(name, depth, salinity);
}

Sea sea1 = ConvertSea(input1);
Sea sea2 = ConvertSea(input2);
Sea sea3 = ConvertSea(input3);

OceanBasin basin = new OceanBasin(new List<Sea> { sea1, sea2, sea3 });

foreach (var sea in basin.Seas)
{
    Console.WriteLine($"{sea.Name}: глубина {sea.Depth} м, солёность {sea.Salinity} ‰");
}

Sea deepest = basin.GetDeepestSea();
Sea saltiest = basin.GetMostSaltySea();

Console.WriteLine($"\nСамое глубокое море: {deepest.Name} ({deepest.Depth} м)");
Console.WriteLine($"Самое солёное море: {saltiest.Name} ({saltiest.Salinity} ‰)");