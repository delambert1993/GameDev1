using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Procedural
{
    /// <summary>
    /// Datos de generacion para cada una de las habitaciones de la Dungeon
    /// </summary>
    public class Room
    {
        public readonly Vector3 startPoint;

        public readonly int posX;
        public readonly int posY;

        public readonly int width;
        public readonly int height;

        public readonly bool masterRoom;

        //Indicadores que indican si la room tiene una puerta de entrada y una puerta de salida
        public bool connectionIn { get; private set; }
        public Room connectedInRoom { get; private set; }
        public bool connectionOut { get; private set; }
        public Room connectedOutRoom { get; private set; }

        public readonly Vector3 centre;

        public List<Wall> divisions { get; private set; }

        public Vector3 dimensions { get => new Vector3(width, 0, height); }

        public readonly Wall[] sides;

        public Room(int posX, int posY, Vector3 startPoint, int width, int height, float tileSize, bool masterRoom = false)
        {
            divisions = new List<Wall>();

            this.startPoint = startPoint;

            this.posX = posX;
            this.posY = posY;

            this.width = width;
            this.height = height;

            this.masterRoom = masterRoom;

            this.centre = startPoint + new Vector3(width / 2f, 0, height / 2f) * tileSize;

            sides = new Wall[4];
            //Bottom left corner / Bottom side
            sides[0] = new Wall(startPoint, Side.Bottom, width, tileSize);
            //Bottom right corner / Right side
            sides[1] = new Wall(startPoint + Vector3.right * width * tileSize, Side.Right, height, tileSize);
            //Top right corner / Top side
            sides[2] = new Wall(startPoint + Vector3.right * width * tileSize + Vector3.forward * height * tileSize, Side.Top, width, tileSize);
            //Top left corner / Left side
            sides[3] = new Wall(startPoint + Vector3.forward * height * tileSize, Side.Left, height, tileSize);
        }

        public void Subdivide(int seed, int minDimension, float tileSize, int depth = 3)
        {
            Random.InitState(seed);

            if (width <= minDimension)
                return;

            if (height <= minDimension)
                return;

            Side side = (Side)Mathf.RoundToInt(Random.value);
            float randomValue = Random.Range(0.2f, 0.8f);

            int index = sides[(int)side].GetValueAtDelta(randomValue);

            Wall current = new Wall(sides[(int)side].GetPointAtValue(index), side.Next(),
                sides[(int)side.Next()].length + 1, tileSize, true);

            Queue<Wall> pending = new Queue<Wall>();
            pending.Enqueue(current);

            for (int d = 0; d < depth; d++)
            {
                List<Wall> nextWave = new List<Wall>();

                while (pending.Count > 0)
                {
                    current = pending.Dequeue();
                    divisions.Add(current);

                    side = current.side.Next();
                    int length = index + 1;
                    int newIndex = current.RandomValue;

                    nextWave.Add(new Wall(current.GetPointAtValue(newIndex), side, length, tileSize, true));

                    side = current.side.Previous();
                    length = sides[(int)side].length - (index);
                    newIndex = current.RandomValue;

                    nextWave.Add(new Wall(current.GetPointAtValue(newIndex) + side.Perpendicular() * tileSize, side, length, tileSize, true));
                }

                foreach (Wall w in nextWave)
                {
                    pending.Enqueue(w);
                }
            }
        }

        public void Draw(float tileSize, RoomLibrary library, Transform parent)
        {
            for (int i = 0; i < sides.Length; i++)
            {
                sides[i].Draw(tileSize, library, parent);
            }

            for (int x = 1; x < width; x++)
            {
                for (int y = 1; y < height; y++)
                {
                    int index = Random.Range(0, library.FloorTiles.Length);
                    Vector3 position = startPoint + new Vector3(x, 0, y) * tileSize;
                    GameObject tile = GameObject.Instantiate(library.FloorTiles[index], position, Quaternion.identity);
                    tile.transform.parent = parent;
                }
            }
        }

        public void Connect (Room b)
        {
            this.connectionOut = true;
            this.connectedOutRoom = b;

            b.connectionIn = true;
            b.connectedInRoom = this;
        }
    }
}
 