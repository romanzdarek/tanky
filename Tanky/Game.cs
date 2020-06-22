using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanky
{
    //původně public class
    partial class Game : Form
    {

        Draw draw;
        Tank playerOne;
        Tank playerTwo;

        int gameOverTimer = 0;

        
        public static BattleField BattleField;
        public static List<Tank> Tanks;
        public static List<Rocket> Rockets;
        public static List<Explosion> Explosions;

        public static readonly int FormWidth = 1020;
        public static readonly int FormHeight = 720;

        public static int Players = 0;
        public static int Level = 0;

        public static bool GameStart = false;
        public static bool GameOver = false;
        public static bool GameWin = false;

        public Game()
        {
            InitializeComponent();
            //rozmer formu
            ClientSize = new Size(FormWidth, FormHeight);
            draw = new Draw();
            Rockets = new List<Rocket>();
            Explosions = new List<Explosion>();
        }



        //stisk klávesy
        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    //restart
                    if (GameOver)
                    {
                        Level = 0;
                        Players = 0;
                        GameOver = false;
                        GameStart = false;
                        GameWin = false;
                        Rockets = new List<Rocket>();
                        Explosions = new List<Explosion>();
                        Invalidate();
                    }
                    else if (!GameStart && !GameOver)
                    {
                        Players = 1;
                        Invalidate();
                    }
                    break;
                case Keys.M:
                    if (!GameStart)
                    {
                        Players = 2;
                        Invalidate();
                    }
                    break;
                case Keys.D1:
                    if (!GameStart && Players !=0)
                    {
                        Level = 1;
                    }
                    break;
                case Keys.D2:
                    if (!GameStart && Players != 0)
                    {
                        Level = 2;
                    }
                    break;
                case Keys.D3:
                    if (!GameStart && Players != 0)
                    {
                        Level = 3;
                    }
                    break;
                case Keys.D4:
                    if (!GameStart && Players != 0)
                    {
                        Level = 4;
                    }
                    break;
                case Keys.D5:
                    if (!GameStart && Players != 0)
                    {
                        Level = 5;
                    }
                    break;
                case Keys.Space:
                    if (GameStart)
                    {
                        playerOne.MakeShoot(true); ;
                    }
                    break;
                case Keys.Left:
                    if (GameStart)
                    {
                        playerOne.Drive("left", true);
                    }
                    break;
                case Keys.Up:
                    if (GameStart)
                    {
                        playerOne.Drive("up", true);
                    }
                    break;
                case Keys.Right:
                    if (GameStart)
                    {
                        playerOne.Drive("right", true);
                    }
                    break;
                case Keys.Down:
                    if (GameStart)
                    {
                        playerOne.Drive("down", true);
                    }
                    break;

                //player two
                case Keys.H:
                    if (GameStart && Players == 2)
                    {
                        playerTwo.MakeShoot(true); ;
                    }
                    break;
                case Keys.A:
                    if (GameStart && Players == 2)
                    {
                        playerTwo.Drive("left", true);
                    }
                    break;
                case Keys.W:
                    if (GameStart && Players == 2)
                    {
                        playerTwo.Drive("up", true);
                    }
                    break;
                case Keys.D:
                    if (GameStart && Players == 2)
                    {
                        playerTwo.Drive("right", true);
                    }
                    break;
                case Keys.S:
                    if (GameStart && Players == 2)
                    {
                        playerTwo.Drive("down", true);
                    }
                    break;
            }
        }

        //uvolnění klávesy
        private void KeyUpEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    break;
                case Keys.Left:
                    if (GameStart)
                    {
                        playerOne.Drive("left", false);
                    }
                    break;
                case Keys.Up:
                    if (GameStart)
                    {
                        playerOne.Drive("up", false);
                    }
                    break;
                case Keys.Right:
                    if (GameStart)
                    {
                        playerOne.Drive("right", false);
                    }
                    break;
                case Keys.Down:
                    if (GameStart)
                    {
                        playerOne.Drive("down", false);
                    }
                    break;
                case Keys.Space:
                    if (GameStart)
                    {
                        playerOne.MakeShoot(false); ;
                    }
                    break;
                //player two
                case Keys.H:
                    if (GameStart && Players == 2)
                    {
                        playerTwo.MakeShoot(false);
                    }
                    break;
                case Keys.A:
                    if (GameStart && Players == 2)
                    {
                        playerTwo.Drive("left", false);
                    }
                    break;
                case Keys.W:
                    if (GameStart && Players == 2)
                    {
                        playerTwo.Drive("up", false);
                    }
                    break;
                case Keys.D:
                    if (GameStart && Players == 2)
                    {
                        playerTwo.Drive("right", false);
                    }
                    break;
                case Keys.S:
                    if (GameStart && Players == 2)
                    {
                        playerTwo.Drive("down", false);
                    }
                    break;
            }
        }

        //Vykreslování
        private void PaintEvent(object sender, PaintEventArgs e)
        {
            //pozadi
            e.Graphics.FillRectangle(Brushes.Black, 0, 0, FormWidth, FormHeight);

            //e.Graphics.DrawImage(tankUp, tank.X, tank.Y);
            draw.View(e);
        }

        //herní smyčka
        private void GameLoopEvent(object sender, EventArgs e)
        {
            //vytvoření levelu
            if (Players != 0 && Level != 0 && !GameStart)
            {
                //vytvoření levelu
                NewLevel.Create(Level, (Players == 2));

                //hráč 1
                playerOne = Tanks[0];
                //hráč 2
                if (Players == 2)
                {
                    playerTwo = Tanks[1];
                }

                GameStart = true;
            }

            

            //hra běží
            if (GameStart && !GameOver)
            {
                //vyřadíme zničené tanky
                for (int i = 0; i < Tanks.Count; i++)
                {
                    if (!Tanks[i].Live)
                    {
                        Tanks.RemoveAt(i);
                    }
                }

                



                //pohyb raket
                foreach (Rocket rocket in Rockets)
                {
                    rocket.Move();
                }
                //mazání raket
                for (int i = Rockets.Count - 1; i >= 0; i--)
                {
                    if (!Rockets[i].Live)
                    {
                        Rockets.RemoveAt(i);
                    }
                }
                //pohyb raket
                foreach (Rocket rocket in Rockets)
                {
                    rocket.Move();
                }
                //mazání raket
                for (int i = Rockets.Count - 1; i >= 0; i--)
                {
                    if (!Rockets[i].Live)
                    {
                        Rockets.RemoveAt(i);
                    }
                }


                //aktivujeme jen omezený počet tanků a další budeme postupně přidávat
                int maxCountEnemyTanks = 4;
                int countEnemyTanks = 0;

                //aktivace tanků
                //počet aktivních tanků
                foreach (Tank tank in Tanks)
                {
                    if (tank is EnemyTank && tank.Active)
                    {
                        countEnemyTanks++;
                    }
                }
                //přidání tanku do hry
                if(countEnemyTanks < maxCountEnemyTanks)
                {
                    foreach (Tank tank in Tanks)
                    {
                        if (tank is EnemyTank && !tank.Active)
                        {
                            //aktivace tanku
                            //není na naší poloze jiný již aktivovaný tank
                            bool canActivated = true;
                            foreach (Tank otherTank in Tanks)
                            {
                                if (otherTank.Active)
                                {
                                    //je jiny aktivni tank na pozici, kde chceme vytvorit novy tank?
                                    if (tank.X + tank.Size >= otherTank.X  && tank.X <= otherTank.X + otherTank.Size)
                                    {
                                        if (tank.Y <= otherTank.Y + otherTank.Size && tank.Y + tank.Size >= otherTank.Y)
                                        {
                                            canActivated = false;
                                        }
                                    }
                                }
                            }
                            if (canActivated)
                            {
                                //prvek náhody do aktivace
                                if(NewLevel.Random.Next(60) == 0)
                                {
                                    tank.Active = true;
                                    break;
                                }
                               
                            }
                        }
                    }
                }


                //pohyb tanků 
                foreach (Tank tank in Tanks)
                {
                    if (tank.Active)
                    {
                        //pocitacem rizeny tank
                        if (tank is EnemyTank)
                        {
                            ((EnemyTank)tank).UI();
                        }

                        if (tank.FullyActivated)
                        {
                            tank.Move();
                        }
                    }
                }


                //mazání exploze
                for (int i = Explosions.Count -1; i >= 0; i--)
                {
                    Explosions[i].Timer++;
                    if(Explosions[i].Timer > 10)
                    {
                        Explosions.RemoveAt(i);
                    }
                }

                //detekce GameOver
                //pokud je znicen blok ktery chranime
                //nebo pokud jsou zniceny nase tanky

                bool gameOver = true;

                foreach (Block block in BattleField.Blocks)
                {
                    if(block.Type == "center")
                    {
                        gameOver = false;
                        break;
                    }
                }

                bool myTanksDestroy = true;

                foreach (Tank tank in Tanks)
                {
                    //moje tanky
                    if (!(tank is EnemyTank))
                    {
                        myTanksDestroy = false;
                        break;
                    }
                }

                //nepřátelské tanky zničeny, výhra...

                bool gameWin = true;

                foreach (Tank tank in Tanks)
                {
                    //moje tanky
                    if (tank is EnemyTank)
                    {
                        gameWin = false;
                        break;
                    }
                }

                //ukončení hry
                if (gameOver || myTanksDestroy || gameWin)
                {
                    gameOverTimer++;
                }
                //zpožděne ukončení hry
                if (gameOverTimer == 30)
                {
                    //výhra za předpokladu zničení nepřátelských tanků a zachovaní centra
                    GameWin = (gameWin && !gameOver) ? true : false;
                    GameOver = true;
                    GameStart = false;
                    gameOverTimer = 0;
                }

                //vykreslení
                Invalidate();
            }
        }
    }
}
