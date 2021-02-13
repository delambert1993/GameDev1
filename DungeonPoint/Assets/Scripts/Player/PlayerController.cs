namespace Game.Entitys.Player
{
    using Controllers;
    using Entitys;
    using Game.Controllers.Characteristics;
    using Game.Player;
    using Game.Systems;
    using UnityEngine;

    [RequireComponent(typeof(InputController))]
    [RequireComponent(typeof(NavController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private SystemLvl _lvl;
        public SystemLvl lvl { get => _lvl; set => _lvl = value; }
        [SerializeField]
        private PlayerStats _charac;
        public PlayerStats charac { get => _charac; set => _charac = new PlayerStats(); }
        private NavController nav;
        private Animator anim;
        #region MainMetods
        void Awake()
        {
            InitializeClass();
        }
        private void Start()
        {
            nav = this.GetComponent<NavController>();
            anim = this.GetComponent<Animator>();
        }
        private void Update()
        {
            anim.SetFloat("speed", nav.nav.velocity.magnitude);
            
        }
        #endregion

        #region HelperMetods        

        private void InitializeClass()
        {
            lvl = new SystemLvl();
            charac.InitialiceStats(100, 100, 10);

            charac.UpdateUI();
        }

        #endregion
    }
}
