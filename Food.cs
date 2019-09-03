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
        public string singleName = "";
        public string multipleName = "";
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
            singleName = "Mus";
            multipleName = "Möss";
        }
    }

    public class Rat : Food
    {
        public Rat()
        {
            scoreModifier = 5;
            singleName = "Råtta";
            multipleName = "Råttor";
        }
    }

    public class Bird : Food
    {
        public Bird()
        {
            scoreModifier = 4;
            singleName = "Fågel";
            multipleName = "Fåglar";
        }
    }

    public class Berry : Food
    {
        public Berry()
        {
            scoreModifier = -3;
            singleName = "Bär";
            multipleName = "Bär";
        }
    }

    public class Apple : Food
    {
        public Apple()
        {
            scoreModifier = -5;
            singleName = "Äpple";
            multipleName = "Äpplen";
        }
    }
}
