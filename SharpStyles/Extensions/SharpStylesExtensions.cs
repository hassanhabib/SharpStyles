// ---------------------------------------------------------------
// Copyright (c) Hassan Habib.
// Licensed under the TSSL License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using SharpStyles.Models;
using SharpStyles.Models.Keyframes;
using SharpStyles.Models.Queries;
using SharpStyles.Services.Styles;

namespace SharpStyles.Extensions
{
    /// <summary>
    /// Provides extension methods for working with <see cref="SharpStyle"/> instances,
    /// including conversion to CSS style strings.
    /// </summary>
    public static class SharpStylesExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="SharpStyle"/> instance to a CSS style string.
        /// </summary>
        public static string ToStyleCss(this SharpStyle sharpStyle)
        {
            IStyleService styleService = new StyleService();
            return styleService.ToStyleCss(sharpStyle);
        }

        /// <summary>
        /// Converts the specified <see cref="MediaQuery"/> instance to a media query CSS style string.
        /// </summary>
        public static string ToQueryCss(this MediaQuery mediaQuery)
        {
            IStyleService styleService = new StyleService();
            return styleService.ToQueryCss(mediaQuery);
        }

        /// <summary>
        /// Converts the specified <see cref="SharpKeyframes"/> instance to a keyframes CSS style string.
        /// </summary>
        public static string ToKeyframesCss(this SharpKeyframes keyframes)
        {
            IStyleService styleService = new StyleService();
            return styleService.ToKeyframesCss(keyframes);
        }
    }
}
