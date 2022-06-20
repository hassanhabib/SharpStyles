// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using FluentAssertions;
using SharpStyles.Models;
using SharpStyles.Models.Attributes;
using Tynamix.ObjectFiller;
using Xunit;

namespace SharpStyles.Tests.Unit.Models
{
    public class SharpStyleTests
    {
        [Fact]
        public void ShouldSerializeCssRules()
        {
            // given
            string randomValue = GetRandomString();

            var testStyle = new TestStyle
            {
                MyElement = new SharpStyle
                {
                    BackgroundColor = randomValue
                },

                MyId = new SharpStyle
                {
                    BackgroundColor = randomValue
                },

                MyClass = new SharpStyle
                {
                    BackgroundColor = randomValue
                },

                MyDeep = new SharpStyle
                {
                    BackgroundColor = randomValue
                }
            };

            string expectedStyle = @$"

my-element {{
	background-color: {randomValue};
}}

#my-id {{
	background-color: {randomValue};
}}

.my-class {{
	background-color: {randomValue};
}}

::deep my-deep {{
	background-color: {randomValue};
}}
";

            // when
            string actualStyle = testStyle.ToCss();

            // then
            actualStyle.Should().BeEquivalentTo(expectedStyle);
        }

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
