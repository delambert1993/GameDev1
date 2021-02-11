namespace Game.Player
{
    using System;
    using Game.Controllers.Characteristics.Stats;
    using UnityEngine;
    [Serializable]
    public class PlayerStats : MonoBehaviour
    {
        private Attribute _attr;
        public Attribute attr { get => _attr; set=> _attr = value; }
        private Characteristic _charac;
        public Characteristic charac { get => _charac; set => _charac = value; }

        private float lvlCurrent;
        private float xp;
        private float xpCurrent;

        private int[] toLevelUp;
        private int[] attackLevels;
        private int[] defenceLevels;

        private float healthCurrent;
        private float defenseCurrent;
        private float barrierCurrent;
        private float speedCurrent;
        private float physicDamageCurrent;
        private float powerDamageCurrent;
        private float physicResistanceCurrent;
        private float powerResistanceCurrent;
        private float criticalRate;

        /*       
            health = 1f;
            defense = 1;
            barrier = 5000f;
            velocity = 1;
            physicalDamage = 1;            
            powerDamage = 1;
            physicalResistance = 1;
            powerResistance = 1;
            criticalRate = 1;*/


    }
}
