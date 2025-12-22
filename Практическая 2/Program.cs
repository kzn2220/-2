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

    var manager = new OceanManager();

    Console.WriteLine("\n--- Ввод данных о морях ---");
    Console.WriteLine("Введите 3 моря в формате: \"название\" глубина солёность \"описание\"");
    for (int i = 0; i < 3; i++)
    {
        Console.Write($"Море {i + 1}: ");
        string input = Console.ReadLine();
        Sea sea = ConvertSea(input);
        manager.AddEntity(sea);
    }

    Console.WriteLine("\n--- Ввод данных о животных ---");
    Console.WriteLine("Введите 2 животных в формате: \"название\" \"море\" \"тип\" популяция \"описание\"");
    for (int i = 0; i < 2; i++)
    {
        Console.Write($"Животное {i + 1}: ");
        string input = Console.ReadLine();
        SeaAnimal animal = ConvertAnimal(input);
        manager.AddEntity(animal);
    }

    Console.WriteLine("\n--- Ввод данных об островах ---");
    Console.WriteLine("Введите 2 острова в формате: \"название\" \"море\" площадь население \"описание\"");
    for (int i = 0; i < 2; i++)
    {
        Console.Write($"Остров {i + 1}: ");
        string input = Console.ReadLine();
        Island island = ConvertIsland(input);
        manager.AddEntity(island);
    }

    Console.WriteLine("\n--- Ввод данных о кораблях ---");
    Console.WriteLine("Введите 3 корабля в формате: \"название\" \"море\" \"тип\" год_постройки");
    for (int i = 0; i < 3; i++)
    {
        Console.Write($"Корабль {i + 1}: ");
        string input = Console.ReadLine();
        Ship ship = ConvertShip(input);
        manager.AddEntity(ship);
    }

    return manager;
}

static Sea ConvertSea(string input)
{
    try
    {
        return InputProcessor.ConvertSea(input);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
        throw;
    }
}

static SeaAnimal ConvertAnimal(string input)
{
    try
    {
        return InputProcessor.ConvertAnimal(input);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
        throw;
    }
}

static Island ConvertIsland(string input)
{
    try
    {
        return InputProcessor.ConvertIsland(input);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
        throw;
    }
}

static Ship ConvertShip(string input)
{
    try
    {
        return InputProcessor.ConvertShip(input);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
        throw;
    }
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
