using System;
using System.Collections.Generic;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace SpeedyLocalization
{
    public class DynamicVarSet
    {
        private readonly Dictionary<string, DynamicVar> _vars = new Dictionary<string, DynamicVar>();
        public IEnumerable<string> Keys => _vars.Keys;
        public IEnumerable<DynamicVar> Values => _vars.Values;
        public DynamicVar this[string key] => _vars[key];
        public int Count => _vars.Count;
        public bool ContainsKey(string key) => _vars.ContainsKey(key);
        public bool TryGetValue(string key, out DynamicVar value) => _vars.TryGetValue(key, out value);

        public DynamicVarSet(IEnumerable<DynamicVar> vars)
        {
            foreach (var var in vars)
            {
                if (_vars.ContainsKey(var.Name))
                {
                    throw new ArgumentException($"DynamicVarSet contains duplicate key '{var.Name}'.");
                }

                _vars[var.Name] = var;
            }
        }
    }
}
