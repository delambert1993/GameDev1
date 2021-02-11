namespace Game.Systems
{
    using System;
    using UnityEngine;

    public class SystemLvl
    {
        private float _xp;
        public float xp { get => _xp; set => _xp = value; }

        private float _lvlCurrent;
        public float lvlCurrent { get => _lvlCurrent; set => _lvlCurrent = value; }

        public void UpdateXp(int Amount)
        {
            xp = Amount;
            int curLvl = (int)(0.1f * Math.Sqrt(xp));
            if (curLvl != lvlCurrent)
            {
                lvlCurrent = curLvl;
                Debug.Log("Waaawww, has alcanzado un nuevo nivel: " + lvlCurrent.ToString());
            }

            float xpNextLevel = 100 * (lvlCurrent + 1) * (lvlCurrent + 1);
            float differencExp = xpNextLevel - xp;

            float totalDiference = xpNextLevel - (100 * lvlCurrent * lvlCurrent);
        }
    }
}
