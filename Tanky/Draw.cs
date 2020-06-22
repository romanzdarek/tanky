using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Tanky
{
    class Draw
    {
        int boomTimer = 0;
        int waterTimer = 0;

        //obrázky
        Image tankUp1 = Properties.Resources.tank_up_1;
        Image tankUp2 = Properties.Resources.tank_up_2;

        Image tankDown1 = Properties.Resources.tank_down_1;
        Image tankDown2 = Properties.Resources.tank_down_2;

        Image tankLeft1 = Properties.Resources.tank_left_1;
        Image tankLeft2 = Properties.Resources.tank_left_2;

        Image tankRight1 = Properties.Resources.tank_right_1;
        Image tankRight2 = Properties.Resources.tank_right_2;

        Image background = Properties.Resources.back;

        Image boom1 = Properties.Resources.boom1;
        Image boom2 = Properties.Resources.boom2;

        Image miniboom1 = Properties.Resources.miniboom1;
        Image miniboom2 = Properties.Resources.miniboom2;

        Image wall1 = Properties.Resources.wall1;
        Image wall2 = Properties.Resources.wall2;
        Image wall3 = Properties.Resources.wall3;

        Image panzer = Properties.Resources.panzer;
        Image center = Properties.Resources.center;
        Image forest = Properties.Resources.forest;

        Image water1 = Properties.Resources.water1;
        Image water2 = Properties.Resources.water2;

        Image create1 = Properties.Resources.create1;
        Image create2 = Properties.Resources.create2;
        Image create3 = Properties.Resources.create3;
        Image create4 = Properties.Resources.create4;
        Image create5 = Properties.Resources.create5;



        public Draw()
        {
            
        }


        //zobrazovac...
        public void View(PaintEventArgs e)
        {
            Font font;

            //hra neběží
            if (!Game.GameStart && !Game.GameOver)
            {
                

                //multiplayer?
                if (Game.Players == 0)
                {
                    font = new Font("arial", 100);
                    e.Graphics.DrawString("Tanky", font, Brushes.White, 260, 200);
                    font = new Font("arial", 20);
                    e.Graphics.DrawString("Stiskni ENTER pro hru jednoho hráče.", font, Brushes.White, 250, 400);
                    e.Graphics.DrawString("Stiskni M pro hru dvou hráčů.", font, Brushes.White, 250, 450);
                }
                //vývěr levelu
                else
                {
                    font = new Font("arial", 100);
                    e.Graphics.DrawString("Tanky", font, Brushes.White, 260, 200);
                    font = new Font("arial", 20);
                    e.Graphics.DrawString("Vyber si level stisknutím: 1, 2, 3, 4, 5.", font, Brushes.White, 250, 400);
                }
            }

            //GameOver
            if (Game.GameOver && !Game.GameWin)
            {
                font = new Font("arial", 100);
                e.Graphics.DrawString("Prohra", font, Brushes.White, 260, 200);
                font = new Font("arial", 20);
                e.Graphics.DrawString("Stiskni ENTER pro restart hry.", font, Brushes.White, 290, 400);
            }
            //GameWin
            if(Game.GameOver && Game.GameWin)
            {
                font = new Font("arial", 100);
                e.Graphics.DrawString("Výhra", font, Brushes.White, 260, 200);
                font = new Font("arial", 20);
                e.Graphics.DrawString("Stiskni ENTER pro restart hry.", font, Brushes.White, 290, 400);
            }

            //pokud hra běží
            if (Game.GameStart && !Game.GameOver)
            {
                //vykresleni tanku
                foreach (Tank tank in Game.Tanks)
                {
                    if (tank.FullyActivated)
                    {
                        //animování tanku
                        if(tank.AnimeTimer == 6)
                        {
                            tank.AnimeTimer = 0;
                        }
                        
                        Image tankUp, tankDown, tankLeft, tankRight;
                        if(tank.AnimeTimer <= 2)
                        {
                            tankUp = tankUp1;
                            tankDown = tankDown1;
                            tankLeft = tankLeft1;
                            tankRight = tankRight1;
                        }
                        else
                        {
                            tankUp = tankUp2;
                            tankDown = tankDown2;
                            tankLeft = tankLeft2;
                            tankRight = tankRight2;
                        }
                        tank.AnimeTimer++;
                        //tank stojí
                        if (!tank.Ride)
                        {
                            tankUp = tankUp1;
                            tankDown = tankDown1;
                            tankLeft = tankLeft1;
                            tankRight = tankRight1;
                        }

                        //barva tanku
                        
                        if(tank is EnemyTank)
                        {
                            e.Graphics.FillRectangle(Brushes.DarkSlateGray, tank.X + 4, tank.Y + 4, tank.Size - 8, tank.Size - 8);
                        }
                        else
                        {
                            e.Graphics.FillRectangle(Brushes.SaddleBrown, tank.X + 4, tank.Y + 4, tank.Size - 8, tank.Size - 8);
                        }

                        double healt;
                        int live;

                        switch (tank.Direction)
                        {
                            case "up":
                                e.Graphics.DrawImage(tankUp, tank.X, tank.Y);
                                //ukazatel zivotu
                                healt = 20 * ((double)tank.Healt / tank.MaxHealt);
                                live = (int)healt;
                                e.Graphics.FillRectangle(Brushes.Red, tank.X + 12, tank.Y + 35, 20, 2);
                                e.Graphics.FillRectangle(Brushes.ForestGreen, tank.X + 12, tank.Y + 35, live, 2);
                                break;
                            case "down":
                                e.Graphics.DrawImage(tankDown, tank.X, tank.Y);
                                //ukazatel zivotu
                                healt = 20 * ((double)tank.Healt / tank.MaxHealt);
                                live = (int)healt;
                                e.Graphics.FillRectangle(Brushes.Red, tank.X + 12, tank.Y + 7, 20, 2);
                                e.Graphics.FillRectangle(Brushes.ForestGreen, tank.X + 12, tank.Y + 7, live, 2);
                                break;
                            case "left":
                                e.Graphics.DrawImage(tankLeft, tank.X, tank.Y);
                                //ukazatel zivotu
                                healt = 20 * ((double)tank.Healt / tank.MaxHealt);
                                live = (int)healt;
                                e.Graphics.FillRectangle(Brushes.Red, tank.X + 35, tank.Y + 12, 2, 20);
                                e.Graphics.FillRectangle(Brushes.ForestGreen, tank.X + 35, tank.Y + 12, 2, live);
                                break;
                            case "right":
                                e.Graphics.DrawImage(tankRight, tank.X, tank.Y);
                                //ukazatel zivotu
                                healt = 20 * ((double)tank.Healt / tank.MaxHealt);
                                live = (int)healt;
                                e.Graphics.FillRectangle(Brushes.Red, tank.X + 7, tank.Y + 12, 2, 20);
                                e.Graphics.FillRectangle(Brushes.ForestGreen, tank.X + 7, tank.Y + 12, 2, live);
                                break;
                        }
                    }
                    //tank ještě není plně aktivovaný
                    else if(tank.Active && !tank.FullyActivated)
                    {
                        if(((EnemyTank)tank).ActiveTimer < 5)
                        {
                            e.Graphics.DrawImage(create1, tank.X-8, tank.Y);
                        }
                        else if (((EnemyTank)tank).ActiveTimer < 10)
                        {
                            e.Graphics.DrawImage(create2, tank.X - 8, tank.Y);
                        }
                        else if (((EnemyTank)tank).ActiveTimer < 15)
                        {
                            e.Graphics.DrawImage(create3, tank.X - 8, tank.Y);
                        }
                        else if (((EnemyTank)tank).ActiveTimer < 20)
                        {
                            e.Graphics.DrawImage(create4, tank.X - 8, tank.Y);
                        }
                        else if (((EnemyTank)tank).ActiveTimer < 25)
                        {
                            e.Graphics.DrawImage(create5, tank.X - 8, tank.Y);
                        }

                    }
                }

                //water timer
                waterTimer++;

                if (waterTimer == 14)
                {
                    waterTimer = 0;
                }



                //vykresleni bloku
                foreach (Block block in Game.BattleField.Blocks)
                {
                    switch (block.Type)
                    {
                        case "wall":
                            //e.Graphics.FillRectangle(Brushes.Coral, block.X, block.Y, Block.Size, Block.Size);
                            if (block.Healt == 3)
                            {
                                e.Graphics.DrawImage(wall1, block.X, block.Y);
                            }
                            else if (block.Healt == 2)
                            {
                                e.Graphics.DrawImage(wall2, block.X, block.Y);
                            }
                            else
                            {
                                e.Graphics.DrawImage(wall3, block.X, block.Y);
                            }

                            break;
                        case "panzer":
                            e.Graphics.DrawImage(panzer, block.X, block.Y);
                            break;
                        case "water":
                            if (waterTimer < 7)
                            {
                                e.Graphics.DrawImage(water1, block.X, block.Y);
                            }
                            else
                            {
                                e.Graphics.DrawImage(water2, block.X, block.Y);
                            }
                            
                            break;
                        case "center":
                            e.Graphics.DrawImage(center, block.X, block.Y);
                            break;
                    }

                }

                //rakety
                foreach (Rocket rocket in Game.Rockets)
                {
                    if (rocket.Tank is EnemyTank)
                    {
                        e.Graphics.FillRectangle(Brushes.Red, rocket.X, rocket.Y, rocket.Width, rocket.Height);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.Lime, rocket.X, rocket.Y, rocket.Width, rocket.Height);
                    }

                }



                //výbuch
                boomTimer++;
                if(boomTimer > 10)
                {
                    boomTimer = 0;
                }

                Image boom, miniBoom;
                if(boomTimer > 5)
                {
                    boom = boom1;
                    miniBoom = miniboom1;
                }
                else
                {
                    boom = boom2;
                    miniBoom = miniboom2;
                }

                foreach (var expolosion in Game.Explosions)
                {
                    if (expolosion.BigExplosion)
                    {
                        e.Graphics.DrawImage(boom, expolosion.X - (expolosion.Size / 2), expolosion.Y - (expolosion.Size / 2));
                    }
                    else
                    {
                        e.Graphics.DrawImage(miniBoom, expolosion.X - (expolosion.Size / 2), expolosion.Y - (expolosion.Size / 2));
                    }
                    
                }

                //les
                foreach (Block block in Game.BattleField.Blocks)
                {
                    switch (block.Type)
                    {
                        case "forest":
                            e.Graphics.DrawImage(forest, block.X, block.Y);
                            break;
                    }

                }
            }
           

        }
    }
}
