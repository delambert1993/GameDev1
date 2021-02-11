namespace Game.Entitys.Player
{
    using Game.Controllers.Characteristics.Stats;
    using UnityEngine;

    public class StatsSystem
    {

        #region Variables
        private Characteristic _stats;
        public Characteristic stats { get => _stats; set => _stats = value; }

        private Atributtes _attr;
        public Atributtes attr { get => _attr; set => _attr = value; }

        private 
        #endregion


        #region MainMethods
        void Awake()
        {
        }
        private void OnEnabled()
        {
            
        }
        #endregion
        #region HelperMethods
        public void InitializeStats(float Vida)
        {
            stats = new Characteristic(Vida);
            attr = new Atributtes();
            HealthStatInit();
            stats.healthCurrent = stats.healthMax;

        }
        public void HealthStatInit()
        {
            this.stats.healthMax = attr.vitality.baseValue * stats.healthMax;
            this.stats.healthCurrent = stats.healthMax;
        }
        #endregion
    }
}
