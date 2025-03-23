﻿// ---------------------------------------------------------------
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
        public void ShouldSerializeMediaCssRules()
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

            var mediaStyle = new MediaSharpStyle
            {
                SizeCondition = "max-width: 600px",
                Styles = testStyle
            };

            string expectedStyle = @$"
@media(max-width: 600px){{

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
            string actualStyle = mediaStyle.ToCss();

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
