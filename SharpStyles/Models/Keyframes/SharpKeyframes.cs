// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace SharpStyles.Models.Keyframes
{
    public class SharpKeyframes
    {
        public string Name { get; set; }

        public List<SharpKeyframe> Keyframes { get; set; }

        [Obsolete("ToCss is obsolete and only supports legacy nested style serialization." +
           " Use ToKeyframesCss() extension method instead.")]
        public string ToCss()
        {
            if (string.IsNullOrEmpty(Name)
                || Keyframes is null
                    || Keyframes.Count is 0)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"@keyframes {Name} {{");

            foreach (var keyframe in Keyframes)
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
