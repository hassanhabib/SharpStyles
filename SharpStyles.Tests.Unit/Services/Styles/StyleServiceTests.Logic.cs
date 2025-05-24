// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using FluentAssertions;
using SharpStyles.Models;
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

            string actualStyle = styleService.ToCss(
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
                    BackgroundColor = randomValue
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

@media (min-width: 768px) {{

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

            string actualStyle = styleService.ToCss(
                sharpStyle: testStyle);

            // then
            actualStyle.Should().BeEquivalentTo(expectedStyle);
        }
    }
}
