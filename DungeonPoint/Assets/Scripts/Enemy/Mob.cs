namespace Assets.Scripts.Enemy
{
    using UnityEngine;
    public class Mob : MonoBehaviour
    {
        public float health;
        private void Awake()
        {
            health = 100f;            
        }

        void Start()
        {
            Debug.Log("Enemy Started");
        }
        public void TakeDamage(float amount)
        {
            
            health -= amount;
            Debug.Log("Health Enemy: " + this.health);
        }
    }
}
