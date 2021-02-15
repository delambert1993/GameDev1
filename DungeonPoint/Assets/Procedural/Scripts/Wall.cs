using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Procedural
{
    /// <summary>
    /// Datos de generacion para los muros de la Room
    /// </summary>
    public class Wall
    {
        public readonly Vector3 startPoint;
        public readonly Vector3 endPoint;
        readonly Vector3 direction;
        public readonly int length;
        public readonly Side side;
        public readonly bool divisionWall;

        public List<int> doorIndices = new List<int>();

        /// <summary>
        /// Create a side for a wall in a room
        /// </summary>
        /// <param name="startPoint">The point where the wall will start</param>
        /// <param name="direction">The direction of the wall</param>
        /// <param name="length">The length of the wall</param>
        public Wall(Vector3 startPoint, Side side, int length, float tileSize, bool divisionWall = false)
        {
            this.startPoint = startPoint;
            this.side = side;
            this.direction = side.Perpendicular();

            this.endPoint = startPoint + direction * length * tileSize;

            this.length = length;

            this.divisionWall = divisionWall;
        }

        /// <summary>
        /// Draw the side in the scene using boxes
        /// </summary>
        public void Draw(float tileSize, RoomLibrary library, Transform parent)
        {
            GameObject wall = new GameObject("Wall");
            wall.transform.parent = parent;
            wall.transform.position = startPoint + direction * tileSize;

            for (int i = 0; i < length; i++)
            {
                Vector3 position = startPoint + direction * i * tileSize;
                    GameObject tile = null;
                int index = 0;

                if (direction == Vector3.right)
                {
                    if (!divisionWall)
                    {
                        if (i == 0)
                        {
                            index = Random.Range(0, library.BottomLeftInnerCorner.Length);
                            tile = GameObject.Instantiate(library.BottomLeftInnerCorner[index],
                                position, Quaternion.identity);
                        }
                        else
                        {
                            if (!doorIndices.Contains(i))
                            {
                                index = Random.Range(0, library.BottomBorder.Length);
                                tile = GameObject.Instantiate(library.BottomBorder[index],
                                    position, Quaternion.identity);
                            }
                            else
                            {
                                index = Random.Range(0, library.BottomBorderDoor.Length);
                                tile = GameObject.Instantiate(library.BottomBorderDoor[index],
                                    position, Quaternion.identity);
                            }
                        }
                    }
                    else
                    {
                        index = Random.Range(0, library.HorizontalDivisions.Length);
                        tile = GameObject.Instantiate(library.HorizontalDivisions[index],
                                position, Quaternion.identity);
                    }
                }
                else if (direction == Vector3.forward)
                {
                    if (!divisionWall)
                    {
                        if (i == 0)
                        {
                            index = Random.Range(0, library.BottomRightInnerCorner.Length);
                            tile = GameObject.Instantiate(library.BottomRightInnerCorner[index],
                                position, Quaternion.identity);
                        }
                        else
                        {
                            if (!doorIndices.Contains(i))
                            {
                                index = Random.Range(0, library.RightBorder.Length);
                                tile = GameObject.Instantiate(library.RightBorder[index],
                                    position, Quaternion.identity);
                            }
                            else
                            {
                                index = Random.Range(0, library.RightBorderDoor.Length);
                                tile = GameObject.Instantiate(library.RightBorderDoor[index],
                                    position, Quaternion.identity);
                            }
                        }
                    }
                    else
                    {
                        index = Random.Range(0, library.VerticalDivisions.Length);
                        tile = GameObject.Instantiate(library.VerticalDivisions[index],
                                position, Quaternion.identity);
                    }
                }
                else if (direction == Vector3.left)
                {
                    if (!divisionWall)
                    {
                        if (i == 0)
                        {
                            index = Random.Range(0, library.TopRightInnerCorner.Length);
                            tile = GameObject.Instantiate(library.TopRightInnerCorner[index],
                                position, Quaternion.identity);
                        }
                        else
                        {
                            if (!doorIndices.Contains(i))
                            {
                                index = Random.Range(0, library.TopBorder.Length);
                                tile = GameObject.Instantiate(library.TopBorder[index],
                                    position, Quaternion.identity);
                            }
                            else
                            {
                                index = Random.Range(0, library.TopBorderDoor.Length);
                                tile = GameObject.Instantiate(library.TopBorderDoor[index],
                                    position, Quaternion.identity);
                            }
                        }
                    }
                    else
                    {
                        index = Random.Range(0, library.HorizontalDivisions.Length);
                        tile = GameObject.Instantiate(library.HorizontalDivisions[index],
                                position, Quaternion.identity);
                    }
                }
                else if (direction == Vector3.back)
                {
                    if (!divisionWall)
                    {
                        if (i == 0)
                        {
                            index = Random.Range(0, library.TopLeftInnerCorner.Length);
                            tile = GameObject.Instantiate(library.TopLeftInnerCorner[index],
                                position, Quaternion.identity);
                        }
                        else
                        {
                            if (!doorIndices.Contains(i))
                            {
                                index = Random.Range(0, library.LeftBorder.Length);
                                tile = GameObject.Instantiate(library.LeftBorder[index],
                                    position, Quaternion.identity);
                            }
                            else
                            {
                                index = Random.Range(0, library.LeftBorderDoor.Length);
                                tile = GameObject.Instantiate(library.LeftBorderDoor[index],
                                    position, Quaternion.identity);
                            }
                        }
                    }
                    else
                    {
                        index = Random.Range(0, library.VerticalDivisions.Length);
                        tile = GameObject.Instantiate(library.VerticalDivisions[index],
                                position, Quaternion.identity);
                    }
                }

                tile.transform.position = position;
                tile.transform.parent = wall.transform;
            }
        }

        /// <summary>
        /// Return a random value in the side
        /// </summary>
        public int RandomValue
        {
            get
            {
                int min = Mathf.RoundToInt(length * 0.2f);
                int max = Mathf.RoundToInt(length * 0.8f);
                return Random.Range(min, max);
            }
        }

        /// <summary>
        /// Return a random point in the side
        /// </summary>
        public Vector3 RandomPoint
        {
            get
            {
                int min = Mathf.RoundToInt(length * 0.2f);
                int max = Mathf.RoundToInt(length * 0.8f);
                return Vector3.Lerp(startPoint, endPoint, Random.Range(min, max) / length);
            }
        }

        /// <summary>
        /// Return the middle value of the side
        /// </summary>
        public int MiddleValue
        {
            get
            {
                return Mathf.FloorToInt(Mathf.Lerp(0, length, 0.5f));
            }
        }

        public int InverseMiddleValue
        {
            get
            {
                return Mathf.CeilToInt(Mathf.Lerp(length, 0, 0.5f));
            }
        }

        /// <summary>
        /// Return the middle point of the side
        /// </summary>
        public Vector3 MiddlePoint
        {
            get
            {
                return Vector3.Lerp(startPoint, endPoint, MiddleValue / (float)length);
            }
        }

        public Vector3 InverseMiddlePoint
        {
            get
            {
                return Vector3.Lerp(startPoint, endPoint, InverseMiddleValue / (float)length);
            }
        }

        /// <summary>
        /// Return a value at given delta
        /// </summary>
        /// <param name="delta">A number between 0 and 1</param>
        /// <returns></returns>
        public int GetValueAtDelta(float delta)
        {
            float clampedDelta = Mathf.Clamp01(delta);
            return Mathf.FloorToInt(Mathf.Lerp(0, length, clampedDelta));
        }

        public int GetInverseValueAtDelta(float delta)
        {
            float clampedDelta = Mathf.Clamp01(delta);
            return Mathf.CeilToInt(Mathf.Lerp(length, 0, clampedDelta));
        }

        /// <summary>
        /// Return a point at given delta
        /// </summary>
        /// <param name="delta">A number between 0 and 1</param>
        /// <returns></returns>
        public Vector3 GetPointAtDelta(float delta)
        {
            float clampedDelta = Mathf.Clamp01(delta);
            return Vector3.Lerp(startPoint, endPoint, delta);
        }

        public Vector3 GetInversePointAtDelta(float delta)
        {
            float clampedDelta = Mathf.Clamp01(delta);
            return Vector3.Lerp(endPoint, startPoint, delta);
        }

        public Vector3 GetPointAtValue (int value)
        {
            float t = (float)value / (float)length;
            return Vector3.Lerp(startPoint, endPoint, t);
        }

        public Vector3 GetInversePointAtValue(int value)
        {
            float t = (float)value / (float)length;
            return Vector3.Lerp(endPoint, startPoint, t);
        }
    }
}