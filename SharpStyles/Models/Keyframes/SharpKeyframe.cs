// ---------------------------------------------------------------
// Copyright (c) Hassan Habib.
// Licensed under the TSSL License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;

namespace SharpStyles.Models.Keyframes
{
    public class SharpKeyframe
    {
        /// <summary>
        /// Keyfrane selector. e.g., "from", "50%", "to"
        /// </summary>
        public string Selector { get; set; }

        /// <summary>
        /// Keyframe Properties. e.g., "opacity", "transform"
        /// </summary>
        public List<SharpKeyframeProperty> Properties { get; set; }
    }

}
