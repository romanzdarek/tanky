using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanky
{
    class EnemyTank : Tank
    {
        Random random;
        public int ActiveTimer { get; private set; }

        public EnemyTank(int x, int y, Random random) : base(x, y, 2)
        {
            Ride = true;
            this.random = random;
            //každý začne střílet jindy...
            shootTimer = random.Next(25);
            Direction = "down";
            Active = false;
            FullyActivated = false;
            ActiveTimer = 0;
        }

        //UI nepřátelského tanku
        public void UI()
        {
            //aktivace tanku
            if (Active && !FullyActivated)
            {
                if(ActiveTimer > 25)
                {
                    FullyActivated = true;
                }
                ActiveTimer++;
            }
            //plně aktivovaný tank
            if (FullyActivated)
            {
                shootTimer++;
                //kontrola zda můžeme jet dopředu, pokud ne změníme směr
                if (CanMove(Direction) == 0)
                {
                    bool changeDirection = true;
                    //pokud nemůžu jet stejným směrem protože mi přkaží tank hráče tak se neotočím v případě, že je do něj možné střílet
                    //zjištění zda se jedná právě o tento stav
                    foreach (Tank tank in Game.Tanks)
                    {
                        //pokud se nejedná o nepřátelský tank, tedy o tank hráče jedna nebo dva
                        if(!(tank is EnemyTank))
                        {
                            //porovnání pozic tanků
                            if (tank.Active)
                            {
                                //aby se tan neotacel kdyz je moznost trefit tank hrace
                                //hrany dela tanku (rakety)
                                int overlapTank1 = 19;
                                int overlapTank2 = 25;
                                switch (Direction)
                                {
                                    case "up":
                                        //blok nad námi na ose X
                                        if (X + overlapTank1 <= tank.X + tank.Size && X + overlapTank2 >= tank.X)
                                        {
                                            //osa Y
                                            //pokud bude možný posun nulový
                                            if (tank.Y + tank.Size + 1 == Y)
                                            {
                                                changeDirection = false;
                                            }
                                        }
                                        break;
                                    case "down":
                                        //blok pod námi na ose X
                                        if (X + overlapTank1 <= tank.X + tank.Size && X + overlapTank2 >= tank.X)
                                        {
                                            //osa Y
                                            //pokud bude možný posun nulový
                                            if (tank.Y == Y + Size + 1)
                                            {
                                                changeDirection = false;
                                            }
                                        }
                                        break;
                                    case "left":
                                        //blok před námi na ose Y
                                        if (Y + overlapTank1 <= tank.Y + tank.Size && Y + overlapTank2 >= tank.Y)
                                        {
                                            //pokud bude možný posun nulový
                                            if (tank.X + tank.Size + 1 == X)
                                            {
                                                changeDirection = false;
                                            }
                                        }
                                        break;
                                    case "right":
                                        //blok před námi na ose Y
                                        if (Y + overlapTank1 <= tank.Y + tank.Size && Y + overlapTank2 >= tank.Y)
                                        {
                                            //pokud bude možný posun nulový
                                            if (tank.X  == X + Size + 1)
                                            {
                                                changeDirection = false;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    }

                    //pokud bude změna směru kvuli kolizi s tankem hráče tak jen snížíme pravděpodobnost změny směru, jinak okamžitá změna změru...
                    int changeNow = (changeDirection) ? 4 : 128;

                    //změna směru
                    switch (random.Next(changeNow))
                    {
                        case 0:
                            Direction = "up";
                            break;
                        case 1:
                            Direction = "down";
                            break;
                        case 2:
                            Direction = "left";
                            break;
                        case 3:
                            Direction = "right";
                            break;
                    }
                   
                }
                
                //úplně náhodná změna směru
                switch (random.Next(1000))
                {
                    case 0:
                        Direction = "up";
                        break;
                    case 1:
                        Direction = "down";
                        break;
                    case 2:
                        Direction = "left";
                        break;
                    case 3:
                        Direction = "right";
                        break;
                }
                
                //střela po x opakováních...
                if (shootTimer > 25)
                {
                    //75% šance na výstřel
                    if (random.Next(4) != 0)
                    {
                        Shoot();
                    }
                    shootTimer = 0;
                }
            }

        }
        public override void Explosion(string direction)
        {
            //pravděpodobnost otočení tanku
            if(random.Next(4) < 3)
            {
                //otoceni tanku smerem odkud priletla raketa
                switch (direction)
                {
                    case "up":
                        Direction = "down";
                        break;
                    case "down":
                        Direction = "up";
                        break;
                    case "left":
                        Direction = "right";
                        break;
                    case "right":
                        Direction = "left";
                        break;
                }
            }

            Healt -= 1;
            Live = (Healt <= 0) ? false : true;

            if (!Live)
            {
                //velká exploze
                Game.Explosions.Add(new Explosion(X + (Size / 2), Y + (Size / 2), true));
            }
        }

    }
}
