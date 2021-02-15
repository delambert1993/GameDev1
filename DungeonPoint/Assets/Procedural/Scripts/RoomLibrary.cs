using System.Collections;
using UnityEngine;

namespace Procedural
{
    [CreateAssetMenu(menuName ="Top Down Engine/Procedural/Dungeon Library", fileName = "New Dungeon Library")]
    public class RoomLibrary : ScriptableObject
    {
        //Inner Corners
        [Header("Inner Corners")]
        public GameObject[] TopLeftInnerCorner;
        public GameObject[] TopRightInnerCorner;
        public GameObject[] BottomLeftInnerCorner;
        public GameObject[] BottomRightInnerCorner;

        //Border Walls
        [Header ("Border Walls")]
        public GameObject[] TopBorder;
        public GameObject[] BottomBorder;
        public GameObject[] LeftBorder;
        public GameObject[] RightBorder;

        //Border Doors
        [Header("Border Doors")]
        public GameObject[] TopBorderDoor;
        public GameObject[] BottomBorderDoor;
        public GameObject[] LeftBorderDoor;
        public GameObject[] RightBorderDoor;

        //Floor tiles
        [Header("Floor Tiles")]
        public GameObject[] FloorTiles;

        //Hallways
        [Header("Hallways")]
        public GameObject[] HorizontalHallway;
        public GameObject[] VerticalHallway;

        //Divisions
        [Header("Inner Divisions")]
        public GameObject[] VerticalDivisions;
        public GameObject[] HorizontalDivisions;
    }
}