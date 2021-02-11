namespace Game.Controllers.Characteristics.Stats
{
    using System;
    using UnityEngine;

    [Serializable]
    public class Atributtes
    {        
        #region Variables
                
        [SerializeField]
        private StatsCharacter _vitality;
        public StatsCharacter vitality { get => _vitality; set => _vitality = value; }

        private StatsCharacter _defense;
        public StatsCharacter defense { get => _defense; set => _defense = value; }

        private StatsCharacter _barrier;
        public StatsCharacter barrier { get => _barrier; set => _barrier = value; }

        private StatsCharacter _wisdom; //Sabiduria 
        public StatsCharacter wisdom { get => _wisdom; set => _wisdom = value; }

        private StatsCharacter _damage;
        public StatsCharacter damage { get => _damage; set => _damage = value; }

        private StatsCharacter _strength;
        public StatsCharacter strength { get => _strength; set => _strength = value; }

        private StatsCharacter _movility;
        public StatsCharacter movility { get => _movility; set => _movility = value; }

        private StatsCharacter _agility;
        public StatsCharacter agility { get => _agility; set => _agility = value; }

        private StatsCharacter _intelligence;
        public StatsCharacter intelligence { get => _intelligence; set => _intelligence = value; }

        private StatsCharacter _lucky;
        public StatsCharacter lucky { get => _lucky; set => _lucky = value; }

        private StatsCharacter _sab;
        public StatsCharacter sab { get => _sab; set => _sab = value; }

        private StatsCharacter _scope;
        public StatsCharacter scope { get => _scope; set => _scope = value; }

        private StatsCharacter _criticalRate;
        public StatsCharacter criticalRate { get => _criticalRate; set => _criticalRate = value; }
        
        #endregion
        public Atributtes()
        {
            this.vitality = new StatsCharacter(5);
            defense = new StatsCharacter(5);
            barrier = new StatsCharacter(5000f);
            wisdom = new StatsCharacter(1);
            damage = new StatsCharacter(1);
            strength = new StatsCharacter(1);
            agility = new StatsCharacter(1);
            intelligence = new StatsCharacter(1);
            lucky = new StatsCharacter(1);
            sab = new StatsCharacter(1);
            scope = new StatsCharacter(1);
            criticalRate = new StatsCharacter(1);
        }
    }
}
