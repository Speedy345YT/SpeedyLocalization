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

            return locString.WithVars(vars.Values)
        }
        public static string ToSnakeCase(this string input)
        {
            return string.Concat(input.Select((x, i) => (i > 0 && char.IsUpper(x) && (char.IsLower(input[i - 1]) || char.IsLower(input[i + 1])))
                ? "_" + x.ToString() : x.ToString())).ToLower();
        }
        public static LocalizedString LocalizedName(this Enum type) => new LocalizedString("Items", $"item.{type.GetType().Name.ToSnakeCase()}.{type.ToString().ToSnakeCase()}.title"); //Turns DamageType.Generic into item.damage_type.generic.title
        public static LocalizedString LocalizedDescription(this Enum type) => new LocalizedString("Items", $"item.{type.GetType().Name.ToSnakeCase()}.{type.ToString().ToSnakeCase()}.description");
        public static LocalizedString LocalizedSmartDescription(this Enum type, DynamicVarSet set) => new LocalizedString("Items", $"item.{type.GetType().Name.ToSnakeCase()}.{type.ToString().ToSnakeCase()}.smartDescription").WithVars(set);
        public static float PercentLess(this float value) => Math.Abs(1f - value) * 100f;
        public static float Percent(this float value) => value * 100f;
        public static float PercentMore(this float value) => Math.Abs(value - 1f) * 100f;
        public static float PercentChange(this float value) => (value - 1f) * 100f;
    }
}
