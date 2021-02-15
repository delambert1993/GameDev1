using System.Collections;
using UnityEngine;

namespace Procedural
{
    /// <summary>
    /// Datos de generacion para los pasillos que conectan las Rooms
    /// </summary>
    public class Hall
    {
        readonly int width;
        readonly int length;
        public readonly Vector3 startPoint;
        readonly Side side;

        public Hall(Side side, Vector3 startPoint, int width, int length)
        {
            this.width = width;

            this.side = side;

            this.length = length;
            this.startPoint = startPoint;
        }

        public void Draw(float tileSize, RoomLibrary library, Transform parent)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 1; y < length; y++)
                {
                    Vector3 position = startPoint + side.Perpendicular() * x * tileSize + side.Direction() * y * tileSize;

                    if (side == Side.Left || side == Side.Right)
                    {
                        int index = Random.Range(0, library.HorizontalHallway.Length);
                        GameObject tile = GameObject.Instantiate(library.HorizontalHallway[index], position, Quaternion.identity);
                        tile.transform.parent = parent;
                    }

                    if (side == Side.Top || side == Side.Bottom)
                    {
                        int index = Random.Range(0, library.VerticalHallway.Length);
                        GameObject tile = GameObject.Instantiate(library.VerticalHallway[index], position, Quaternion.identity);
                        tile.transform.parent = parent;
                    }
                }
            }
        }
    }
}