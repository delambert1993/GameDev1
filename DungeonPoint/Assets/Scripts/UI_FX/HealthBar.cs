namespace Game.UI_UX
{
    using Game.Entitys.Player;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private Image img;
        [SerializeField]
        private TextMeshProUGUI text;
        private float fillAmount;
        public float maxHealth;
        public float currHealth;
        [SerializeField]
        public PlayerController pc;
        float finalHealth;
        
        void Start()
        {    
            pc = FindObjectOfType<PlayerController>();

            img = GetComponentInChildren<Image>();
            text = GetComponentInChildren<TextMeshProUGUI>();

            this.maxHealth = pc.charac.stats.healthMax;
            this.currHealth = pc.charac.stats.health;

        }
        void Update()
        {
            BarController();    
        }

        void BarController()
        {
            finalHealth = this.currHealth / this.maxHealth;
            img.fillAmount = Mathf.MoveTowards(img.fillAmount, finalHealth, Time.deltaTime);
            text.text = "Hp: " + currHealth;            
            
        }
    }
}
