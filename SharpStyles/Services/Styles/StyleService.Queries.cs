// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Text;
using SharpStyles.Models.Queries;

namespace SharpStyles.Services.Styles
{
    internal partial class StyleService : IStyleService
    {
        public string ToQueryCss(MediaQuery mediaQuery)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.Append("@media ");

            if (mediaQuery.Not)
                stringBuilder.Append("not ");

            if (mediaQuery.Only)
                stringBuilder.Append("only ");

            if (string.IsNullOrWhiteSpace(mediaQuery.MediaType) is false)
                stringBuilder.Append(mediaQuery.MediaType + " ");

            var conditions = new List<string>();

            if (mediaQuery.MinWidth.HasValue)
                conditions.Add($"(min-width: {mediaQuery.MinWidth}px)");

            if (mediaQuery.MaxWidth.HasValue)
                conditions.Add($"(max-width: {mediaQuery.MaxWidth}px)");

            if (string.IsNullOrWhiteSpace(mediaQuery.CustomFeature) is false)
                conditions.Add($"({mediaQuery.CustomFeature.Trim('(').Trim(')')})");

            if (conditions.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(mediaQuery.MediaType) || mediaQuery.Not || mediaQuery.Only)
                    stringBuilder.Append("and ");

                stringBuilder.Append(string.Join(" and ", conditions));
            }

            stringBuilder.AppendLine(" {");
            stringBuilder.AppendLine(ToStyleCss(mediaQuery.Styles) ?? string.Empty);
            stringBuilder.AppendLine("}");

            return stringBuilder.ToString();
        }
    }
}
