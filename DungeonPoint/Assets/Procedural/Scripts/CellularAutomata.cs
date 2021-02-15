using System.Collections;
using UnityEngine;

namespace Procedural
{
    public class CellularAutomata
    {

        /// <summary>
        /// Generate the shape of the island
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="seed"></param>
        /// <param name="probability">The land probability. A number between 0 and 100</param>
        /// <returns></returns>
        public static int[,] Generate(int width, int height, int seed, int probability, int passes = 1)
        {
            int[,] shape = new int[width, height];

            Random.InitState(seed);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    bool value = Random.Range(0, 101) <= probability;

                    if (value)
                        shape[x, y] = 1;
                    else
                        shape[x, y] = 0;
                }
            }

            for (int p = 0; p < passes; p++)
            {
                int[,] newShape = new int[width, height];

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        int neighbours = 0;

                        #region Neighbour count
                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                if (j == 0 && i == 0)
                                    continue;

                                int newX = x + i;
                                int newY = y + j;

                                if (newX >= 0 && newX < width &&
                                    newY >= 0 && newY < height)
                                {
                                    neighbours += shape[newX, newY];
                                }
                            }
                        }
                        #endregion

                        if (neighbours >= 6)
                            newShape[x, y] = 1;

                        if (neighbours <= 4)
                            newShape[x, y] = 0;
                    }
                }

                shape = newShape;
            }

            return shape;
        }
    }
}