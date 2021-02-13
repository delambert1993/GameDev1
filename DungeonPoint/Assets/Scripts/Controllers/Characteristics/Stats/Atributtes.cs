namespace Game.Controllers.Characteristics.Stats
{
    using System;
    using UnityEngine;

    public class Atributtes
    {        
        #region Variables
                
        
        private float _healthMax;
        public float healthMax { get => _healthMax; set => _healthMax = value; }        
        private float _healthCurrent;
        public float healthCurrent { get => _healthCurrent; set => _healthCurrent = value; }
        private float _barrierCurrent;
        public float barrierCurrent { get => _barrierCurrent; set => _barrierCurrent = value; }

        private float _barrierMax;
        public float barrierMax { get => _barrierMax; set => _barrierMax = value; }

        private float _xpMax;
        public float xpMax { get => _xpMax; set => _xpMax = value; }

        private float _xpCurrent;
        public float xpCurrent { get => _xpCurrent; set => _xpCurrent = value; }

        private float _speed;
        public float speed { get => _speed; set => _speed = value; }

        private float _damage;
        public float damage { get => _damage; set => _damage = value; }

        public Atributtes(float health, float barrier, float speed, float damage)
        {
            this.healthMax = health;
            this.barrierMax = barrier;
            this.healthCurrent = healthMax;
            this.barrierCurrent = barrierMax;
            this.speed = speed;
            this.damage = damage;
                
        }

        #endregion
    }
}
