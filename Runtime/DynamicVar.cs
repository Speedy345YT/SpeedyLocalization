using System;
using UnityEngine;
using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace SpeedyLocalization
{
    [Serializable]
    public class DynamicVar : IVariable
    {
        private float _baseValue;
        public string Name { get; }
        public virtual float BaseValue { get => _baseValue; set => _baseValue = value; }
        public DynamicVar(string name, float baseValue)
        {
            Name = name;
            BaseValue = baseValue;
        }
        public virtual void ModifyValue(float addend) => BaseValue += addend;

        public int IntValue => Mathf.RoundToInt(BaseValue);

        public object GetSourceValue(ISelectorInfo selector) => ReadValue;

        public virtual object ReadValue => BaseValue;
    }
}
