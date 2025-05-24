// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using SharpStyles.Models;
using SharpStyles.Models.Attributes;
using SharpStyles.Models.Keyframes;
using SharpStyles.Models.Queries;

namespace SharpStyles.Services.Styles
{
    internal partial class StyleService : IStyleService
    {
        private static readonly Regex PascalToKebabRegex =
            new Regex("([a-z,0-9](?=[A-Z])|[A-Z](?=[A-Z][a-z]))");

        private static void AppendStyleBlock(
            SharpStyle sharpStyle,
            PropertyInfo property,
            StringBuilder stringBuilder)
        {
            string prefix = null;
            string selectorCss = null;

            foreach (var attribute in property.CustomAttributes)
            {
                if (attribute.NamedArguments.Any())
                {
                    selectorCss = attribute.NamedArguments[0].TypedValue.Value.ToString();
                }
                else
                {
                    prefix += attribute.AttributeType.Name switch
                    {
                        nameof(CssId) => "#",
                        nameof(CssClass) => ".",
                        nameof(CssDeep) => "::deep ",
                        _ => ""
                    };
                }
            }

            selectorCss ??= PascalToKebabRegex.Replace(property.Name, "$1-").ToLower();
            stringBuilder.AppendLine();
            stringBuilder.Append($"{prefix}{selectorCss} {{");
            stringBuilder.AppendLine();

            AppendInnerStyles(sharpStyle, property, stringBuilder);

            stringBuilder.Append("}");
            stringBuilder.AppendLine();
        }

        private static void AppendInnerStyles(
            SharpStyle sharpStyle,
            PropertyInfo property,
            StringBuilder stringBuilder)
        {
            var styleValue = property.GetValue(sharpStyle);
            if (styleValue == null) return;

            foreach (PropertyInfo innerProperty in property.PropertyType.GetProperties())
            {
                var value = innerProperty.GetValue(styleValue);
                if (value != null)
                {
                    string raw = $"\t{innerProperty.Name}: {value};";
                    stringBuilder.Append(PascalToKebabRegex.Replace(raw, "$1-").ToLower());
                    stringBuilder.AppendLine();
                }
            }
        }

        private void AppendMediaQueryBlock(
            SharpStyle sharpStyle,
            PropertyInfo property,
            StringBuilder stringBuilder)
        {
            IEnumerable<MediaQuery> mediaQueries =
                property.GetValue(sharpStyle)
                    as IEnumerable<MediaQuery>;

            if (mediaQueries == null)
                return;

            foreach (var mediaQuery in mediaQueries)
            {
                stringBuilder.AppendLine(ToQueryCss(mediaQuery));
            }
        }

        private void AppendKeyframesBlock(
            SharpStyle sharpStyle,
            PropertyInfo property,
            StringBuilder stringBuilder)
        {
            IEnumerable<SharpKeyframes> sharpKeyframes =
                property.GetValue(sharpStyle)
                    as IEnumerable<SharpKeyframes>;

            if (sharpKeyframes == null)
                return;

            foreach (var keyframes in sharpKeyframes)
            {
                stringBuilder.AppendLine(ToKeyframesCss(keyframes));
            }
        }
    }
}
