using System;
using UnityEngine.Localization.SmartFormat.Core.Extensions;

namespace SpeedyLocalization
{
    [Serializable]
    public class PercentFormatter : FormatterBase
    {
        public PercentFormatter() : base()
        {
            Names = DefaultNames;
        }
        public override string[] DefaultNames => new[]
        {
            "percentLess", //0.75x => 25%
            "percent", //0.75x => 75%
            "percentMore", //1.5x => 50%
            "percentChange", //1.5x => 50%, 0.75x turns into -25%
        };
        public override bool TryEvaluateFormat(IFormattingInfo formattingInfo)
        {
            var current = formattingInfo.CurrentValue;
            var formatterName = formattingInfo.Placeholder?.FormatterName;

            if (current == null)
                return false;

            float value = Convert.ToSingle(current);

            switch (formatterName)
            {
                case "percentLess":
                    formattingInfo.Write($"{value.PercentLess():0.##}%");
                    return true;

                case "percent":
                    formattingInfo.Write($"{value.Percent():0.##}%");
                    return true;

                case "percentMore":
                    formattingInfo.Write($"{value.PercentMore():0.##}%");
                    return true;

                case "percentChange":
                    formattingInfo.Write($"{value.PercentChange():+0.##;-0.##;0}%");
                    return true;

                default:
                    return false;
            }
        }
    }
}