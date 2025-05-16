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
    public partial class SharpStyleTests
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

        [Fact]
        public void ShouldSerializeWithCustomSelectors()
        {
            // given
            string randomValue = GetRandomString();

            var testStyle = new TestStyleWithCustomSelectors
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

my-custom-element {{
	background-color: {randomValue};
}}

#my-custom-id {{
	background-color: {randomValue};
}}

.my-custom-class {{
	background-color: {randomValue};
}}

::my-custom-deep {{
	background-color: {randomValue};
}}
";

            // when
            string actualStyle = testStyle.ToCss();

            // then
            actualStyle.Should().BeEquivalentTo(expectedStyle);
        }

        [Fact]
        public void ShouldSerializeMediaQueryWithStyles()
        {
            // given
            string randomValue = GetRandomString();

            var mobileStyle = new TestStyle
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

            var mediaQuery = new MediaQuery
            {
                Only = true,
                MediaType = "screen",
                MaxWidth = 768,
                Styles = mobileStyle
            };

            string expectedCss = @$"
@media only screen and (max-width: 768px) {{


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

}}
";

            // when
            string actualCss = mediaQuery.ToCss();

            // then
            actualCss.Should().BeEquivalentTo(expectedCss);
        }

        [Fact]
        public void ShouldSerializeMediaQueryWithCustomCondition()
        {
            // given
            string randomValue = GetRandomString();

            var mobileStyle = new TestStyle
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

            var mediaQuery = new MediaQuery
            {
                Only = true,
                MediaType = "screen",
                MaxWidth = 768,
                Styles = mobileStyle,
                CustomFeature = "orientation: portrait"
            };

            string expectedCss = @$"
@media only screen and (max-width: 768px) and (orientation: portrait) {{


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

}}
";

            // when
            string actualCss = mediaQuery.ToCss();

            // then
            actualCss.Should().BeEquivalentTo(expectedCss);
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

        internal class TestStyleWithCustomSelectors : SharpStyle
        {
            [CssElement(Selector = "my-custom-element")]
            public SharpStyle MyElement { get; set; }

            [CssId(Selector = "#my-custom-id")]
            public SharpStyle MyId { get; set; }

            [CssClass(Selector = ".my-custom-class")]
            public SharpStyle MyClass { get; set; }

            [CssDeep(Selector = "::my-custom-deep")]
            public SharpStyle MyDeep { get; set; }
        }

        private static string GetRandomString() =>
            new MnemonicString().GetValue();
    }
}
