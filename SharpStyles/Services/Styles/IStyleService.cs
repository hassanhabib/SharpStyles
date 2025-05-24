// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using SharpStyles.Models;
using SharpStyles.Models.Keyframes;
using SharpStyles.Models.Queries;

namespace SharpStyles.Services.Styles
{
    internal interface IStyleService
    {
        string ToStyleCss(SharpStyle sharpStyle);
        string ToQueryCss(MediaQuery mediaQuery);
        string ToKeyframesCss(SharpKeyframes sharpKeyframes);
    }
}
