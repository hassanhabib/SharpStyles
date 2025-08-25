// ---------------------------------------------------------------
// Copyright (c) Hassan Habib.
// Licensed under the TSSL License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using SharpStyles.Models;
using SharpStyles.Models.Attributes;
using Tynamix.ObjectFiller;

namespace SharpStyles.Tests.Unit.Services.Styles
{
    public partial class StyleServiceTests
    {
        internal class TestStyle : SharpStyle
        {
            [CssElement]
            public SharpStyle MyElement { get; set; }

            [CssId]
            public SharpStyle MyId { get; set; }

            [CssClass]
            public SharpStyle MyClass { get; set; }

            [CssDeep]
            public SharpStyle MyDeep { get; set; }
        }

        private static string GetRandomString() =>
            new MnemonicString().GetValue();
    }
}
