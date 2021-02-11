namespace Game.Entitys.Player
{
    using Controllers;
    using Entitys;
    using Game.Player;
    using Game.Systems;
    using UnityEngine;

    [RequireComponent(typeof(InputController))]
    [RequireComponent(typeof(NavController))]
    public class PlayerController : PlayerBase
    {
        [SerializeField]
        private SystemLvl _lvl;
        public SystemLvl lvl { get => _lvl; set => _lvl = value; }
        [SerializeField]
        private PlayerStats _charac;
        public PlayerStats charac { get => _charac; set => _charac = value; }

        #region MainMetods
        void OnEnable()
        {
            InitializeClass();
        }
        #endregion

        #region HelperMetods        

        private void InitializeClass()
        {
            lvl = new SystemLvl();
            charac = new StatsSystem();
            charac.InitializeStats(10f);
            charac.HealthStatInit();
        }

        #endregion
    }
}
