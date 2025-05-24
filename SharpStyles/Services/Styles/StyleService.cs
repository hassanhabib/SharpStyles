// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Text.RegularExpressions;
using SharpStyles.Models;

namespace SharpStyles.Services.Styles
{
    internal partial class StyleService : IStyleService
    {
        private static readonly Regex PascalToKebabRegex =
            new Regex("([a-z,0-9](?=[A-Z])|[A-Z](?=[A-Z][a-z]))");

        public string ToCss(SharpStyle sharpStyle)
        {
            return string.Empty;
        }
    }
}
