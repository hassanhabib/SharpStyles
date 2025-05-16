// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using FluentAssertions;
using SharpStyles.Models.Keyframes;
using Xunit;

namespace SharpStyles.Tests.Unit.Models
{
    public partial class SharpStyleTests
    {
        [Fact]
        public void ShouldSerializeKeyframesCorrectly()
        {
            // given
            string randomValue = GetRandomString();

            var keyframes = new SharpKeyframes
            {
                Name = "fadeIn",
                Keyframes = new List<SharpKeyframe>
        {
            new()
            {
                Selector = "from",
                Properties = new()
                {
                    new() { Name = "opacity", Value = "0" }
                }
            },
            new()
            {
                Selector = "to",
                Properties = new()
                {
                    new() { Name = "opacity", Value = randomValue }
                }
            }
        }
            };

            string expectedCss = @$"@keyframes fadeIn {{
  from {{
    opacity: 0;
  }}
  to {{
    opacity: {randomValue};
  }}
}}
";

            // when
            string actualCss = keyframes.ToCss();

            // then
            actualCss.Should().BeEquivalentTo(expectedCss);
        }

    }
}
