namespace Game.Entitys.Items
{
    using Game.Controllers.Characteristics;
    using Game.Entitys.Player;
    using UnityEngine;

    public abstract class Item : MonoBehaviour
    {
        protected StatsModifier mod1, mod2;

        public virtual void Equip(StatsSystem c)
        {
            //c.stats.strength.AddModifier(mod1);
            //c.stats.health.AddModifier(new StatsModifier(100, StatModType.Flat));
            //c.stats.strength.AddModifier(new StatsModifier(0.1f, StatModType.PercentMult, this));
        }
        public virtual void UnEquip(StatsSystem c)
        {
        }
    }
}
