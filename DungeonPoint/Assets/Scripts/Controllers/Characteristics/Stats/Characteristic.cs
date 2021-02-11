namespace Game.Controllers.Characteristics.Stats
{
    using UnityEngine;
    public class Characteristic
    {
        #region Variables        
        
        private float _health;
        public float health { get => _health; set => _health = value; }

        private float _defense;
        public float defense { get => _defense; set => _defense = value; }

        private float _barrier;
        public float barrier { get => _barrier; set => _barrier = value; }

        private float _powerDamage; //Sabiduria 
        public float powerDamage { get => _powerDamage; set => _powerDamage = value; }

        private float _physicalDamage;
        public float physicalDamage { get => _physicalDamage; set => _physicalDamage = value; }

        private float _velocity;
        public float velocity { get => _velocity; set => _velocity = value; }

        private float _physicalResistance;
        public float physicalResistance { get => _physicalResistance; set => _physicalResistance = value; }

        private float _powerResistance;
        public float powerResistance { get => _powerResistance; set => _powerResistance = value; }

        private float _criticalRate;
        public float criticalRate { get => _criticalRate; set => _criticalRate = value; }

        #endregion
        public Characteristic()
        {       
            health = 1f;
            defense = 1;
            barrier = 5000f;
            velocity = 1;
            physicalDamage = 1;            
            powerDamage = 1;
            physicalResistance = 1;
            powerResistance = 1;
            criticalRate = 1;
        }
    }
}
