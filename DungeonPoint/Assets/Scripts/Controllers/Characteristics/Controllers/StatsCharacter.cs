namespace Game.Controllers.Characteristics
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    [Serializable]
    public class StatsCharacter
    {
        #region Variables
        protected float _baseValue;
        public float baseValue { get => _baseValue; set => _baseValue = value; }

        protected float _value;
        public virtual float value 
        {
            get
            {
                if (isDirty || baseValue != lastBaseValue)
                {
                    lastBaseValue = baseValue;
                    _value = CalculateFinalValue();
                    isDirty = false;
                }
                return _value;
            }
        }

        protected bool isDirty = true;
        protected float lastBaseValue = float.MinValue;

        protected readonly List<StatsModifier> statsModifiers;
        public readonly ReadOnlyCollection<StatsModifier> StatsModifiers;

        #endregion
        #region MainMethods
        #endregion
        #region HelperMethods
        public StatsCharacter()
        {
            statsModifiers = new List<StatsModifier>();
            StatsModifiers = statsModifiers.AsReadOnly();
        }

         public StatsCharacter(float BaseValue) : this()
        {
            baseValue = BaseValue;
        }

       
         public virtual void AddModifier(StatsModifier mod)
        {
            isDirty = true;
            statsModifiers.Add(mod);
            statsModifiers.Sort();

        }
        protected virtual int CompareModifierOrder(StatsModifier a, StatsModifier b)
        {
            if (a.order < b.order)
                return -1;
            else if (a.order > b.order)
                return 1;
            return 0; //if (a.order == b.order)
        }
         public virtual bool RemoveModifier(StatsModifier mod)
        {

            if(statsModifiers.Remove(mod))
            {
                isDirty = true;
                return true;
            }
            return false;
        }

         public virtual bool RemoveAllModifiersFromSource(object Source)
        {
            bool didRemove = false;
            for (int i = statsModifiers.Count -1; i >=0; i--)
            {
                if(statsModifiers[i].source == Source)
                {
                    isDirty = true;
                    didRemove = true;
                    statsModifiers.RemoveAt(i);
                }
            }
            return didRemove;
        }
        protected virtual float CalculateFinalValue()
        {
            float finalValue = baseValue;
            float sumPercentAdd = 0;

            for (int i = 0; i < statsModifiers.Count; i++)
            {
                StatsModifier mod = statsModifiers[i];
                if (mod.type == StatModType.Flat)
                {
                    finalValue += mod.value;
                }
                else if (mod.type == StatModType.PercentAdd)
                {
                    sumPercentAdd += mod.value;

                    if (i + 1 >= statsModifiers.Count || statsModifiers[i + 1].type != StatModType.PercentAdd)
                    {
                        finalValue *= 1 + sumPercentAdd;
                        sumPercentAdd = 0;
                    }
                }
                else if (mod.type == StatModType.PercentMult)
                {
                    finalValue *= 1 + mod.value;
                }

                finalValue += statsModifiers[i].value;
            }
            return (float)Math.Round(finalValue, 4);
        }
      
    }
    #endregion
}

