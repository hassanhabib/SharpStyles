// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Text;

namespace SharpStyles.Models
{
    public class MediaQuery
    {
        /// <summary>
        /// Specifies the media type the query targets (e.g. "screen", "print", "all").
        /// </summary>
        public string MediaType { get; set; }

        /// <summary>
        /// When set to true, negates the entire media query (e.g. "not screen").
        /// </summary>
        public bool Not { get; set; }

        /// <summary>
        /// When set to true, restricts the query to devices that understand media queries (e.g. "only screen").
        /// </summary>
        public bool Only { get; set; }

        /// <summary>
        /// Sets the minimum width condition for the media query (e.g. "(min-width: 768px)").
        /// </summary>
        public int? MinWidth { get; set; }

        /// <summary>
        /// Sets the maximum width condition for the media query (e.g. "(max-width: 1024px)").
        /// </summary>
        public int? MaxWidth { get; set; }

        /// <summary>
        /// Adds a custom media feature condition (e.g. "(orientation: portrait)", "(prefers-color-scheme: dark)").
        /// </summary>
        public string CustomFeature { get; set; }

        /// <summary>
        /// Specify the styles.
        /// </summary>
        public SharpStyle Styles { get; set; }

        public string ToCss()
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.Append("@media ");

            // Build media type and modifiers
            if (Not)
                sb.Append("not ");

            if (Only)
                sb.Append("only ");

            if (!string.IsNullOrWhiteSpace(MediaType))
                sb.Append(MediaType + " ");

            var conditions = new List<string>();

            if (MinWidth.HasValue)
                conditions.Add($"(min-width: {MinWidth}px)");

            if (MaxWidth.HasValue)
                conditions.Add($"(max-width: {MaxWidth}px)");

            if (!string.IsNullOrWhiteSpace(CustomFeature))
                conditions.Add(CustomFeature);

            if (conditions.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(MediaType) || Not || Only)
                    sb.Append("and ");

                sb.Append(string.Join(" and ", conditions));
            }

            sb.AppendLine(" {");
            sb.AppendLine(Styles?.ToCss() ?? string.Empty);
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
