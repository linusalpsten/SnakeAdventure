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
        List<Food> inventory = new List<Food>();
        static Random rng = new Random();
        static void Main(string[] args)
        {
            //bool gameover = false;
            ////Introduction
            //Console.WriteLine($"Du ska hjälpa ormen {name} att hitta mat");
            //Console.WriteLine("Du behöver 20 poäng för att gå vidare till nästa nivå");
            //while (!gameover)
            //{
            //    Console.Clear();
            //    Console.WriteLine($"Poäng: {score}");
            //    Console.WriteLine($"Du befinner dig i {location}");
            //    Console.WriteLine("1. Leta mat");
            //    Console.WriteLine("2. Ryggsäck");
            //    string input = Console.ReadLine();
            //    switch (input)
            //    {
            //        case "1":

            //            break;
            //        default:
            //            break;
            //    }
            //}
            FindFood();
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
                    break;
            }
            if (food.GetType() == typeof(Berry)||food.GetType() == typeof(Apple))
            {
                Console.WriteLine($"Du hittade ett {food.name}.");
            }
            else
            {
                Console.WriteLine($"Du hittade en {food.name}");
            }
            char input;
            do
            {
                Console.WriteLine("Vill du spara det du hittade?");
                Console.WriteLine("1. Ja");
                Console.WriteLine("2. Nej");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine(input);

            } while (input != '1' && input != '2');
        }
    }
}
