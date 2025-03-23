// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Text;

namespace SharpStyles.Models
{
    public class MediaSharpStyle
    {
        /// <summary>
        /// Specify the size condition. (e.g. max-width: 600px)
        /// </summary>
        public string SizeCondition { get; set; }

        /// <summary>
        /// Specify the styles.
        /// </summary>
        public SharpStyle Styles { get; set; }

        public string ToCss()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();

            stringBuilder.AppendLine($"@media({SizeCondition}){{");
            stringBuilder.AppendLine(Styles?.ToCss());
            stringBuilder.AppendLine("}");

            return stringBuilder.ToString();
        }
    }
}
