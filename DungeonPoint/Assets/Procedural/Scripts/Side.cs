using System.Collections;
using UnityEngine;

namespace Procedural
{
    public enum Side
    {
        Bottom,
        Right,
        Top,
        Left
    }

    public static class SideExtensions
    {
        /// <summary>
        /// El lado opuesto
        /// </summary>
        /// <param name="side"></param>
        /// <returns></returns>
        public static Side Opposite(this Side side)
        {
            return (int)side < 2 ? (side + 2) : (side - 2);
        }

        /// <summary>
        /// El lado anterior
        /// </summary>
        /// <param name="side"></param>
        /// <returns></returns>
        public static Side Previous(this Side side)
        {
            return side == Side.Bottom ? Side.Left : side - 1;
        }

        /// <summary>
        /// El lado que le sigue
        /// </summary>
        /// <param name="side"></param>
        /// <returns></returns>
        public static Side Next(this Side side)
        {
            return side == Side.Left ? Side.Bottom : side + 1;
        }

        /// <summary>
        /// Devuele el vector de direccion del lado con respecto al centro de la room
        /// </summary>
        /// <param name="side"></param>
        /// <returns></returns>
        public static Vector3 Direction (this Side side)
        {
            Vector3 retVal = Vector2.zero;

            switch (side)
            {
                case Side.Top:
                    retVal = Vector3.forward;
                    break;

                case Side.Right:
                    retVal = Vector3.right;
                    break;

                case Side.Bottom:
                    retVal = Vector3.back;
                    break;

                case Side.Left:
                    retVal = Vector3.left;
                    break;
            }

            return retVal;
        }

        public static Vector3 AbsDirection(this Side side)
        {
            Vector3 retVal = Vector2.zero;

            switch (side)
            {
                case Side.Top:
                    retVal = Vector3.forward;
                    break;

                case Side.Right:
                    retVal = Vector3.right;
                    break;

                case Side.Bottom:
                    retVal = Vector3.forward;
                    break;

                case Side.Left:
                    retVal = Vector3.right;
                    break;
            }

            return retVal;
        }

        /// <summary>
        /// Devuelve un lado basandose en una direccion
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static Side FromDirection (Vector3 direction)
        {
            Side retVal = Side.Top;

            if (direction == Vector3.forward)
                retVal = Side.Top;
            else if (direction == Vector3.right)
                retVal = Side.Right;
            else if (direction == Vector3.back)
                retVal = Side.Bottom;
            else if (direction == Vector3.left)
                retVal = Side.Left;

            return retVal;
        }

        /// <summary>
        /// Vector perpendicular a la direccion del lado
        /// </summary>
        /// <param name="side"></param>
        /// <returns></returns>
        public static Vector3 Perpendicular (this Side side)
        {
            Vector3 retVal = Vector3.zero;

            switch (side)
            {
                case Side.Bottom:
                    retVal = Vector3.right;
                    break;

                case Side.Right:
                    retVal = Vector3.forward;
                    break;

                case Side.Top:
                    retVal = Vector3.left;
                    break;

                case Side.Left:
                    retVal = Vector3.back;
                    break;
            }

            return retVal;
        }

        public static Vector3 AbsPerpendicular (this Side side)
        {
            Vector3 retVal = Vector3.zero;

            switch (side)
            {
                case Side.Bottom:
                    retVal = Vector3.right;
                    break;

                case Side.Right:
                    retVal = Vector3.forward;
                    break;

                case Side.Top:
                    retVal = Vector3.right;
                    break;

                case Side.Left:
                    retVal = Vector3.forward;
                    break;
            }

            return retVal;
        }
    }
}