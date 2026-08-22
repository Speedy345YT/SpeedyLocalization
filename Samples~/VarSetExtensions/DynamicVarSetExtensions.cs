using UnityEngine;

namespace SpeedyLocalization
{
    public static class DynamicVarSetExtensions
    {
        //You can edit this as you so please to add shorthands to whatever dynamic vars you use commonly, examples could be a DamageVar called Damage, etc.
        public static DynamicVar Dynamic(this DynamicVarSet varSet) => varSet[nameof(Dynamic)];
    }
}
