using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAdventure
{
    public class Food
    {
        public int scoreModifier = 0;
        public string name = "";
        public int Eat(int score)
        {
            return score + scoreModifier;
        }
    }

    public class Mouse : Food
    {
        public Mouse()
        {
            scoreModifier = 3;
            name = "Mus";
        }
    }

    public class Rat : Food
    {
        public Rat()
        {
            scoreModifier = 5;
            name = "Råtta";
        }
    }

    public class Bird : Food
    {
        public Bird()
        {
            scoreModifier = 4;
            name = "Fågel";
        }
    }

    public class Berry : Food
    {
        public Berry()
        {
            scoreModifier = -3;
            name = "Bär";
        }
    }

    public class Apple : Food
    {
        public Apple()
        {
            scoreModifier = -5;
            name = "Äpple";
        }
    }
}
