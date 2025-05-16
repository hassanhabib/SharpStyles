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

        [Fact]
        public void ShouldSerializeMultipleFramePoints()
        {
            // given
            var keyframes = new SharpKeyframes
            {
                Name = "pulse",

                Keyframes = new List<SharpKeyframe>
                {
                    new SharpKeyframe()
                    {
                        Selector = "0%",

                        Properties = new()
                        {
                            new SharpKeyframeProperty()
                            {
                                Name = "transform",
                                Value = "scale(1)"
                            },

                            new SharpKeyframeProperty()
                            {
                                Name = "opacity",
                                Value = "1"
                            }
                        }
                    },

                    new SharpKeyframe()
                    {
                        Selector = "50%",

                        Properties = new()
                        {
                            new SharpKeyframeProperty()
                            {
                                Name = "transform",
                                Value = "scale(1.1)"
                            },

                            new SharpKeyframeProperty()
                            {
                                Name = "opacity",
                                Value = "0.7"
                            }
                        }
                    },

                    new SharpKeyframe()
                    {
                        Selector = "100%",

                        Properties = new()
                        {
                            new SharpKeyframeProperty()
                            {
                                Name = "transform",
                                Value = "scale(1)"
                            },

                            new SharpKeyframeProperty()
                            {
                                Name = "opacity",
                                Value = "1"
                            }
                        }
                    }
                }
            };

            string expectedCss = @"@keyframes pulse {
  0% {
    transform: scale(1);
    opacity: 1;
  }
  50% {
    transform: scale(1.1);
    opacity: 0.7;
  }
  100% {
    transform: scale(1);
    opacity: 1;
  }
}
";

            // when
            string actualCss = keyframes.ToCss();

            // then
            actualCss.Should().BeEquivalentTo(expectedCss);
        }

        [Fact]
        public void ShouldReturnEmptyCssWhenNameIsNull()
        {
            // given
            var keyframes = new SharpKeyframes
            {
                Name = null,

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
                    }
                }
            };

            // when
            string css = keyframes.ToCss();

            // then
            css.Should().BeEmpty();
        }

        [Fact]
        public void ShouldReturnEmptyCssWhenKeyframesIsNull()
        {
            // given
            var keyframes = new SharpKeyframes
            {
                Name = "fadeIn",
                Keyframes = null
            };

            // when
            string css = keyframes.ToCss();

            // then
            css.Should().BeEmpty();
        }

        [Fact]
        public void ShouldReturnEmptyCssWhenKeyframesListIsEmpty()
        {
            // given
            var keyframes = new SharpKeyframes
            {
                Name = "fadeIn",
                Keyframes = new List<SharpKeyframe>()
            };

            // when
            string css = keyframes.ToCss();

            // then
            css.Should().BeEmpty();
        }
    }
}
