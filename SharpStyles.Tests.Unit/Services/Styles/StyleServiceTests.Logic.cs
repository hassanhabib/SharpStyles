// ---------------------------------------------------------------
// Copyright (c) Hassan Habib.
// Licensed under the TSSL License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using FluentAssertions;
using SharpStyles.Models;
using SharpStyles.Models.Keyframes;
using SharpStyles.Models.Queries;
using SharpStyles.Services.Styles;
using Xunit;

namespace SharpStyles.Tests.Unit.Services.Styles
{
    public partial class StyleServiceTests
    {
        [Fact]
        public void ShouldSerializeSharpStyleToCssRules()
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
            IStyleService styleService = new StyleService();

            string actualStyle = styleService.ToStyleCss(
                sharpStyle: testStyle);

            // then
            actualStyle.Should().BeEquivalentTo(expectedStyle);
        }

        [Fact]
        public void ShouldSerializeSharpStyleWithMediaQueriesToCssRules()
        {
            // given
            string randomValue = GetRandomString();
            string randomSmallDeviceValue = GetRandomString();

            var smallScreenStyle = new TestStyle
            {
                MyElement = new SharpStyle
                {
                    BackgroundColor = randomSmallDeviceValue
                },

                MyId = new SharpStyle
                {
                    BackgroundColor = randomSmallDeviceValue
                },

                MyClass = new SharpStyle
                {
                    BackgroundColor = randomSmallDeviceValue
                },

                MyDeep = new SharpStyle
                {
                    BackgroundColor = randomSmallDeviceValue
                }
            };

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
                },

                MediaQueries = new List<MediaQuery>
                {
                    new MediaQuery
                    {
                        MaxWidth  = 768,
                        Styles = smallScreenStyle
                    }
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

@media (max-width: 768px) {{


my-element {{
	background-color: {randomSmallDeviceValue};
}}

#my-id {{
	background-color: {randomSmallDeviceValue};
}}

.my-class {{
	background-color: {randomSmallDeviceValue};
}}

::deep my-deep {{
	background-color: {randomSmallDeviceValue};
}}

}}

";

            // when
            IStyleService styleService = new StyleService();

            string actualStyle = styleService.ToStyleCss(
                sharpStyle: testStyle);

            // then
            actualStyle.Should().BeEquivalentTo(expectedStyle);
        }

        [Fact]
        public void ShouldSerializeSharpStyleWithKeyFramesToCssRules()
        {
            // given
            string randomValue = GetRandomString();
            string randomSmallDeviceValue = GetRandomString();

            var keyframes = new SharpKeyframes
            {
                Name = "fadeIn",

                Keyframes = new List<SharpKeyframe>
                {
                    new SharpKeyframe()
                    {
                        Selector = "from",
                        Properties = new List<SharpKeyframeProperty>()
                        {
                            new SharpKeyframeProperty()
                            {
                                Name = "opacity",
                                Value = "0"
                            }
                        }
                    },

                    new SharpKeyframe()
                    {
                        Selector = "to",
                        Properties = new()
                        {
                            new SharpKeyframeProperty()
                            {
                                Name = "opacity",
                                Value = randomValue
                            }
                        }
                    }
                }
            };

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
                },

                Keyframes = new List<SharpKeyframes>
                {
                    keyframes
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

@keyframes fadeIn {{
  from {{
    opacity: 0;
  }}
  to {{
    opacity: {randomValue};
  }}
}}

";

            // when
            IStyleService styleService = new StyleService();

            string actualStyle = styleService.ToStyleCss(
                sharpStyle: testStyle);

            // then
            actualStyle.Should().BeEquivalentTo(expectedStyle);
        }

        [Theory]
        [InlineData("#ff0000")]
        [InlineData("#00FF00")]
        [InlineData("#0000fF")]
        [InlineData("#123456")]
        public void ShouldSerializeSharpStyleToCssRulesWithUppercasedAndLowercasedHexColors(string hexColor)
        {
            // given
            var testStyle = new TestStyle
            {
                MyElement = new SharpStyle
                {
                    BackgroundColor = hexColor
                },

                MyId = new SharpStyle
                {
                    BackgroundColor = hexColor
                },

                MyClass = new SharpStyle
                {
                    BackgroundColor = hexColor
                },

                MyDeep = new SharpStyle
                {
                    BackgroundColor = hexColor
                }
            };

            string expectedStyle = @$"

my-element {{
	background-color: {hexColor};
}}

#my-id {{
	background-color: {hexColor};
}}

.my-class {{
	background-color: {hexColor};
}}

::deep my-deep {{
	background-color: {hexColor};
}}
";

            // when
            IStyleService styleService = new StyleService();

            string actualStyle = styleService.ToStyleCss(
                sharpStyle: testStyle);

            // then
            actualStyle.Should().BeEquivalentTo(expectedStyle);
        }
    }
}
