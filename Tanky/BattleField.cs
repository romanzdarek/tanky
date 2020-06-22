using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanky
{
    class BattleField
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public List<Block> Blocks { get; private set; }
        int level;

        public BattleField(int width, int height, int level)
        {
            Width = width;
            Height = height;
            Blocks = new List<Block>();
            this.level = level;
            CreateBattleField();
            
        }
        //vytvoření hrací plochy z bloků
        void CreateBattleField()
        {
            int size = Block.Size;
            //rozměr hracího pole
            //x 0 - 16
            //y 0 - 11

            switch (level)
            {
                //++++++++++++++++++++  1  +++++++++++++++++++++++++
                case 1:

                    Blocks.Add(new Block(4 * size, 0 * size, "panzer"));
                    Blocks.Add(new Block(12 * size, 0 * size, "panzer"));
                    //les

                    Blocks.Add(new Block(0 * size, 1 * size, "forest"));
                    Blocks.Add(new Block(1 * size, 1 * size, "forest"));
                    Blocks.Add(new Block(2 * size, 1 * size, "forest"));
                    Blocks.Add(new Block(3 * size, 1 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 1 * size, "wall"));
                    Blocks.Add(new Block(5 * size, 1 * size, "forest"));
                    Blocks.Add(new Block(6 * size, 1 * size, "forest"));
                    Blocks.Add(new Block(7 * size, 1 * size, "wall"));
                    Blocks.Add(new Block(8 * size, 1 * size, "wall"));
                    Blocks.Add(new Block(9 * size, 1 * size, "wall"));
                    Blocks.Add(new Block(10 * size, 1 * size, "forest"));
                    Blocks.Add(new Block(11 * size, 1 * size, "forest"));
                    Blocks.Add(new Block(12 * size, 1 * size, "wall"));
                    Blocks.Add(new Block(13 * size, 1 * size, "wall"));
                    Blocks.Add(new Block(14 * size, 1 * size, "forest"));
                    Blocks.Add(new Block(15 * size, 1 * size, "forest"));
                    Blocks.Add(new Block(16 * size, 1 * size, "forest"));

                    Blocks.Add(new Block(0 * size, 2 * size, "forest"));
                    Blocks.Add(new Block(1 * size, 2 * size, "forest"));
                    Blocks.Add(new Block(2 * size, 2 * size, "wall"));
                    Blocks.Add(new Block(3 * size, 2 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 2 * size, "forest"));
                    Blocks.Add(new Block(5 * size, 2 * size, "forest"));
                    Blocks.Add(new Block(6 * size, 2 * size, "forest"));
                    Blocks.Add(new Block(7 * size, 2 * size, "forest"));
                    Blocks.Add(new Block(8 * size, 2 * size, "wall"));
                    Blocks.Add(new Block(9 * size, 2 * size, "forest"));
                    Blocks.Add(new Block(10 * size, 2 * size, "forest"));
                    Blocks.Add(new Block(11 * size, 2 * size, "forest"));
                    Blocks.Add(new Block(12 * size, 2 * size, "forest"));
                    Blocks.Add(new Block(13 * size, 2 * size, "wall"));
                    Blocks.Add(new Block(14 * size, 2 * size, "wall"));
                    Blocks.Add(new Block(15 * size, 2 * size, "forest"));
                    Blocks.Add(new Block(16 * size, 2 * size, "forest"));

                    Blocks.Add(new Block(0 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(1 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(2 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(3 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(5 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(6 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(7 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(8 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(9 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(10 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(11 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(12 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(13 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(14 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(15 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(16 * size, 3 * size, "forest"));

                    Blocks.Add(new Block(8 * size, 4 * size, "water"));


                    Blocks.Add(new Block(1 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(2 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(3 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 5 * size, "wall"));

                    Blocks.Add(new Block(6 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(7 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(8 * size, 5 * size, "panzer"));
                    Blocks.Add(new Block(9 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(10 * size, 5 * size, "wall"));

                    Blocks.Add(new Block(12 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(13 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(14 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(15 * size, 5 * size, "wall"));

                    Blocks.Add(new Block(0 * size, 7 * size, "panzer"));
                    Blocks.Add(new Block(1 * size, 7 * size, "panzer"));
                    Blocks.Add(new Block(15 * size, 7 * size, "panzer"));
                    Blocks.Add(new Block(16 * size, 7 * size, "panzer"));

                    Blocks.Add(new Block(3 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(3 * size, 7 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 7 * size, "wall"));
                    Blocks.Add(new Block(5 * size, 6 * size, "wall"));

                    Blocks.Add(new Block(6 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(6 * size, 7 * size, "wall"));
                    Blocks.Add(new Block(7 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(7 * size, 7 * size, "wall"));
                    Blocks.Add(new Block(8 * size, 6 * size, "panzer"));
                    Blocks.Add(new Block(8 * size, 7 * size, "panzer"));
                    Blocks.Add(new Block(9 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(9 * size, 7 * size, "wall"));
                    Blocks.Add(new Block(10 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(10 * size, 7 * size, "wall"));
                    Blocks.Add(new Block(11 * size, 6 * size, "wall"));


                    Blocks.Add(new Block(12 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(12 * size, 7 * size, "wall"));

                    Blocks.Add(new Block(13 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(13 * size, 7 * size, "wall"));






                    Blocks.Add(new Block(2 * size, 9 * size, "wall"));
                    Blocks.Add(new Block(2 * size, 10 * size, "wall"));
                    Blocks.Add(new Block(2 * size, 11 * size, "wall"));

                    Blocks.Add(new Block(4 * size, 8 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 9 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 10 * size, "wall"));


                    Blocks.Add(new Block(14 * size, 9 * size, "wall"));
                    Blocks.Add(new Block(14 * size, 10 * size, "wall"));
                    Blocks.Add(new Block(14 * size, 11 * size, "wall"));

                    Blocks.Add(new Block(12 * size, 8 * size, "wall"));
                    Blocks.Add(new Block(12 * size, 9 * size, "wall"));
                    Blocks.Add(new Block(12 * size, 10 * size, "wall"));




                    //centrum
                    Blocks.Add(new Block(8 * size, 10 * size, "wall"));
                    Blocks.Add(new Block(7 * size, 11 * size, "wall"));
                    Blocks.Add(new Block(8 * size, 11 * size, "center"));
                    Blocks.Add(new Block(9 * size, 11 * size, "wall"));
                    break;

                //++++++++++++++++++++  2  +++++++++++++++++++++++++
                case 2:

                    // horní řada

                    Blocks.Add(new Block(2 * size, 1 * size, "water"));
                    Blocks.Add(new Block(3 * size, 1 * size, "water"));
                    Blocks.Add(new Block(4 * size, 1 * size, "water"));
                    Blocks.Add(new Block(5 * size, 1 * size, "water"));
                    Blocks.Add(new Block(6 * size, 1 * size, "water"));
                    Blocks.Add(new Block(7 * size, 1 * size, "water"));

                    Blocks.Add(new Block(9 * size, 1 * size, "water"));
                    Blocks.Add(new Block(10 * size, 1 * size, "water"));
                    Blocks.Add(new Block(11 * size, 1 * size, "water"));
                    Blocks.Add(new Block(12 * size, 1 * size, "water"));
                    Blocks.Add(new Block(13 * size, 1 * size, "water"));
                    Blocks.Add(new Block(14 * size, 1 * size, "water"));



                    Blocks.Add(new Block(5 * size, 3 * size, "panzer"));
                    Blocks.Add(new Block(5 * size, 4 * size, "panzer"));
                    Blocks.Add(new Block(5 * size, 5 * size, "panzer"));
                    Blocks.Add(new Block(5 * size, 6 * size, "panzer"));

                    Blocks.Add(new Block(11 * size, 3 * size, "panzer"));
                    Blocks.Add(new Block(11 * size, 4 * size, "panzer"));
                    Blocks.Add(new Block(11 * size, 5 * size, "panzer"));
                    Blocks.Add(new Block(11 * size, 6 * size, "panzer"));



                    Blocks.Add(new Block(10 * size, 8 * size, "wall"));
                    Blocks.Add(new Block(11 * size, 8 * size, "wall"));
                    Blocks.Add(new Block(12 * size, 8 * size, "wall"));

                    Blocks.Add(new Block(4 * size, 8 * size, "wall"));
                    Blocks.Add(new Block(5 * size, 8 * size, "wall"));
                    Blocks.Add(new Block(6 * size, 8 * size, "wall"));

                    Blocks.Add(new Block(7 * size, 7 * size, "panzer"));
                    Blocks.Add(new Block(8 * size, 7 * size, "panzer"));
                    Blocks.Add(new Block(9 * size, 7 * size, "panzer"));




                    Blocks.Add(new Block(2 * size, 10 * size, "wall"));
                    Blocks.Add(new Block(2 * size, 11 * size, "wall"));

                    Blocks.Add(new Block(4 * size, 10 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 11 * size, "wall"));

                    Blocks.Add(new Block(14 * size, 10 * size, "wall"));
                    Blocks.Add(new Block(14 * size, 11 * size, "wall"));

                    Blocks.Add(new Block(12 * size, 10 * size, "wall"));
                    Blocks.Add(new Block(12 * size, 11 * size, "wall"));


                    //centrum
                    Blocks.Add(new Block(8 * size, 10 * size, "wall"));
                    Blocks.Add(new Block(7 * size, 11 * size, "wall"));
                    Blocks.Add(new Block(8 * size, 11 * size, "center"));
                    Blocks.Add(new Block(9 * size, 11 * size, "wall"));

                    //les
                    Blocks.Add(new Block(6 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(7 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(8 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(9 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(10 * size, 3 * size, "forest"));

                    Blocks.Add(new Block(6 * size, 4 * size, "forest"));
                    Blocks.Add(new Block(7 * size, 4 * size, "forest"));
                    Blocks.Add(new Block(8 * size, 4 * size, "forest"));
                    Blocks.Add(new Block(9 * size, 4 * size, "forest"));
                    Blocks.Add(new Block(10 * size, 4 * size, "forest"));

                    Blocks.Add(new Block(6 * size, 5 * size, "forest"));
                    Blocks.Add(new Block(7 * size, 5 * size, "forest"));
                    Blocks.Add(new Block(8 * size, 5 * size, "forest"));
                    Blocks.Add(new Block(9 * size, 5 * size, "forest"));
                    Blocks.Add(new Block(10 * size, 5 * size, "forest"));

                    Blocks.Add(new Block(6 * size, 6 * size, "forest"));
                    Blocks.Add(new Block(7 * size, 6 * size, "forest"));
                    Blocks.Add(new Block(8 * size, 6 * size, "forest"));
                    Blocks.Add(new Block(9 * size, 6 * size, "forest"));
                    Blocks.Add(new Block(10 * size, 6 * size, "forest"));


                    Blocks.Add(new Block(16 * size, 3 * size, "wall"));

                    Blocks.Add(new Block(16 * size, 4 * size, "wall"));
                    Blocks.Add(new Block(15 * size, 4 * size, "wall"));

                    Blocks.Add(new Block(16 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(15 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(14 * size, 5 * size, "wall"));

                    Blocks.Add(new Block(16 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(15 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(14 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(13 * size, 6 * size, "wall"));

                    Blocks.Add(new Block(16 * size, 7 * size, "wall"));
                    Blocks.Add(new Block(15 * size, 7 * size, "wall"));
                    Blocks.Add(new Block(14 * size, 7 * size, "wall"));

                    Blocks.Add(new Block(16 * size, 8 * size, "wall"));
                    Blocks.Add(new Block(15 * size, 8 * size, "wall"));

                    Blocks.Add(new Block(16 * size, 9 * size, "wall"));



                    Blocks.Add(new Block(0 * size, 3 * size, "wall"));

                    Blocks.Add(new Block(0 * size, 4 * size, "wall"));
                    Blocks.Add(new Block(1 * size, 4 * size, "wall"));

                    Blocks.Add(new Block(0 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(1 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(2 * size, 5 * size, "wall"));

                    Blocks.Add(new Block(0 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(1 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(2 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(3 * size, 6 * size, "wall"));

                    Blocks.Add(new Block(0 * size, 7 * size, "wall"));
                    Blocks.Add(new Block(1 * size, 7 * size, "wall"));
                    Blocks.Add(new Block(2 * size, 7 * size, "wall"));

                    Blocks.Add(new Block(0 * size, 8 * size, "wall"));
                    Blocks.Add(new Block(1 * size, 8 * size, "wall"));

                    Blocks.Add(new Block(0 * size, 9 * size, "wall"));


                    break;

                //++++++++++++++++++++  3  +++++++++++++++++++++++++
                case 3:



                    //les
                    for (int i = 0; i <= 2; i++)
                    {
                        for (int j = 0; j <= 16; j++)
                        {
                            Blocks.Add(new Block(j * size, i * size, "forest"));
                        }
                    }

                    Blocks.Add(new Block(0 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(1 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(2 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(3 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(5 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(6 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(7 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(8 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(9 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(10 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(11 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(12 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(13 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(14 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(15 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(16 * size, 3 * size, "wall"));

                    Blocks.Add(new Block(0 * size, 4 * size, "wall"));
                    Blocks.Add(new Block(1 * size, 4 * size, "wall"));
                    Blocks.Add(new Block(2 * size, 4 * size, "wall"));
                    Blocks.Add(new Block(3 * size, 4 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 4 * size, "wall"));
                    Blocks.Add(new Block(5 * size, 4 * size, "wall"));
                    Blocks.Add(new Block(6 * size, 4 * size, "forest"));
                    Blocks.Add(new Block(7 * size, 4 * size, "forest"));
                    Blocks.Add(new Block(8 * size, 4 * size, "forest"));
                    Blocks.Add(new Block(9 * size, 4 * size, "forest"));
                    Blocks.Add(new Block(10 * size, 4 * size, "forest"));
                    Blocks.Add(new Block(11 * size, 4 * size, "wall"));
                    Blocks.Add(new Block(12 * size, 4 * size, "wall"));
                    Blocks.Add(new Block(13 * size, 4 * size, "wall"));
                    Blocks.Add(new Block(14 * size, 4 * size, "wall"));
                    Blocks.Add(new Block(15 * size, 4 * size, "wall"));
                    Blocks.Add(new Block(16 * size, 4 * size, "wall"));


                    //bloky
                    for (int i = 5; i <= 8; i++)
                    {
                        for (int j = 0; j <= 16; j++)
                        {

                            if (i == 8 && j == 8)
                            {
                                Blocks.Add(new Block(j * size, i * size, "panzer"));
                            }
                            else
                            {
                                Blocks.Add(new Block(j * size, i * size, "wall"));
                            }

                        }
                    }


                    Blocks.Add(new Block(4 * size, 10 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 11 * size, "wall"));

                    Blocks.Add(new Block(12 * size, 10 * size, "wall"));
                    Blocks.Add(new Block(12 * size, 11 * size, "wall"));


                    //centrum
                    Blocks.Add(new Block(8 * size, 10 * size, "wall"));
                    Blocks.Add(new Block(7 * size, 11 * size, "wall"));
                    Blocks.Add(new Block(8 * size, 11 * size, "center"));
                    Blocks.Add(new Block(9 * size, 11 * size, "wall"));

                    break;

                //++++++++++++++++++++  4  +++++++++++++++++++++++++

                case 4:


                    Blocks.Add(new Block(1 * size, 0 * size, "panzer"));
                    Blocks.Add(new Block(15 * size, 0 * size, "panzer"));

                    Blocks.Add(new Block(0 * size, 3 * size, "panzer"));

                    Blocks.Add(new Block(2 * size, 2 * size, "panzer"));
                    Blocks.Add(new Block(3 * size, 2 * size, "panzer"));
                    Blocks.Add(new Block(4 * size, 2 * size, "panzer"));
                    Blocks.Add(new Block(5 * size, 2 * size, "panzer"));
                    Blocks.Add(new Block(6 * size, 2 * size, "panzer"));
                    Blocks.Add(new Block(7 * size, 2 * size, "panzer"));

                    Blocks.Add(new Block(9 * size, 2 * size, "panzer"));
                    Blocks.Add(new Block(10 * size, 2 * size, "panzer"));
                    Blocks.Add(new Block(11 * size, 2 * size, "panzer"));
                    Blocks.Add(new Block(12 * size, 2 * size, "panzer"));
                    Blocks.Add(new Block(13 * size, 2 * size, "panzer"));
                    Blocks.Add(new Block(14 * size, 2 * size, "panzer"));

                    Blocks.Add(new Block(16 * size, 3 * size, "panzer"));

                    Blocks.Add(new Block(5 * size, 3 * size, "panzer"));
                    Blocks.Add(new Block(11 * size, 3 * size, "panzer"));

                    Blocks.Add(new Block(7 * size, 4 * size, "panzer"));
                    Blocks.Add(new Block(8 * size, 4 * size, "panzer"));
                    Blocks.Add(new Block(9 * size, 4 * size, "panzer"));

                    //lesik
                    Blocks.Add(new Block(6 * size, 1 * size, "forest"));
                    Blocks.Add(new Block(7 * size, 1 * size, "forest"));
                    Blocks.Add(new Block(8 * size, 1 * size, "forest"));
                    Blocks.Add(new Block(9 * size, 1 * size, "forest"));
                    Blocks.Add(new Block(10 * size, 1 * size, "forest"));

                    Blocks.Add(new Block(8 * size, 2 * size, "forest"));

                    Blocks.Add(new Block(6 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(7 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(8 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(9 * size, 3 * size, "forest"));
                    Blocks.Add(new Block(10 * size, 3 * size, "forest"));

                    Blocks.Add(new Block(6 * size, 4 * size, "forest"));
                    Blocks.Add(new Block(10 * size, 4 * size, "forest"));

                    Blocks.Add(new Block(6 * size, 5 * size, "forest"));
                    Blocks.Add(new Block(7 * size, 5 * size, "forest"));
                    Blocks.Add(new Block(8 * size, 5 * size, "forest"));
                    Blocks.Add(new Block(9 * size, 5 * size, "forest"));
                    Blocks.Add(new Block(10 * size, 5 * size, "forest"));

                    //wall
                    Blocks.Add(new Block(1 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(1 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(1 * size, 7 * size, "wall"));
                    Blocks.Add(new Block(1 * size, 8 * size, "wall"));
                    Blocks.Add(new Block(1 * size, 9 * size, "wall"));
                    Blocks.Add(new Block(1 * size, 10 * size, "wall"));
                    Blocks.Add(new Block(1 * size, 11 * size, "wall"));

                    Blocks.Add(new Block(15 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(15 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(15 * size, 7 * size, "wall"));
                    Blocks.Add(new Block(15 * size, 8 * size, "wall"));
                    Blocks.Add(new Block(15 * size, 9 * size, "wall"));
                    Blocks.Add(new Block(15 * size, 10 * size, "wall"));
                    Blocks.Add(new Block(15 * size, 11 * size, "wall"));

                    Blocks.Add(new Block(2 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(3 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(5 * size, 5 * size, "wall"));

                    Blocks.Add(new Block(11 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(12 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(13 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(14 * size, 5 * size, "wall"));




                    //voda
                    Blocks.Add(new Block(4 * size, 7 * size, "water"));
                    Blocks.Add(new Block(5 * size, 7 * size, "water"));
                    Blocks.Add(new Block(6 * size, 7 * size, "water"));
                    Blocks.Add(new Block(7 * size, 7 * size, "water"));
                    Blocks.Add(new Block(8 * size, 7 * size, "water"));
                    Blocks.Add(new Block(9 * size, 7 * size, "water"));
                    Blocks.Add(new Block(10 * size, 7 * size, "water"));
                    Blocks.Add(new Block(11 * size, 7 * size, "water"));
                    Blocks.Add(new Block(12 * size, 7 * size, "water"));

                    Blocks.Add(new Block(4 * size, 8 * size, "water"));
                    Blocks.Add(new Block(4 * size, 9 * size, "water"));
                    Blocks.Add(new Block(4 * size, 10 * size, "water"));
                    Blocks.Add(new Block(4 * size, 11 * size, "water"));

                    Blocks.Add(new Block(12 * size, 8 * size, "water"));
                    Blocks.Add(new Block(12 * size, 9 * size, "water"));
                    Blocks.Add(new Block(12 * size, 10 * size, "water"));
                    Blocks.Add(new Block(12 * size, 11 * size, "water"));


                    //centrum
                    Blocks.Add(new Block(8 * size, 10 * size, "wall"));
                    Blocks.Add(new Block(7 * size, 11 * size, "wall"));
                    Blocks.Add(new Block(8 * size, 11 * size, "center"));
                    Blocks.Add(new Block(9 * size, 11 * size, "wall"));

                    break;

                //++++++++++++++++++++  5  +++++++++++++++++++++++++
                case 5:

                    //centrum
                    Blocks.Add(new Block(8 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(8 * size, 6 * size, "center"));
                    Blocks.Add(new Block(8 * size, 7 * size, "wall"));
                    Blocks.Add(new Block(7 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(9 * size, 6 * size, "wall"));

                    //hradby

                    Blocks.Add(new Block(3 * size, 2 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 2 * size, "wall"));
                    Blocks.Add(new Block(5 * size, 2 * size, "wall"));
                    Blocks.Add(new Block(6 * size, 2 * size, "wall"));
                    Blocks.Add(new Block(7 * size, 2 * size, "wall"));
                    Blocks.Add(new Block(8 * size, 2 * size, "wall"));
                    Blocks.Add(new Block(9 * size, 2 * size, "wall"));
                    Blocks.Add(new Block(10 * size, 2 * size, "wall"));
                    Blocks.Add(new Block(11 * size, 2 * size, "wall"));
                    Blocks.Add(new Block(12 * size, 2 * size, "wall"));
                    Blocks.Add(new Block(13 * size, 2 * size, "wall"));


                    Blocks.Add(new Block(3 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(5 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(6 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(7 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(8 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(9 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(10 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(11 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(12 * size, 3 * size, "wall"));
                    Blocks.Add(new Block(13 * size, 3 * size, "wall"));

                    Blocks.Add(new Block(3 * size, 4 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 4 * size, "wall"));
                    Blocks.Add(new Block(5 * size, 4 * size, "wall"));

                    Blocks.Add(new Block(3 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(5 * size, 5 * size, "wall"));

                    Blocks.Add(new Block(3 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(5 * size, 6 * size, "wall"));

                    Blocks.Add(new Block(3 * size, 7 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 7 * size, "wall"));
                    Blocks.Add(new Block(5 * size, 7 * size, "wall"));

                    Blocks.Add(new Block(3 * size, 8 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 8 * size, "wall"));
                    Blocks.Add(new Block(5 * size, 8 * size, "wall"));

                    Blocks.Add(new Block(3 * size, 9 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 9 * size, "wall"));
                    Blocks.Add(new Block(5 * size, 9 * size, "wall"));

                    Blocks.Add(new Block(3 * size, 10 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 10 * size, "wall"));
                    Blocks.Add(new Block(5 * size, 10 * size, "wall"));

                    Blocks.Add(new Block(3 * size, 11 * size, "wall"));
                    Blocks.Add(new Block(4 * size, 11 * size, "wall"));
                    Blocks.Add(new Block(5 * size, 11 * size, "wall"));




                    Blocks.Add(new Block(13 * size, 4 * size, "wall"));
                    Blocks.Add(new Block(12 * size, 4 * size, "wall"));
                    Blocks.Add(new Block(11 * size, 4 * size, "wall"));

                    Blocks.Add(new Block(13 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(12 * size, 5 * size, "wall"));
                    Blocks.Add(new Block(11 * size, 5 * size, "wall"));

                    Blocks.Add(new Block(13 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(12 * size, 6 * size, "wall"));
                    Blocks.Add(new Block(11 * size, 6 * size, "wall"));

                    Blocks.Add(new Block(13 * size, 7 * size, "wall"));
                    Blocks.Add(new Block(12 * size, 7 * size, "wall"));
                    Blocks.Add(new Block(11 * size, 7 * size, "wall"));

                    Blocks.Add(new Block(13 * size, 8 * size, "wall"));
                    Blocks.Add(new Block(12 * size, 8 * size, "wall"));
                    Blocks.Add(new Block(11 * size, 8 * size, "wall"));

                    Blocks.Add(new Block(13 * size, 9 * size, "wall"));
                    Blocks.Add(new Block(12 * size, 9 * size, "wall"));
                    Blocks.Add(new Block(11 * size, 9 * size, "wall"));

                    Blocks.Add(new Block(13 * size, 10 * size, "wall"));
                    Blocks.Add(new Block(12 * size, 10 * size, "wall"));
                    Blocks.Add(new Block(11 * size, 10 * size, "wall"));

                    Blocks.Add(new Block(13 * size, 11 * size, "wall"));
                    Blocks.Add(new Block(12 * size, 11 * size, "wall"));
                    Blocks.Add(new Block(11 * size, 11 * size, "wall"));


                    Blocks.Add(new Block(0 * size, 5 * size, "panzer"));
                    Blocks.Add(new Block(9 * size, 0 * size, "panzer"));
                    Blocks.Add(new Block(16 * size, 7 * size, "panzer"));
                    break;
            }

            
        }
    }
}
