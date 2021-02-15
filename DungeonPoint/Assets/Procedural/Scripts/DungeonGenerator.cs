using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Procedural
{
    public class DungeonGenerator : MonoBehaviour
    {
        public RoomLibrary prefabLibrary;

        [Space(10)]

        public int seed = 123;
        public bool randomSeed = false;

        [Space(10)]

        public int dungeonWidth;
        public int dungeonHeight;
        public Room[,] dungeonMap;
        public int roomWidth, roomHeight;
        public int roomDivisions = 3;
        [Min(1)] public float tileSize = 1;

        Room startRoom;

        [HideInInspector] public GameObject dungeon;

        public void Generate()
        {
            dungeonMap = new Room[dungeonWidth, dungeonHeight];

            if (randomSeed)
                seed = Random.Range(-10000, 10000);

            System.Random prng = new System.Random(seed);

            dungeon = new GameObject("Dungeon");

            for (int x = 0; x < dungeonWidth; x++)
            {
                for (int y = 0; y < dungeonHeight; y++)
                {
                    int newWidth = prng.Next(Mathf.RoundToInt(roomWidth * 0.3f),
                        Mathf.RoundToInt(roomWidth * 0.8f));
                    int newHeight = prng.Next(Mathf.RoundToInt(roomHeight * 0.3f),
                        Mathf.RoundToInt(roomHeight * 0.8f));

                    //Trastoco las dimensiones de la room para simplificar el calculo de
                    //los pasillos
                    if (Extensions.Divisible(newWidth, 2))
                        newWidth += 1;
                    if (Extensions.Divisible(newHeight, 2))
                        newHeight += 1;


                    Vector3 startPosition = Vector3.forward * roomHeight * y * tileSize +
                        Vector3.right * roomWidth * x * tileSize;

                    int halfWidth = newWidth / 2;
                    int halfHeight = newHeight / 2;
                    Vector3 startCorner = startPosition - new Vector3(halfWidth, 0, halfHeight) * tileSize;

                    dungeonMap[x, y] = new Room(x, y, startCorner, newWidth, newHeight, tileSize, true);
                    dungeonMap[x, y].Subdivide(prng.Next(-10000,10000), 3, tileSize, roomDivisions);
                }
            }

            startRoom = dungeonMap[prng.Next(0, dungeonWidth), prng.Next(0, dungeonHeight)];

            ConnectRooms();
            ClearIsolatedRooms();

            for (int x = 0; x < dungeonWidth; x++)
            {
                for (int y = 0; y < dungeonHeight; y++)
                {
                    if (dungeonMap[x, y] != null)
                    {
                        GameObject room = new GameObject("Room " + x + ";" + y);
                        room.transform.position = dungeonMap[x, y].startPoint;
                        room.transform.parent = dungeon.transform;
                        dungeonMap[x, y].Draw(tileSize, prefabLibrary, room.transform);

                        foreach (Wall w in dungeonMap[x, y].divisions)
                        {
                            w.Draw(tileSize, prefabLibrary, room.transform);
                        }
                    }
                }
            }
        }

        public void Clear()
        {
            if (dungeon)
                DestroyImmediate(dungeon);
        }

        public void ConnectRooms()
        {
            System.Random prng = new System.Random(seed);

            Room current = startRoom;
            Room next = startRoom;

            while (true)
            {
                Dictionary<Side, Room> aviableRooms = new Dictionary<Side, Room>();
                List<Side> aviableSides = new List<Side>();

                for (Side side = Side.Bottom; side <= Side.Left; side++)
                {
                    int x = Mathf.RoundToInt(current.posX + side.Direction().x);
                    int y = Mathf.RoundToInt(current.posY + side.Direction().z);

                    if (x < 0 || x >= dungeonWidth)
                        continue;

                    if (y < 0 || y >= dungeonHeight)
                        continue;

                    if (dungeonMap[x, y].connectionIn)
                        continue;

                    aviableRooms.Add(side, dungeonMap[x, y]);
                    aviableSides.Add(side);
                }

                if (aviableRooms.Count == 0)
                    break;

                Side selectedSide = aviableSides[prng.Next(0, aviableSides.Count)];
                next = aviableRooms[selectedSide];

                current.Connect(next);

                Vector3 startPoint = current.sides[(int)selectedSide].MiddlePoint;

                current.sides[(int)selectedSide].doorIndices.Add(current.sides[(int)selectedSide].MiddleValue);
                next.sides[(int)selectedSide.Opposite()].doorIndices.Add(next.sides[(int)selectedSide.Opposite()].InverseMiddleValue);
                
                GameObject hgo = new GameObject("Hall");
                hgo.transform.position = startPoint;
                hgo.transform.parent = dungeon.transform;

                float dst = Vector3.Distance(current.sides[(int)selectedSide].MiddlePoint,
                    next.sides[(int)selectedSide.Opposite()].MiddlePoint) / tileSize;

                int length = Mathf.RoundToInt(dst);

                Hall hall = new Hall(selectedSide, startPoint, 1, length);
                hall.Draw(tileSize, prefabLibrary, hgo.transform);

                current = next;
                next = null;
            }
        }

        void ClearIsolatedRooms()
        {
            for (int x = 0; x < dungeonWidth; x++)
            {
                for (int y = 0; y < dungeonHeight; y++)
                {
                    if (!dungeonMap[x, y].connectionIn && !dungeonMap[x, y].connectionOut)
                        dungeonMap[x, y] = null;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(DungeonGenerator))]
    public class DungeonGeneratorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            DungeonGenerator dungeon = (DungeonGenerator)target;

            if (GUILayout.Button("Generate Dungeon", GUILayout.Height(30)))
            {
                dungeon.Clear();
                dungeon.Generate();
            }

            if (GUILayout.Button("Clear Dungeon", GUILayout.Height(30)))
            {
                dungeon.Clear();
            }
        }
    }
#endif
}
