﻿namespace Game.Entitys.Player
{
    using Assets.Scripts.Enemy;
    using Controllers;
    using Game.Player;
    using Game.Systems;
    using UnityEngine;

    [RequireComponent(typeof(InputController))]
    [RequireComponent(typeof(NavController))]
    public class PlayerController : MonoBehaviour
    {
        InputController input;
        [SerializeField]
        private float _xpCurrent;
        public float xpCurrent { get => _xpCurrent; set => _xpCurrent = value; }
        private float _toLvlUp;
        public float toLvlUp { get => _toLvlUp; set => _toLvlUp = value; }
        private SystemLvl _lvl;
        public SystemLvl lvl { get => _lvl; set => _lvl = value; }
        [SerializeField]
        private PlayerStats _charac;
        public PlayerStats charac { get => _charac; set => _charac = new PlayerStats(); }
        private NavController nav;
        private Animator _anim;
        public Animator anim { get => _anim; set => _anim = value; }
        public AudioFeet clipFeet;

        //Interaction
        private GameObject triggeringNpc;
        private bool triggering;        
        //Attack
        float timeBtwAttack;
        public float startBtwAttack;
        public Transform attackPos;
        public LayerMask whatIsEnemies;
        public float attackRange;
        public float damage;

        #region MainMetods
        void Awake()
        {
            InitializeClass();
            
        }
        private void Start()
        {
            anim = this.GetComponent<Animator>();
            clipFeet = FindObjectOfType<AudioFeet>();
            nav = this.GetComponent<NavController>();
            input = new InputController(anim);
        }
        private void LateUpdate()
        {
            
        }
        private void Update()
        {
            AnimationsPlayer.instance.Attack();

            anim.SetFloat("speed", nav.nav.velocity.magnitude);
            if(Input.GetKeyUp(KeyCode.Space))
            {
                XpSystem.instance.AddXP(10);
            }
                XpSystem.instance.GetXP();

            if(triggering)
            {
                print("Player is triggering with " + triggeringNpc.name);
            }

        }       

        #endregion

        #region HelperMetods     
        
        void Pisar()
        {
            clipFeet.PlaySound();
        }
        void AttackColdown()
        {
            /*if (timeBtwAttack <= 0)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    anim.SetTrigger("shake");
                    anim.SetTrigger("atack");                                    
                    Collider[] enemiesToDamage = Physics.OverlapSphere(attackPos.position, attackRange, whatIsEnemies);
                    
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
                        if (enemiesToDamage[i])
                        {
                            enemiesToDamage[i].GetComponent<Mob>().TakeDamage(damage, this.transform.position);
                            Debug.Log("Health -");
                        }
                    }
                
                    timeBtwAttack = startBtwAttack;
                }
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }*/
        }

        void GetXP()
        {
            XpSystem.instance.GetXP();
        }
        private void InitializeClass()
        {
            lvl = new SystemLvl();
            charac.InitialiceStats(100, 100, 10, 10);
            charac.UpdateUI();
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);
        }
        #endregion
    }
}
