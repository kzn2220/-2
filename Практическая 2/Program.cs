using Практическая_2;

RunProgram();

static void RunProgram()
{
    OceanManager manager = InitializeData();
    DisplayAllData(manager);
    DisplayStatistics(manager);
}

static OceanManager InitializeData()
{
    Console.WriteLine("Выберите способ ввода данных:");
    Console.WriteLine("1. Загрузить из файлов");
    Console.WriteLine("2. Ввести вручную");
    Console.Write("Ваш выбор: ");

    string choice = Console.ReadLine();

    if (choice == "1")
    {
        return LoadDataFromFile();
    }
    else if (choice == "2")
    {
        return InputDataManually();
    }
    else
    {
        Console.WriteLine("Неверный выбор, будет использоваться ручной ввод");
        return InputDataManually();
    }
}

static OceanManager LoadDataFromFile()
{
    try
    {
        OceanManager manager = FileHelper.LoadFromFile();
        Console.WriteLine("\nДанные из файлов успешно загружены");
        return manager;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка загрузки из файлов: {ex.Message}");
        Console.WriteLine("Переход к ручному вводу");
        return InputDataManually();
    }
}

static OceanManager InputDataManually()
{
    Console.WriteLine("\n==== РУЧНОЙ ВВОД ====");

    List<Sea> seas = InputSeas();
    List<SeaAnimal> animals = InputAnimals();
    List<Island> islands = InputIslands();
    List<Ship> ships = InputShips();

    return new OceanManager(seas, animals, islands, ships);
}

static List<Sea> InputSeas()
{
    Console.WriteLine("\n--- Ввод данных о морях ---");
    Console.WriteLine("Введите 3 моря в формате: \"название\" глубина солёность");

    var seas = new List<Sea>();
    for (int i = 0; i < 3; i++)
    {
        Console.Write($"Море {i + 1}: ");
        string input = Console.ReadLine();
        Sea sea = ConvertSea(input);
        seas.Add(sea);
    }
    return seas;
}

static List<SeaAnimal> InputAnimals()
{
    Console.WriteLine("\n--- Ввод данных о животных ---");
    Console.WriteLine("Введите 2 животных в формате: \"название\" \"море\" \"тип\" популяция");

    var animals = new List<SeaAnimal>();
    for (int i = 0; i < 2; i++)
    {
        Console.Write($"Животное {i + 1}: ");
        string input = Console.ReadLine();
        SeaAnimal animal = ConvertAnimal(input);
        animals.Add(animal);
    }
    return animals;
}

static List<Island> InputIslands()
{
    Console.WriteLine("\n--- Ввод данных об островах ---");
    Console.WriteLine("Введите 2 острова в формате: \"название\" \"море\" площадь население");

    var islands = new List<Island>();
    for (int i = 0; i < 2; i++)
    {
        Console.Write($"Остров {i + 1}: ");
        string input = Console.ReadLine();
        Island island = ConvertIsland(input);
        islands.Add(island);
    }
    return islands;
}

static List<Ship> InputShips()
{
    Console.WriteLine("\n--- Ввод данных о кораблях ---");
    Console.WriteLine("Введите 3 корабля");

    var ships = new List<Ship>();
    for (int i = 0; i < 3; i++)
    {
        Console.Write($"Корабль: {i + 1}: ");
        string input = Console.ReadLine();
        Ship ship = ConvertShip(input);
        ships.Add(ship);
    }
    return ships;
}

static Sea ConvertSea(string input)
{
    var parts = ParseInputWithQuotes(input);
    string name = parts[0];
    double depth = double.Parse(parts[1]);
    double salinity = double.Parse(parts[2]);
    string description = parts[3];
    return new Sea(name, depth, salinity, description);
}

static SeaAnimal ConvertAnimal(string input)
{
    var parts = ParseInputWithQuotes(input);
    string name = parts[0];
    string seaName = parts[1];
    string type = parts[2];
    int population = int.Parse(parts[3]);
    string description = parts[4];
    return new SeaAnimal(name, seaName, type, population, description);
}

static Island ConvertIsland(string input)
{
    var parts = ParseInputWithQuotes(input);
    string name = parts[0];
    string seaName = parts[1];
    double area = double.Parse(parts[2]);
    int population = int.Parse(parts[3]);
    string description = parts[4];
    return new Island(name, seaName, area, population, description);
}

static Ship ConvertShip(string input)
{
    var parts = ParseInputWithQuotes(input);
    string name = parts[0];
    string seaName = parts[1];
    string type = parts[2];
    int yearBuilt = int.Parse(parts[3]);
    return new Ship(name, seaName, type, yearBuilt);
}

static List<string> ParseInputWithQuotes(string input)
{
    var parts = new List<string>();
    bool inQuotes = false;
    string currentPart = "";

    foreach (char c in input.Trim())
    {
        if (c == '"')
        {
            inQuotes = !inQuotes;
            continue;
        }

        if (c == ' ' && !inQuotes)
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

    return parts;
}

static void DisplayAllData(OceanManager manager)
{
    Console.WriteLine("\n==== ЗАГРУЖЕННЫЕ ДАННЫЕ ====");

    Console.WriteLine("\n--- Моря ---");
    foreach (var sea in manager.Seas)
    {
        Console.WriteLine(sea.GetInfo());
    }

    Console.WriteLine("\n--- Животные ---");
    foreach (var animal in manager.Animals)
    {
        Console.WriteLine(animal.GetInfo());
    }

    Console.WriteLine("\n--- Острова ---");
    foreach (var island in manager.Islands)
    {
        Console.WriteLine(island.GetInfo());
    }

    Console.WriteLine("\n--- Корабли ---");
    foreach (var ship in manager.Ships)
    {
        Console.WriteLine(ship.GetInfo());
    }
}

static void DisplayStatistics(OceanManager manager)
{
    Console.WriteLine("\n==== СТАТИСТИКА ====");

    Sea deepestSea = manager.FindDeepestSea();
    Sea saltiestSea = manager.FindSaltiestSea();
    SeaAnimal populousAnimal = manager.FindMostPopulousAnimal();
    Island largestIsland = manager.FindLargestIsland();
    Ship oldestShip = manager.FindOldestShip();

    if (deepestSea != null)
        Console.WriteLine($"Самое глубокое море: {deepestSea.Name} ({deepestSea.Depth} м)");

    if (saltiestSea != null)
        Console.WriteLine($"Самое солёное море: {saltiestSea.Name} ({saltiestSea.Salinity} ‰)");

    if (populousAnimal != null)
        Console.WriteLine($"Самое многочисленное животное: {populousAnimal.Name} ({populousAnimal.Population} особей)");

    if (largestIsland != null)
        Console.WriteLine($"Самый большой остров: {largestIsland.Name} ({largestIsland.Square} кв. км)");
    if (oldestShip != null)
        Console.WriteLine($"Самый старый корабль: {oldestShip.Name} ({oldestShip.YearBuilt} год)");
}