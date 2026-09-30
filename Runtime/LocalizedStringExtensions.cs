using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Localization;
using System.Collections.Generic;

namespace SpeedyLocalization
{
    public static class LocalizedStringExtensions
    {
        public static LocalizedString WithVars(this LocalizedString locString, IEnumerable<DynamicVar> vars)
        {
            if (vars == null) return locString;
            foreach (var var in vars)
            {
                locString.Add(var.Name, var);
            }
            return locString;
        }
        public static LocalizedString WithVars(this LocalizedString locString, DynamicVarSet vars)
        {
            if (vars == null) return locString;

            return locString.WithVars(vars.Values);
        }
        public static string ToSnakeCase(this string input)
        {
            return string.Concat(input.Select((x, i) => (i > 0 && char.IsUpper(x) && (char.IsLower(input[i - 1]) || char.IsLower(input[i + 1])))
                ? "_" + x.ToString() : x.ToString())).ToLower();
        }
        public static float PercentLess(this float value) => Math.Abs(1f - value) * 100f;
        public static float Percent(this float value) => value * 100f;
        public static float PercentMore(this float value) => Math.Abs(value - 1f) * 100f;
        public static float PercentChange(this float value) => (value - 1f) * 100f;
    }
}
