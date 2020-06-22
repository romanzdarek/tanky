using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanky
{
    class Explosion
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Size { get; private set; }
        public int Timer { get; set; }
        public bool BigExplosion { get; private set; }

        public Explosion(int x, int y, bool bigExplosion)
        {
            if (bigExplosion)
            {
                Size = 72;
            }
            else
            {
                Size = 36;
            }
            BigExplosion = bigExplosion;
            Timer = 0;
            X = x;
            Y = y;
            
        }

    }
}
