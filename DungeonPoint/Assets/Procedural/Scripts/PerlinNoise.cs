using UnityEngine;
using System.Collections;

namespace Procedural
{
    public class PerlinNoise
    {
        /// <summary>
        /// Generate a map given a width an height
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="seed"></param>
        /// <param name="scale"></param>
        /// <param name="persistance"></param>
        /// <param name="lacunarity"></param>
        /// <param name="octaves"></param>
        /// <param name="curve"></param>
        /// <param name="steps"></param>
        /// <returns></returns>
        public static int[,] Generate(int width, int height, int seed, float scale,
            float persistance, float lacunarity,
            int octaves, AnimationCurve curve, int steps)
        {
            int[,] heightMap = new int[width, height];

            float amplitude = 1;
            float frequency = 1;
            float maxPossibleHeight = 0;


            Vector2[] offsets = new Vector2[octaves];

            System.Random prng = new System.Random(seed);

            for (int i = 0; i < octaves; i++)
            {
                float offsetX = prng.Next(-100000, 100000);
                float offsetY = prng.Next(-100000, 100000);
                offsets[i] = new Vector2(offsetX, offsetY);

                maxPossibleHeight += amplitude;
                amplitude *= persistance;
            }

            float maxLocalNoiseHeight = float.MinValue;
            float minLocalNoiseHeight = float.MaxValue;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    amplitude = 1;
                    frequency = 1;
                    float noiseHeight = 0;

                    for (int i = 0; i < octaves; i++)
                    {
                        float sampleX = (x + offsets[i].x) / scale * frequency;
                        float sampleY = (y + offsets[i].y) / scale * frequency;

                        float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                        noiseHeight += perlinValue * amplitude;

                        amplitude *= persistance;
                        frequency *= lacunarity;
                    }

                    if (noiseHeight > maxLocalNoiseHeight)
                    {
                        maxLocalNoiseHeight = noiseHeight;
                    }
                    if (noiseHeight < minLocalNoiseHeight)
                    {
                        minLocalNoiseHeight = noiseHeight;
                    }

                    float normalizedHeight = noiseHeight / maxPossibleHeight;
                    noiseHeight = normalizedHeight;

                    noiseHeight = curve.Evaluate(noiseHeight);

                    heightMap[x, y] = Mathf.RoundToInt(noiseHeight * steps);
                }
            }

            return heightMap;
        }

        /// <summary>
        /// Generate a map given a shape for it
        /// </summary>
        /// <param name="shape"></param>
        /// <param name="seed"></param>
        /// <param name="scale"></param>
        /// <param name="persistance"></param>
        /// <param name="lacunarity"></param>
        /// <param name="octaves"></param>
        /// <param name="curve"></param>
        /// <param name="steps"></param>
        /// <returns></returns>
        public static int[,] Generate(int[,] shape, int seed, float scale,
            float persistance, float lacunarity,
            int octaves, AnimationCurve curve, int steps)
        {
            int width = shape.GetLength(0);
            int height = shape.GetLength(1);
            int[,] heightMap = new int[width, height];

            float amplitude = 1;
            float frequency = 1;
            float maxPossibleHeight = 0;


            Vector2[] offsets = new Vector2[octaves];

            System.Random prng = new System.Random(seed);

            for (int i = 0; i < octaves; i++)
            {
                float offsetX = prng.Next(-100000, 100000);
                float offsetY = prng.Next(-100000, 100000);
                offsets[i] = new Vector2(offsetX, offsetY);

                maxPossibleHeight += amplitude;
                amplitude *= persistance;
            }

            float maxLocalNoiseHeight = float.MinValue;
            float minLocalNoiseHeight = float.MaxValue;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (shape[x, y] == 1)
                    {
                        amplitude = 1;
                        frequency = 1;
                        float noiseHeight = 0;

                        for (int i = 0; i < octaves; i++)
                        {
                            float sampleX = (x + offsets[i].x) / scale * frequency;
                            float sampleY = (y + offsets[i].y) / scale * frequency;

                            float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                            noiseHeight += perlinValue * amplitude;

                            amplitude *= persistance;
                            frequency *= lacunarity;
                        }

                        if (noiseHeight > maxLocalNoiseHeight)
                        {
                            maxLocalNoiseHeight = noiseHeight;
                        }
                        if (noiseHeight < minLocalNoiseHeight)
                        {
                            minLocalNoiseHeight = noiseHeight;
                        }

                        float normalizedHeight = noiseHeight / maxPossibleHeight;
                        noiseHeight = normalizedHeight;

                        noiseHeight = curve.Evaluate(noiseHeight);

                        heightMap[x, y] = Mathf.RoundToInt(noiseHeight * steps);
                    }
                }
            }

            return heightMap;
        }
    }
}