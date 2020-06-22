using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanky
{
    class Tank
    {
        public int AnimeTimer { get; set; }
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public bool Live { get; protected set; }
        public bool Active { get; set; }
        public bool FullyActivated { get; protected set; }

        public int Size { get; protected set; }
        public string Direction { get; protected set; }


        public bool Ride { get; protected set; }
        protected int speed;
        public int Healt { get; protected set; }
        public int MaxHealt { get; protected set; }
        protected int shootTimer;
        protected bool canMakeShot;

        public Tank(int x, int y, int healt)
        {
            X = x;
            Y = y;
            Size = 44;
            Direction = "up";
            Ride = false;
            speed = 5;
            MaxHealt = Healt = healt;
            Live = true;
            shootTimer = 100;
            Active = true;
            FullyActivated = true;
            AnimeTimer = 0;
            canMakeShot = true;
        }

        //střela
        public void MakeShoot(bool key)
        {
            if (canMakeShot && key)
            {
                Shoot();
                canMakeShot = false;
            }
            if (!canMakeShot && !key)
            {
                canMakeShot = true;
            }
        }

        //střela
        public void Shoot()
        {
            //je nabito?
            if(shootTimer > 8)
            {
                Game.Rockets.Add(new Rocket(X, Y, Direction, this));
                shootTimer = 0;
            }
            
        }

        //zásah
        public virtual void Explosion(string direction)
        {
            Healt -= 1;
            Live = (Healt <= 0) ? false : true;
            if (!Live)
            {
                //velká exploze
                Game.Explosions.Add(new Explosion(X + (Size / 2), Y + (Size / 2), true));
            }
        }


        //řízení tanku
        public void Drive(string direction, bool Ride)
        {   
            //povel k jizde
            if (Ride)
            {
                Direction = direction;
                this.Ride = true;
            }
            else
            //uvolneni tlacitka - zastaveni...
            {
                //preruseni jizdy pokud uvolnime tlacitko ktere vyvolalo soucasny smer jizdy
                if(direction == Direction)
                {
                    this.Ride = false;
                }
            }
        }

        //posun tanku
        public void Move()
        {
            //nabíjení
            shootTimer++;
            if (Ride)
            {
                switch (Direction)
                {
                    case "up":
                        Y -= CanMove("up");
                        break;
                    case "down":
                        Y += CanMove("down");
                        break;
                    case "left":
                        X -= CanMove("left");
                        break;
                    case "right":
                        X += CanMove("right");
                        break;
                }
            }
        }
        //je mozne tank posunout?
        //vraci cislo o kolik je mozne tank posunout
        protected int CanMove(string direction)
        {
            //možný posun
            int canSpeed = 0;

            //nedovolime tanku vyjet ven z okna
            switch (direction)
            {
                case "up":
                    //posun je mozny
                    if (Y >= speed)
                    {
                        canSpeed = speed;
                    }
                    //castecny posun
                    else
                    {
                        canSpeed = Y;
                    }
                    break;
                case "down":
                    //posun je mozny
                    if (Y <= (Game.BattleField.Height - Size) - speed)
                    {
                        canSpeed = speed;
                    }
                    //castecny posun
                    else
                    {
                        canSpeed = (Game.BattleField.Height - Size) - Y;
                    }
                    break;
                case "left":
                    //posun je mozny
                    if (X >= speed)
                    {
                        canSpeed = speed;
                    }
                    //castecny posun
                    else
                    {
                        canSpeed = X;
                    }
                    break;
                case "right":
                    //posun je mozny
                    if (X <= (Game.BattleField.Width - Size) - speed)
                    {
                        canSpeed = speed;
                    }
                    //castecny posun
                    else
                    {
                        canSpeed = (Game.BattleField.Width - Size) - X;
                    }
                    break;
            }

            //možný posun dokud neprijdeme na omezení nastavíme maximální
            int canSpeed2 = speed;
           
            //nedovolime vjet do prekážek na mapě
            foreach (Block block in Game.BattleField.Blocks)
            {
                //lesem muzem projet...
                if (block.Type != "forest")
                {
                    switch (direction)
                    {
                        case "up":
                            //blok nad námi na ose X
                            if (X + Size >= block.X && X <= block.X + Block.Size)
                            {
                                //osa Y
                                //posun možný pod blokem je místo...
                                if (block.Y + Block.Size < Y - speed)
                                {

                                }
                                //částečný posun
                                else if (block.Y + Block.Size < Y)
                                {
                                    canSpeed2 = Y - (block.Y + Block.Size + 1);
                                }
                            }
                            break;
                        case "down":
                            //blok pod námi na ose X
                            if (X + Size >= block.X && X <= block.X + Block.Size)
                            {
                                //osa Y
                                //posun možný nad blokem je místo...
                                if (block.Y > Y + Size + speed)
                                {

                                }
                                //částečný posun
                                else if (block.Y > Y + Size)
                                {
                                    canSpeed2 = block.Y - (Y + Size + 1);
                                }
                            }
                            break;
                        case "left":
                            //blok před námi na ose Y
                            if (Y + Size >= block.Y && Y <= block.Y + Block.Size)
                            {
                                //osa X
                                //posun možný před blokem je místo...
                                if (block.X + Block.Size < X - speed)
                                {

                                }
                                //částečný posun
                                else if (block.X < X)
                                {
                                    canSpeed2 = X - (block.X + Block.Size + 1);
                                }
                            }
                            break;
                        case "right":
                            //blok před námi na ose Y
                            if (Y + Size >= block.Y && Y <= block.Y + Block.Size)
                            {
                                //osa X
                                //posun možný před blokem je místo...
                                if (block.X > X + Size + speed)
                                {

                                }
                                //částečný posun
                                else if (block.X > X + Size)
                                {
                                    canSpeed2 = block.X - (X + Size + 1);
                                }
                            }
                            break;
                    }
                }
            }

            
            //možný posun dokud neprijdeme na omezení nastavíme maximální
            int canSpeed3 = speed;

            //nedovolíme vjet do jiného tanku
            foreach (Tank tank in Game.Tanks)
            {
                if (tank.Active)
                {
                    switch (direction)
                    {
                        case "up":
                            //blok nad námi na ose X
                            if (X + Size >= tank.X && X <= tank.X + tank.Size)
                            {
                                //osa Y
                                //posun možný pod blokem je místo...
                                if (tank.Y + tank.Size < Y - speed)
                                {

                                }
                                //částečný posun
                                else if (tank.Y + tank.Size < Y)
                                {
                                    canSpeed2 = Y - (tank.Y + tank.Size + 1);
                                }
                            }
                            break;
                        case "down":
                            //blok pod námi na ose X
                            if (X + Size >= tank.X && X <= tank.X + tank.Size)
                            {
                                //osa Y
                                //posun možný nad blokem je místo...
                                if (tank.Y > Y + Size + speed)
                                {

                                }
                                //částečný posun
                                else if (tank.Y > Y + Size)
                                {
                                    canSpeed2 = tank.Y - (Y + Size + 1);
                                }
                            }
                            break;
                        case "left":
                            //blok před námi na ose Y
                            if (Y + Size >= tank.Y && Y <= tank.Y + tank.Size)
                            {
                                //osa X
                                //posun možný před blokem je místo...
                                if (tank.X + tank.Size < X - speed)
                                {

                                }
                                //částečný posun
                                else if (tank.X < X)
                                {
                                    canSpeed2 = X - (tank.X + tank.Size + 1);
                                }
                            }
                            break;
                        case "right":
                            //blok před námi na ose Y
                            if (Y + Size >= tank.Y && Y <= tank.Y + tank.Size)
                            {
                                //osa X
                                //posun možný před blokem je místo...
                                if (tank.X > X + Size + speed)
                                {

                                }
                                //částečný posun
                                else if (tank.X > X + Size)
                                {
                                    canSpeed2 = tank.X - (X + Size + 1);
                                }
                            }
                            break;
                    }
                }
            }

            //vratime maximalni možny posun to je ten nejmenší...

            if (canSpeed < canSpeed2) {

                if(canSpeed < canSpeed3)
                {
                    return canSpeed;
                }
                else
                {
                    return canSpeed3;
                }
            }
            else
            {
                if(canSpeed2 < canSpeed3)
                {
                    return canSpeed2;
                }
                else
                {
                    return canSpeed3;
                }
            }
        }
    }
}
