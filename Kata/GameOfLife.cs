using System;

namespace Kata
{
    public class GameOfLife
    {

        enum cell { dead, alive, tempD, tempA, dead1, alive1, tempD1, tempA1, };
        public static void Main()
        {
            //input
            int[,] gridCell = {{0,0,0,0,0,0,0,0},
                           {0,0,0,0,1,0,0,0},
                           {0,0,0,1,1,0,0,0},
                           {0,0,0,0,0,0,0,0},
                          };
            int y = 1;
            Console.WriteLine("Generation 1:\n{0}x{1}\n", gridCell.GetLength(0), gridCell.GetLength(1), (int)cell.dead, (int)cell.alive, (int)cell.tempD, (int)cell.tempA, (int)cell.dead1, (int)cell.alive1, (int)cell.tempD1, (int)cell.tempA1);
            foreach (int x in gridCell)
            {
                Console.Write(x + " ");
                if (y++ % gridCell.GetLength(1) == 0)
                    Console.WriteLine("");
            }
            Console.WriteLine("--------------------------------------------");

            for (int i = 1; i < gridCell.GetLength(0) - 1; i++)
            {
                for (int a = 1; a < gridCell.GetLength(1) - 1; a++)
                {
                    int count = -1;
                    for (int w = -1; w <= 1; w++)
                    {
                        for (int z = -1; z <= 1; z++)
                        {
                            if (gridCell[(i + w), (a + z)] == (int)cell.alive || gridCell[(i + w), (a + z)] == (int)cell.tempD)
                                ++count;
                        }
                    }
                    if ((count < 2) || (count > 3))
                    {
                        if (gridCell[i, a] != (int)cell.dead)
                            gridCell[i, a] = (int)cell.tempD;
                    }
                    else if (count == 2)
                    {
                        if (gridCell[i, a] != (int)cell.alive)
                            gridCell[i, a] = (int)cell.tempA;
                    }
                    else if (count == 3)
                    {
                        if (gridCell[i, a] != (int)cell.alive)
                            gridCell[i, a] = (int)cell.dead;
                    }
                }
            }
            foreach (int x in gridCell)
            {
                Console.Write(x + " ");
                if (y++ % gridCell.GetLength(1) == 0)
                    Console.WriteLine("");
            }

            for (int i = 0; i < gridCell.GetLength(0) - 1; i++)
            {
                for (int a = 0; a < gridCell.GetLength(1) - 1; a++)
                {
                    int x = gridCell[i, a];
                    if (x == (int)cell.tempD)
                        x = (int)cell.dead;
                    if (x == (int)cell.tempA)
                        x = (int)cell.alive;
                    gridCell[i, a] = x;
                }
            }
            Console.WriteLine("--------------------------------------------\nGeneration 2:\n{0}x{1}\n", gridCell.GetLength(0), gridCell.GetLength(1));
            foreach (int x in gridCell)
            {
                Console.Write(x + " ");
                if (y++ % gridCell.GetLength(1) == 0)
                    Console.WriteLine("");
            }
        }
    }
}
