using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanky
{
    static class NewLevel
    {
        public static Random Random = new Random();

        public static void Create(int level, bool twoPlayers)
        {

            Game.BattleField = new BattleField(Game.FormWidth, Game.FormHeight, level);


            Game.Tanks = new List<Tank>();

            //pozice nepřátelských tanků
            int x1 = 7;
            int x2 = 487;
            int x3 = 969;

            int y = 0;

            switch (level)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    
                    if (twoPlayers)
                    {
                        //první hráč
                        Game.Tanks.Add(new Tank(548, 608, 2));
                        //druhý hráč 
                        Game.Tanks.Add(new Tank(428, 608, 2));
                    }
                    else
                    {
                        //první hráč
                        Game.Tanks.Add(new Tank(548, 608, 4));
                    }
                    //nepřátelské tanky
                    Game.Tanks.Add(new EnemyTank(x1, y, Random));
                    Game.Tanks.Add(new EnemyTank(x2, y, Random));
                    Game.Tanks.Add(new EnemyTank(x3, y, Random));

                    Game.Tanks.Add(new EnemyTank(x1, y, Random));
                    Game.Tanks.Add(new EnemyTank(x2, y, Random));
                    Game.Tanks.Add(new EnemyTank(x3, y, Random));

                    Game.Tanks.Add(new EnemyTank(x1, y, Random));
                    Game.Tanks.Add(new EnemyTank(x2, y, Random));
                    Game.Tanks.Add(new EnemyTank(x3, y, Random));

                    Game.Tanks.Add(new EnemyTank(x1, y, Random));
                    Game.Tanks.Add(new EnemyTank(x2, y, Random));
                    Game.Tanks.Add(new EnemyTank(x3, y, Random));

                    Game.Tanks.Add(new EnemyTank(x1, y, Random));
                    Game.Tanks.Add(new EnemyTank(x2, y, Random));
                    Game.Tanks.Add(new EnemyTank(x3, y, Random));



                    break;
            }
        }
    }
}
