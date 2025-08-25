// ---------------------------------------------------------------
// Copyright (c) Hassan Habib.
// Licensed under the TSSL License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Text;
using SharpStyles.Models.Keyframes;

namespace SharpStyles.Services.Styles
{
    internal partial class StyleService : IStyleService
    {
        public string ToKeyframesCss(SharpKeyframes sharpKeyframes)
        {
            if (string.IsNullOrEmpty(sharpKeyframes?.Name)
                || sharpKeyframes?.Keyframes is null
                    || sharpKeyframes?.Keyframes.Count is 0)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"@keyframes {sharpKeyframes.Name} {{");

            foreach (var keyframe in sharpKeyframes.Keyframes)
            {
                stringBuilder.AppendLine($"  {keyframe.Selector} {{");
                foreach (var prop in keyframe.Properties)
                {
                    stringBuilder.AppendLine($"    {prop.Name}: {prop.Value};");
                }
                stringBuilder.AppendLine("  }");
            }

            stringBuilder.AppendLine("}");
            return stringBuilder.ToString();
        }
    }
}
