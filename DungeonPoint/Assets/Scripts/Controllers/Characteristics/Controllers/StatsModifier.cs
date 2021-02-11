namespace Game.Controllers.Characteristics
{ 
    public enum StatModType
    {
        Flat = 100,
        PercentAdd = 200,
        PercentMult = 300,
    }

    public class StatsModifier
    {
        #region Variables
        public readonly float value;
        public readonly StatModType type;
        public readonly int order;
        public readonly object source;
        #endregion

        #region MainMethods
        #endregion

        #region HelperMethods
        public StatsModifier(float Value, StatModType Type, int Order, object Source)
        {
            value = Value;
            type = Type;
            order = Order;
            source = Source;
        }
        public StatsModifier(float value, StatModType type) : this(value, type, (int)type, null) { }
        public StatsModifier(float value, StatModType type, int order) : this(value, type, order, null) { }
        public StatsModifier(float value, StatModType type, object source) : this(value, type, (int)type, source) { }






        #endregion
    }
}
