
namespace Game.Entitys.Items
{
    using Game.Controllers.Characteristics;
    using Game.Entitys.Items.Interface;
    using Game.Entitys.Player;

    public class ItemStarterPlayer : Item , IAddItem, IRemoveItem
    {
        public override void Equip(StatsSystem Player)
        {
            Player.attr.vitality.AddModifier(new StatsModifier(5, StatModType.Flat));
            Player.attr.defense.AddModifier(new StatsModifier(5, StatModType.Flat));
            Player.attr.barrier.AddModifier(new StatsModifier(5, StatModType.Flat));
            Player.attr.wisdom.AddModifier(new StatsModifier(5, StatModType.Flat));
            Player.attr.damage.AddModifier(new StatsModifier(5, StatModType.Flat));
            Player.attr.strength.AddModifier(new StatsModifier(5, StatModType.Flat));
            Player.attr.movility.AddModifier(new StatsModifier(5, StatModType.Flat));
            Player.attr.agility.AddModifier(new StatsModifier(5, StatModType.Flat));
            Player.attr.intelligence.AddModifier(new StatsModifier(5, StatModType.Flat));
            Player.attr.lucky.AddModifier(new StatsModifier(5, StatModType.Flat));
            Player.attr.sab.AddModifier(new StatsModifier(5, StatModType.Flat));
            Player.attr.scope.AddModifier(new StatsModifier(5, StatModType.Flat));
            Player.attr.criticalRate.AddModifier(new StatsModifier(5, StatModType.Flat));
        }

        public override void UnEquip(StatsSystem Player)
        {
            Player.attr.vitality.RemoveAllModifiersFromSource(this);
            Player.attr.defense.RemoveAllModifiersFromSource(this);
            Player.attr.barrier.RemoveAllModifiersFromSource(this);
            Player.attr.wisdom.RemoveAllModifiersFromSource(this);
            Player.attr.damage.RemoveAllModifiersFromSource(this);
            Player.attr.strength.RemoveAllModifiersFromSource(this);
            Player.attr.movility.RemoveAllModifiersFromSource(this);
            Player.attr.agility.RemoveAllModifiersFromSource(this);
            Player.attr.intelligence.RemoveAllModifiersFromSource(this);
            Player.attr.lucky.RemoveAllModifiersFromSource(this);
            Player.attr.sab.RemoveAllModifiersFromSource(this);
            Player.attr.scope.RemoveAllModifiersFromSource(this);
            Player.attr.criticalRate.RemoveAllModifiersFromSource(this);
        }
    }
}
