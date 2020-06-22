using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanky
{
    class Block
    {
        public static int Size = 60;
        public int X { get; private set; }
        public int Y { get; private set; }
        public string Type { get; private set; }
        public bool Live { get; private set; }
        public int Healt { get; private set; }

        public Block(int x, int y, string type)
        {
            switch (type)
            {
                case "wall":
                    Healt = 3;
                    break;
                case "center":
                    Healt = 1;
                    break;
                case "panzer":
                    Healt = 100000;
                    break;
                default:
                    Healt = 1;
                    break;
            }

            X = x;
            Y = y;
            Type = type;
            Live = true;
            
        }

        public bool Explosion()
        {
            Healt--;
            //true zniceno...
            return (Healt <= 0) ? true : false;
        }


    }
}
