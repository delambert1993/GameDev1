using System.Collections;
using UnityEngine;

namespace Procedural
{
    public static class Extensions
    {
        public static bool Divisible(float number, float divider)
        {
            float mod = number / divider;
            if (mod - Mathf.FloorToInt(mod) > 0)
                return false;
            else
                return true;
        }
    }
}