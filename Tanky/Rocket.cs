using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanky
{
     class Rocket
    {
        public bool Live { get; private set; }
        public int X {get; private set;}
        public int Y { get; private set;}
        string Direction;
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Tank Tank { get; private set; }
        int speed;

        public Rocket(int x, int y, string direction, Tank tank)
        {

            Live = true;
            Tank = tank;
            Direction = direction;
            speed = 10;

            int longSize = 15;
            int shortSize = 6;

            switch (direction)
            {
                case "up":

                    Width = shortSize;
                    Height = longSize;

                    X = x + (tank.Size / 2)  - (Width / 2);
                    Y = y - Height - 1;
                    break;
                case "down":

                    Width = shortSize;
                    Height = longSize;

                    X = x + (tank.Size / 2) - (Width / 2);
                    Y = y + tank.Size + Height + 1;
                    break;
                case "left":

                    Width = longSize;
                    Height = shortSize;

                    Y = y + (tank.Size / 2) - (Height / 2);
                    X = x - Width - 1;
                    break;
                case "right":

                    Width = longSize;
                    Height = shortSize;

                    Y = y + (tank.Size / 2) - (Height / 2);
                    X = x + tank.Size + Width + 1;
                    break;
            }
        }

        //posun rakety skaceme po 20 coz je moc muzem tak preskocit proti letici raketu skok zmensime a budeme ho volat nekolikrat za sebou...
        public void Move()
        {
            //kolize rakety
            Explosion();

            //posun rakety
            switch (Direction)
            {
                case "up":
                    Y -= speed;
                    break;
                case "down":
                    Y += speed;
                    break;
                case "left":
                    X -= speed;
                    break;
                case "right":
                    X += speed;
                    break;
            }
        }

        //kontrola kolizi rakety
        void Explosion()
        {
            //naraz do bloků...

            //indexy zničenych bloků ke smazání
            List<int> hits = new List<int>();

            //nenarazila raketa na nejaky blok na mape?
            for (int i = 0; i < Game.BattleField.Blocks.Count; i++)
            {
                //pokud se raketa překrývá s nějakým blokem
                //střet na ose X
                if (X + Width >= Game.BattleField.Blocks[i].X && X <= Game.BattleField.Blocks[i].X + Block.Size)
                {
                    //střet na ose Y
                    if (Y + Height >= Game.BattleField.Blocks[i].Y && Y <= Game.BattleField.Blocks[i].Y + Block.Size)
                    {
                        //lesem a vodou raketa proletne bez poškození
                        if(!(Game.BattleField.Blocks[i].Type == "forest" || Game.BattleField.Blocks[i].Type == "water"))
                        {
                            //trefa - zničeno?
                            if (Game.BattleField.Blocks[i].Explosion())
                            {
                                //přidaní do seznamu bloku pro smazání
                                hits.Add(i);
                                //velká exploze
                                Game.Explosions.Add(new Explosion(Game.BattleField.Blocks[i].X + (Block.Size / 2), Game.BattleField.Blocks[i].Y + (Block.Size / 2), true));
                            }
                            //tady je třeba zničit raketu...
                            Live = false;
                            //výbuch
                            Game.Explosions.Add(new Explosion(X + (Width / 2), Y + (Height / 2), false));
                        }
                    }
                }
            }

            //došlo k nějakému zničení?
            //nutné mazat bloky od zadu (posunutí indexu)
            for (int i = hits.Count - 1; i >= 0; i--)
            {
                //smazání zničeného bloku
                Game.BattleField.Blocks.RemoveAt(hits[i]);
            }



            //náraz do tanku
            foreach (Tank oneTank in Game.Tanks)
            {
                if (oneTank.FullyActivated)
                {
                    //nepřátelský tank nemůže zasáhnou jiný nepřátelský tank... střela proletí tankem a pokračuje dál...
                    //pokud nejsou oba nepřátelské trefa... nebo pokud nejdeo dva tanky hráče...
                    if (!(Tank is EnemyTank && oneTank is EnemyTank) && !(!(Tank is EnemyTank) && !(oneTank is EnemyTank)))
                    {
                        //pokud se raketa překrývá s nějakým tankem
                        //střet na ose X
                        if (X + Width >= oneTank.X && X <= oneTank.X + oneTank.Size)
                        {
                            //střet na ose Y
                            if (Y + Height >= oneTank.Y && Y <= oneTank.Y + oneTank.Size)
                            {
                                oneTank.Explosion(Direction);
                                //tady je třeba zničit raketu...
                                Live = false;
                                //výbuch
                                Game.Explosions.Add(new Explosion(X - (Width / 2), Y - (Height / 2), false));
                            }
                        }
                    }
                } 
            }

            //náraz do jiné rakety
            foreach (Rocket rocket in Game.Rockets)
            {
                //neporovnávame znovu se svoji raketou!
                if (!(rocket == this))
                {
                    //nepřetelská raketa nemuze sejmout jinou nepratelskou raketu a raketa hrace nemuze sejmout druheho hrace
                    if (!(Tank is EnemyTank && rocket.Tank is EnemyTank) && !(!(Tank is EnemyTank) && !(rocket.Tank is EnemyTank)))
                    {
                        //střet na ose X
                        if (X + Width >= rocket.X && X <= rocket.X + rocket.Width)
                        {
                            //střet na ose Y
                            if (Y + Height >= rocket.Y && Y <= rocket.Y + rocket.Height)
                            {
                                //tady je třeba zničit raketu...
                                Live = false;
                                //výbuch
                                Game.Explosions.Add(new Explosion(X - (Width / 2), Y - (Height / 2), true));
                            }
                        }
                    }
                    
                }
            }

            //raketa mimo hrací pole
            foreach (Rocket rocket in Game.Rockets)
            {
                if (rocket.X > Game.BattleField.Width || rocket.X + rocket.Width < 0)
                {
                    rocket.Live = false;
                }
                if (rocket.Y > Game.BattleField.Height || rocket.Y + rocket.Height < 0)
                {
                    rocket.Live = false;
                }
            }

        }
    }
}
