// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;

namespace SharpStyles.Models.Keyframes
{
    public class SharpKeyframes
    {
        public string Name { get; set; }

        public List<SharpKeyframe> Keyframes { get; set; }

        public string ToCss()
        {
            return string.Empty;
        }
    }
}
