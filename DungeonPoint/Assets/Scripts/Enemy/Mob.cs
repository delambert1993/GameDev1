namespace Assets.Scripts.Enemy
{
    using Game.Entitys.Player;
    using UnityEngine;
    public class Mob : MonoBehaviour
    {
        public float xpAmount = 10f;
        public float health;
        public float speed;
        public GameObject effect;
        private void Awake()
        {
            health = 100f;            
        }

        void Start()
        {
            Debug.Log("Enemy Started");
        }
        public void TakeDamage(float amount, Vector3 direction)
        {
            
            health -= amount;
            DieOrReact();
            HitEffect();
            this.transform.Translate((this.transform.position - direction) * speed * Time.deltaTime);
            
            Debug.Log("Health Enemy: " + this.health);
        }

        void DieOrReact()
        {
            if(this.health <= 0)
            {
                XpSystem.instance.AddXP(xpAmount);
                Destroy(this.gameObject);
            }            
        }

        void HitEffect()
        {
            var efectIns = Instantiate(effect, transform.position, Quaternion.identity);            
            Destroy(efectIns, .5f);
        }
    }
}
