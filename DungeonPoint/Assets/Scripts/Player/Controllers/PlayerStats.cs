namespace Game.Player
{
    using System;
    using Game.Controllers.Characteristics.Stats;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    [Serializable]
    public class PlayerStats
    {
        
        private Atributtes _attr;
        public Atributtes attr { get => _attr; set => _attr = value; }

        [SerializeField]
        private Image imgUIHealth;
        [SerializeField]
        private TextMeshProUGUI txt;
        [SerializeField]
        private Image imgUIBarrier;
        void Start()
        {
            
        }
        public void InitialiceStats(float health, float barrier, float speed)
        {
            attr = new Atributtes(health,barrier, speed);

        }
        private void CalculateValues()
        {
            if(attr.healthCurrent == 0)
            {
                Debug.Log("Player is dead");
            }
            UpdateUI();

        }

        public void TakeDamage(float Amount)
        {
            this.attr.healthCurrent -= Amount;
            UpdateUI();
        }
        public void UpdateUI()
        {
            var healthUI = Mathf.Clamp(attr.healthMax, 0, 100f);
            var barrierUI = Mathf.Clamp(attr.barrierMax, 0, 100f);
            imgUIHealth.fillAmount = healthUI;
            imgUIBarrier.fillAmount = barrierUI;
            txt.text = "HP: " + attr.healthCurrent.ToString();            
        }
    }
}
