﻿using NLog;
using System.Reflection;
using System.Text.Json;
string path = Directory.GetCurrentDirectory() + "//nlog.config";

// create instance of Logger
var logger = LogManager.Setup().LoadConfigurationFromFile(path).GetCurrentClassLogger();

logger.Info("Program started");

// deserialize mario json from file into List<Mario>
string marioFileName = "mario.json";
List<Mario> marios = [];
// check if file exists
if (File.Exists(marioFileName))
{
  marios = JsonSerializer.Deserialize<List<Mario>>(File.ReadAllText(marioFileName))!;
  logger.Info($"File deserialized {marioFileName}");
}

// deserialize donkey kong json from file into List<DonkeyKong>
string dkFileName = "dk.json";
List<DonkeyKong> donkeyKongs = [];
// check if file exists
if (File.Exists(dkFileName))
{
  donkeyKongs = JsonSerializer.Deserialize<List<DonkeyKong>>(File.ReadAllText(dkFileName))!;
  logger.Info($"File deserialized {dkFileName}");
}

// deserialize street fighter json from file into List<StreetFighter>
string sf2FileName = "sf2.json";
List<StreetFighter> streetFighters = [];
// check if file exists
if (File.Exists(sf2FileName))
{
  streetFighters = JsonSerializer.Deserialize<List<StreetFighter>>(File.ReadAllText(sf2FileName))!;
  logger.Info($"File deserialized {sf2FileName}");
}

do
{
  // display choices to user
  Console.WriteLine("1) Display Mario Characters");
  Console.WriteLine("2) Add Mario Character");
  Console.WriteLine("3) Remove Mario Character");
  Console.WriteLine("4) Edit Mario Character");
  Console.WriteLine("5) Display Donkey Kong Characters");
  Console.WriteLine("6) Add Donkey Kong Character");
  Console.WriteLine("7) Remove Donkey Kong Character");
  Console.WriteLine("8) Edit Donkey Kong Character");
  Console.WriteLine("9) Display Street Fighter Characters");
  Console.WriteLine("10) Add Street Fighter Character");
  Console.WriteLine("11) Remove Street Fighter Character");
  Console.WriteLine("12) Edit Street Fighter Character");
  Console.WriteLine("Enter to quit");

  // input selection
  string? choice = Console.ReadLine();
  logger.Info("User choice: {Choice}", choice);

    if (choice == "1")
    {
        // Display Mario Characters
        foreach (var c in marios)
        {
            Console.WriteLine(c.Display());
        }
    }
    else if (choice == "2")
    {
        // Add Mario Character
        // Generate unique Id
        Mario mario = new()
        {
            Id = marios.Count == 0 ? 1 : marios.Max(c => c.Id) + 1
        };
        InputCharacter(mario);
        // Add Character
        marios.Add(mario);
        File.WriteAllText(marioFileName, JsonSerializer.Serialize(marios));
        logger.Info($"Character added: {mario.Name}");
    }
    else if (choice == "3")
    {
        // Remove Mario Character
        Console.WriteLine("Enter the Id of the character to remove:");
        if (UInt32.TryParse(Console.ReadLine(), out UInt32 Id))
        {
            Mario? character = marios.FirstOrDefault(c => c.Id == Id);
            if (character == null)
            {
                logger.Error($"Character Id {Id} not found");
            }
            else
            {
                marios.Remove(character);
                // serialize list<marioCharacter> into json file
                File.WriteAllText(marioFileName, JsonSerializer.Serialize(marios));
                logger.Info($"Character Id {Id} removed");
            }
        }
        else
        {
            logger.Error("Invalid Id");
        }
    }
    else if (choice == "4")
    {
        // Edit Mario Character
        Console.WriteLine("Enter the Id of the character to edit:");
        if (UInt32.TryParse(Console.ReadLine(), out UInt32 Id))
        {
            int idx = marios.FindIndex(c => c.Id == Id);
            if (idx == -1)
            {
                logger.Error($"Character Id {Id} not found");
            }
            else
            {
                InputCharacter(marios[idx]);
                File.WriteAllText(marioFileName, JsonSerializer.Serialize(marios));
                logger.Info($"Character Id {Id} edited");
            }
        }
        else
        {
            logger.Error("Invalid Id");
        }
    }
    else if (choice == "5")
    {
        // Display Donkey Kong Characters
        foreach (var c in donkeyKongs)
        {
            Console.WriteLine(c.Display());
        }
    }
    else if (choice == "6")
    {
        // Add Donkey Kong Character
        // Generate unique Id
        DonkeyKong donkeyKong = new()
        {
            Id = donkeyKongs.Count == 0 ? 1 : donkeyKongs.Max(c => c.Id) + 1
        };
        InputCharacter(donkeyKong);
        // Add Character
        donkeyKongs.Add(donkeyKong);
        File.WriteAllText(dkFileName, JsonSerializer.Serialize(donkeyKongs));
        logger.Info($"Character added: {donkeyKong.Name}");
    }
    else if (choice == "7")
    {
        // Remove Donkey Kong Character
        Console.WriteLine("Enter the Id of the character to remove:");
        if (UInt32.TryParse(Console.ReadLine(), out UInt32 Id))
        {
            DonkeyKong? character = donkeyKongs.FirstOrDefault(c => c.Id == Id);
            if (character == null)
            {
                logger.Error($"Character Id {Id} not found");
            }
            else
            {
                donkeyKongs.Remove(character);
                // serialize list<donkeyKong> into json file
                File.WriteAllText(dkFileName, JsonSerializer.Serialize(donkeyKongs));
                logger.Info($"Character Id {Id} removed");
            }
        }
        else
        {
            logger.Error("Invalid Id");
        }
    }
    else if (choice == "8")
    {
        // Edit Donkey Kong Character
        Console.WriteLine("Enter the Id of the character to edit:");
        if (UInt32.TryParse(Console.ReadLine(), out UInt32 Id))
        {
            int idx = donkeyKongs.FindIndex(c => c.Id == Id);
            if (idx == -1)
            {
                logger.Error($"Character Id {Id} not found");
            }
            else
            {
                InputCharacter(donkeyKongs[idx]);
                File.WriteAllText(dkFileName, JsonSerializer.Serialize(donkeyKongs));
                logger.Info($"Character Id {Id} edited");
            }
        }
        else
        {
            logger.Error("Invalid Id");
        }
    }
    else if (choice == "9")
    {
        // Display Street Fighter Characters
        foreach (var c in streetFighters)
        {
            Console.WriteLine(c.Display());
        }
    }
    else if (choice == "10")
    {
        // Add Street Fighter Character
        // Generate unique Id
        StreetFighter streetFighter = new()
        {
            Id = streetFighters.Count == 0 ? 1 : streetFighters.Max(c => c.Id) + 1
        };
        InputCharacter(streetFighter);
        // Add Character
        streetFighters.Add(streetFighter);
        File.WriteAllText(sf2FileName, JsonSerializer.Serialize(streetFighters));
        logger.Info($"Character added: {streetFighter.Name}");
    }
    else if (choice == "11")
    {
        // Remove Street Fighter Character
        Console.WriteLine("Enter the Id of the character to remove:");
        if (UInt32.TryParse(Console.ReadLine(), out UInt32 Id))
        {
            StreetFighter? character = streetFighters.FirstOrDefault(c => c.Id == Id);
            if (character == null)
            {
                logger.Error($"Character Id {Id} not found");
            }
            else
            {
                streetFighters.Remove(character);
                // serialize list<streetFighter> into json file
                File.WriteAllText(sf2FileName, JsonSerializer.Serialize(streetFighters));
                logger.Info($"Character Id {Id} removed");
            }
        }
        else
        {
            logger.Error("Invalid Id");
        }
    }
    else if (choice == "12")
    {
        // Edit Street Fighter Character
        Console.WriteLine("Enter the Id of the character to edit:");
        if (UInt32.TryParse(Console.ReadLine(), out UInt32 Id))
        {
            int idx = streetFighters.FindIndex(c => c.Id == Id);
            if (idx == -1)
            {
                logger.Error($"Character Id {Id} not found");
            }
            else
            {
                InputCharacter(streetFighters[idx]);
                File.WriteAllText(sf2FileName, JsonSerializer.Serialize(streetFighters));
                logger.Info($"Character Id {Id} edited");
            }
        }
        else
        {
            logger.Error("Invalid Id");
        }
    }
    else if (string.IsNullOrEmpty(choice))
    {
        break;
    }
    else
    {
        logger.Info("Invalid choice");
    }
} while (true);

logger.Info("Program ended");

static void InputCharacter(Character character)
{
  Type type = character.GetType();
  PropertyInfo[] properties = type.GetProperties();
  var props = properties.Where(p => p.Name != "Id");
  foreach (PropertyInfo prop in props)
  {
    if (prop.PropertyType == typeof(string))
    {
      Console.WriteLine($"Enter {prop.Name}:");
      prop.SetValue(character, Console.ReadLine());
    } else if (prop.PropertyType == typeof(List<string>)) {
      List<string> list = [];
      do {
        Console.WriteLine($"Enter {prop.Name} or (enter) to quit:");
        string response = Console.ReadLine()!;
        if (string.IsNullOrEmpty(response)){
          break;
        }
        list.Add(response);
      } while (true);
      prop.SetValue(character, list);
    }
  }
}