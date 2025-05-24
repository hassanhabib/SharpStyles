// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using SharpStyles.Models;

namespace SharpStyles.Services.Styles
{
    internal interface IStyleService
    {
        string ToCss(SharpStyle sharpStyle);
    }
}
