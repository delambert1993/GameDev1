namespace Game.Controllers.Characteristics.Stats
{
    using UnityEngine;
    public class Characteristic
    {
        #region Variables
        private float _expCurrent;
        public float expCurrent { get => _healthCurrent; set => _healthCurrent = value; }
        private float _healthMax;
        public float healthMax { get => _healthCurrent; set => _healthCurrent = value; }
        private float _healthCurrent;
        public float healthCurrent { get => _healthCurrent; set => _healthCurrent = value; }

        private float _defenseCurrent;
        public float defenseCurrent { get => _defenseCurrent; set => _defenseCurrent = value; }

        private float _barrierCurrent;
        public float barrierCurrent { get => _barrierCurrent; set => _barrierCurrent = value; }

        private float _wisdomCurrent; //Sabiduria 
        public float wisdomCurrent { get => _wisdomCurrent; set => _wisdomCurrent = value; }

        private float _damageCurrent;
        public float damageCurrent { get => _damageCurrent; set => _damageCurrent = value; }

        private float _strengthCurrent;
        public float strengthCurrent { get => _strengthCurrent; set => _strengthCurrent = value; }

        private float _speedCurrent;
        public float speedCurrent { get => _speedCurrent; set => _speedCurrent = value; }

        private float _agilityCurrent;
        public float agilityCurrent { get => _agilityCurrent; set => _agilityCurrent = value; }

        private float _intelligenceCurrent;
        public float intelligenceCurrent { get => _intelligenceCurrent; set => _intelligenceCurrent = value; }

        private float _luckyCurrent;
        public float luckyCurrent { get => _luckyCurrent; set => _luckyCurrent = value; }

        private float _sabCurrent; //Modificador de experincia
        public float sabCurrent { get => _sabCurrent; set => _sabCurrent = value; }

        private float _scopeCurrent;
        public float scopeCurrent { get => _scopeCurrent; set => _scopeCurrent = value; }

        private float _criticalRateCurrent;
        public float criticalRateCurrent { get => _criticalRateCurrent; set => _criticalRateCurrent = value; }

        #endregion
        public Characteristic(float HealthMax)
        {
            healthMax = HealthMax;

            healthCurrent = 1f;
            defenseCurrent = 1;
            barrierCurrent = 5000f;
            wisdomCurrent = 1;
            damageCurrent = 1;
            strengthCurrent = 1;
            speedCurrent = 1;
            agilityCurrent = 1;
            intelligenceCurrent = 1;
            luckyCurrent = 1;
            sabCurrent = 1;
            scopeCurrent = 1;
            criticalRateCurrent = 1;
        }
    }
}
