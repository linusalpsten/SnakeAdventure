using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAdventure
{
    class Program
    {
        const string name = "Oscar";
        static Locations location = Locations.Skogen;
        static int score = 0;
        static List<Food> stomach = new List<Food>();
        static Random rng = new Random();
        static bool gameover = false;

        static void Main(string[] args)
        {
            StartGame();
        }

        public static void StartGame()
        {
            //Introduction
            Console.WriteLine($"Du ska hjälpa ormen {name} att hitta mat");
            Console.WriteLine("Du behöver 20 poäng för att gå vidare till nästa nivå");
            while (!gameover)
            {
                Console.Clear();
                Console.WriteLine($"Poäng: {score}");
                Console.WriteLine($"Du befinner dig i {location}");
                Console.WriteLine("Vill du...");
                string input;
                do
                {
                    Console.WriteLine("1. Leta mat?");
                    Console.WriteLine("2. Se vad du har ätit?");
                    input = Console.ReadLine();
                } while (input != "1" && input != "2");
                switch (input)
                {
                    case "1":
                        FindFood();
                        break;
                    case "2":
                        ViewStomach();
                        break;
                    default:
                        break;
                }
                if (score >= 20)
                {
                    score = 0;
                    NextLocation();
                }
            }
        }

        public static void ViewStomach()
        {
            Console.WriteLine("Du har ätit:");
            int mouseCount = 0;
            int ratCount = 0;
            int birdCount = 0;
            int berryCount = 0;
            int appleCount = 0;
            foreach (var item in stomach)
            {
                if (item.GetType() == typeof(Mouse))
                {
                    mouseCount++;
                }
                if (item.GetType() == typeof(Rat))
                {
                    ratCount++;
                }
                if (item.GetType() == typeof(Bird))
                {
                    birdCount++;
                }
                if (item.GetType() == typeof(Berry))
                {
                    berryCount++;
                }
                if (item.GetType() == typeof(Apple))
                {
                    appleCount++;
                }
            }
            if (stomach.Count == 0)
            {
                Console.WriteLine($"{name} har inte ätit något.");
            }
            else
            {
                TellFoodCount(mouseCount, new Mouse());
                TellFoodCount(ratCount, new Rat());
                TellFoodCount(birdCount, new Bird());
                TellFoodCount(berryCount, new Berry());
                TellFoodCount(appleCount, new Apple());
            }
            Console.WriteLine("Tryck på en valfri tangent för att gå tillbaka.");
            Console.ReadKey();
        }

        public static void TellFoodCount(int count, Food food)
        {
            if (count == 1)
            {
                Console.WriteLine($"{name} har ätit 1 {food.singleName}");
            }
            else if (count != 0)
            {
                Console.WriteLine($"{name} har ätit {count} {food.multipleName}");
            }
        }

        public static void NextLocation()
        {
            switch (location)
            {
                case Locations.Skogen:
                    location = Locations.Träsket;
                    break;
                case Locations.Träsket:
                    location = Locations.Kloaken;
                    break;
                case Locations.Kloaken:
                    location = Locations.Storstaden;
                    break;
                case Locations.Storstaden:
                    gameover = true;
                    Console.WriteLine("Grattis, du har vunnit.");
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        }

        public static void FindFood()
        {
            Food food;
            switch (rng.Next(5))
            {
                case 0:
                    food = new Mouse();
                    break;
                case 1:
                    food = new Rat();
                    break;
                case 2:
                    food = new Bird();
                    break;
                case 3:
                    food = new Berry();
                    break;
                case 4:
                    food = new Apple();
                    break;
                default:
                    throw new Exception("Could not generate food");
            }
            if (food.GetType() == typeof(Berry) || food.GetType() == typeof(Apple))
            {
                Console.WriteLine($"Du hittade ett {food.singleName}.");
            }
            else
            {
                Console.WriteLine($"Du hittade en {food.singleName}");
            }
            string input;
            do
            {
                Console.WriteLine("Vill du äta det du hittade?");
                Console.WriteLine("Ja/Nej");
                input = Console.ReadLine().ToLower();
            } while (input != "ja" && input != "nej");
            switch (input)
            {
                case "ja":
                    score = food.Eat(score);
                    stomach.Add(food);
                    break;
                default:
                    break;
            }
        }
    }
}
