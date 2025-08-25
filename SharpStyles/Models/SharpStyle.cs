// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using SharpStyles.Models.Attributes;
using SharpStyles.Models.Keyframes;
using SharpStyles.Models.Queries;

namespace SharpStyles.Models
{
    public class SharpStyle
    {
        /// <summary>
        /// Specifies the alignment of flexible container's items within the flex container.
        /// </summary>
        public string AlignContent { get; set; }

        /// <summary>
        /// Specifies the default alignment for items within the flex container.
        /// </summary>
        public string AlignItems { get; set; }

        /// <summary>
        /// Specifies the alignment for selected items within the flex container.
        /// </summary>
        public string AlignSelf { get; set; }

        /// <summary>
        /// Specifies the keyframe-based animations.
        /// </summary>
        public string Animation { get; set; }

        /// <summary>
        /// Specifies when the animation will start.
        /// </summary>
        public string AnimationDelay { get; set; }

        /// <summary>
        /// Specifies whether the animation should play in reverse on alternate cycles or not.
        /// </summary>
        public string AnimationDirection { get; set; }

        /// <summary>
        /// Specifies the number of seconds or milliseconds an animation should take to complete one cycle.
        /// </summary>
        public string AnimationDuration { get; set; }

        /// <summary>
        /// Specifies how a CSS animation should apply styles to its target before and after it is executing.
        /// </summary>
        public string AnimationFillMode { get; set; }

        /// <summary>
        /// Specifies the number of times an animation cycle should be played before stopping.
        /// </summary>
        public string AnimationIterationCount { get; set; }

        /// <summary>
        /// Specifies the name of @keyframes defined animations that should be applied to the selected element.
        /// </summary>
        public string AnimationName { get; set; }

        /// <summary>
        /// Specifies whether the animation is running or paused.
        /// </summary>
        public string AnimationPlayState { get; set; }

        /// <summary>
        /// Specifies how a CSS animation should progress over the duration of each cycle.
        /// </summary>
        public string AnimationTimingFunction { get; set; }

        /// <summary>
        /// Specifies whether or not the "back" side of a transformed element is visible when facing the user.
        /// </summary>
        public string BackfaceVisibility { get; set; }

        /// <summary>
        /// Defines a variety of background properties within one declaration.
        /// </summary>
        public string Background { get; set; }

        /// <summary>
        /// Specify whether the background image is fixed in the viewport or scrolls.
        /// </summary>
        public string BackgroundAttachment { get; set; }

        /// <summary>
        /// Specifies the painting area of the background.
        /// </summary>
        public string BackgroundClip { get; set; }

        /// <summary>
        /// Defines an element's background color.
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Defines an element's background image.
        /// </summary>
        public string BackgroundImage { get; set; }

        /// <summary>
        /// Specifies the positioning area of the background images.
        /// </summary>
        public string BackgroundOrigin { get; set; }

        /// <summary>
        /// Defines the origin of a background image.
        /// </summary>
        public string BackgroundPosition { get; set; }

        /// <summary>
        /// Specify whether/how the background image is tiled.
        /// </summary>
        public string BackgroundRepeat { get; set; }

        /// <summary>
        /// Specifies the size of the background images.
        /// </summary>
        public string BackgroundSize { get; set; }

        /// <summary>
        /// Sets the width, style, and color for all four sides of an element's border.
        /// </summary>
        public string Border { get; set; }

        /// <summary>
        /// Sets the width, style, and color of the bottom border of an element.
        /// </summary>
        public string BorderBottom { get; set; }

        /// <summary>
        /// Sets the color of the bottom border of an element.
        /// </summary>
        public string BorderBottomColor { get; set; }

        /// <summary>
        /// Defines the shape of the bottom-left border corner of an element.
        /// </summary>
        public string BorderBottomLeftRadius { get; set; }

        /// <summary>
        /// Defines the shape of the bottom-right border corner of an element.
        /// </summary>
        public string BorderBottomRightRadius { get; set; }

        /// <summary>
        /// Sets the style of the bottom border of an element.
        /// </summary>
        public string BorderBottomStyle { get; set; }

        /// <summary>
        /// Sets the width of the bottom border of an element.
        /// </summary>
        public string BorderBottomWidth { get; set; }

        /// <summary>
        /// Specifies whether table cell borders are connected or separated.
        /// </summary>
        public string BorderCollapse { get; set; }

        /// <summary>
        /// Sets the color of the border on all the four sides of an element.
        /// </summary>
        public string BorderColor { get; set; }

        /// <summary>
        /// Specifies how an image is to be used in place of the border styles.
        /// </summary>
        public string BorderImage { get; set; }

        /// <summary>
        /// Specifies the amount by which the border image area extends beyond the border box.
        /// </summary>
        public string BorderImageOutset { get; set; }

        /// <summary>
        /// Specifies whether the image-border should be repeated, rounded or stretched.
        /// </summary>
        public string BorderImageRepeat { get; set; }

        /// <summary>
        /// Specifies the inward offsets of the image-border.
        /// </summary>
        public string BorderImageSlice { get; set; }

        /// <summary>
        /// Specifies the location of the image to be used as a border.
        /// </summary>
        public string BorderImageSource { get; set; }

        /// <summary>
        /// Specifies the width of the image-border.
        /// </summary>
        public string BorderImageWidth { get; set; }

        /// <summary>
        /// Sets the width, style, and color of the left border of an element.
        /// </summary>
        public string BorderLeft { get; set; }

        /// <summary>
        /// Sets the color of the left border of an element.
        /// </summary>
        public string BorderLeftColor { get; set; }

        /// <summary>
        /// Sets the style of the left border of an element.
        /// </summary>
        public string BorderLeftStyle { get; set; }

        /// <summary>
        /// Sets the width of the left border of an element.
        /// </summary>
        public string BorderLeftWidth { get; set; }

        /// <summary>
        /// Defines the shape of the border corners of an element.
        /// </summary>
        public string BorderRadius { get; set; }

        /// <summary>
        /// Sets the width, style, and color of the right border of an element.
        /// </summary>
        public string BorderRight { get; set; }

        /// <summary>
        /// Sets the color of the right border of an element.
        /// </summary>
        public string BorderRightColor { get; set; }

        /// <summary>
        /// Sets the style of the right border of an element.
        /// </summary>
        public string BorderRightStyle { get; set; }

        /// <summary>
        /// Sets the width of the right border of an element.
        /// </summary>
        public string BorderRightWidth { get; set; }

        /// <summary>
        /// Sets the spacing between the borders of adjacent table cells.
        /// </summary>
        public string BorderSpacing { get; set; }

        /// <summary>
        /// Sets the style of the border on all the four sides of an element.
        /// </summary>
        public string BorderStyle { get; set; }

        /// <summary>
        /// Sets the width, style, and color of the top border of an element.
        /// </summary>
        public string BorderTop { get; set; }

        /// <summary>
        /// Sets the color of the top border of an element.
        /// </summary>
        public string BorderTopColor { get; set; }

        /// <summary>
        /// Defines the shape of the top-left border corner of an element.
        /// </summary>
        public string BorderTopLeftRadius { get; set; }

        /// <summary>
        /// Defines the shape of the top-right border corner of an element.
        /// </summary>
        public string BorderTopRightRadius { get; set; }

        /// <summary>
        /// Sets the style of the top border of an element.
        /// </summary>
        public string BorderTopStyle { get; set; }

        /// <summary>
        /// Sets the width of the top border of an element.
        /// </summary>
        public string BorderTopWidth { get; set; }

        /// <summary>
        /// Sets the width of the border on all the four sides of an element.
        /// </summary>
        public string BorderWidth { get; set; }

        /// <summary>
        /// Specify the location of the bottom edge of the positioned element.
        /// </summary>
        public string Bottom { get; set; }

        /// <summary>
        /// Applies one or more drop-shadows to the element's box.
        /// </summary>
        public string BoxShadow { get; set; }

        /// <summary>
        /// Alter the default CSS box model.
        /// </summary>
        public string BoxSizing { get; set; }

        /// <summary>
        /// Specify the position of table's caption.
        /// </summary>
        public string CaptionSide { get; set; }

        /// <summary>
        /// Specifies the placement of an element in relation to floating elements.
        /// </summary>
        public string Clear { get; set; }

        /// <summary>
        /// Defines the clipping region.
        /// </summary>
        public string Clip { get; set; }

        /// <summary>
        /// Specify the color of the text of an element.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Specifies the number of columns in a multi-column element.
        /// </summary>
        public string ColumnCount { get; set; }

        /// <summary>
        /// Specifies how columns will be filled.
        /// </summary>
        public string ColumnFill { get; set; }

        /// <summary>
        /// Specifies the gap between the columns in a multi-column element.
        /// </summary>
        public string ColumnGap { get; set; }

        /// <summary>
        /// Specifies a straight line, or "rule", to be drawn between each column in a multi-column element.
        /// </summary>
        public string ColumnRule { get; set; }

        /// <summary>
        /// Specifies the color of the rules drawn between columns in a multi-column layout.
        /// </summary>
        public string ColumnRuleColor { get; set; }

        /// <summary>
        /// Specifies the style of the rule drawn between the columns in a multi-column layout.
        /// </summary>
        public string ColumnRuleStyle { get; set; }

        /// <summary>
        /// Specifies the width of the rule drawn between the columns in a multi-column layout.
        /// </summary>
        public string ColumnRuleWidth { get; set; }

        /// <summary>
        /// Specifies how many columns an element spans across in a multi-column layout.
        /// </summary>
        public string ColumnSpan { get; set; }

        /// <summary>
        /// Specifies the optimal width of the columns in a multi-column element.
        /// </summary>
        public string ColumnWidth { get; set; }

        /// <summary>
        /// A shorthand property for setting column-width and column-count properties.
        /// </summary>
        public string Columns { get; set; }

        /// <summary>
        /// Inserts generated content.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Increments one or more counter values.
        /// </summary>
        public string CounterIncrement { get; set; }

        /// <summary>
        /// Creates or resets one or more counters.
        /// </summary>
        public string CounterReset { get; set; }

        /// <summary>
        /// Specify the type of cursor.
        /// </summary>
        public string Cursor { get; set; }

        /// <summary>
        /// Define the text direction/writing direction.
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// Specifies how an element is displayed onscreen.
        /// </summary>
        public string Display { get; set; }

        /// <summary>
        /// Show or hide borders and backgrounds of empty table cells.
        /// </summary>
        public string EmptyCells { get; set; }

        /// <summary>
        /// Specifies the components of a flexible length.
        /// </summary>
        public string Flex { get; set; }

        /// <summary>
        /// Specifies the initial main size of the flex item.
        /// </summary>
        public string FlexBasis { get; set; }

        /// <summary>
        /// Specifies the direction of the flexible items.
        /// </summary>
        public string FlexDirection { get; set; }

        /// <summary>
        /// A shorthand property for the flex-direction and the flex-wrap properties.
        /// </summary>
        public string FlexFlow { get; set; }

        /// <summary>
        /// Specifies how the flex item will grow relative to the other items inside the flex container.
        /// </summary>
        public string FlexGrow { get; set; }

        /// <summary>
        /// Specifies how the flex item will shrink relative to the other items inside the flex container.
        /// </summary>
        public string FlexShrink { get; set; }

        /// <summary>
        /// Specifies whether the flexible items should wrap or not.
        /// </summary>
        public string FlexWrap { get; set; }

        /// <summary>
        /// Specifies whether or not a box should float.
        /// </summary>
        public string Float { get; set; }

        /// <summary>
        /// Defines a variety of font properties within one declaration.
        /// </summary>
        public string Font { get; set; }

        /// <summary>
        /// Defines a list of fonts for element.
        /// </summary>
        public string FontFamily { get; set; }

        /// <summary>
        /// Defines the font size for the text.
        /// </summary>
        public string FontSize { get; set; }

        /// <summary>
        /// Preserves the readability of text when font fallback occurs.
        /// </summary>
        public string FontSizeAdjust { get; set; }

        /// <summary>
        /// Selects a normal, condensed, or expanded face from a font.
        /// </summary>
        public string FontStretch { get; set; }

        /// <summary>
        /// Defines the font style for the text.
        /// </summary>
        public string FontStyle { get; set; }

        /// <summary>
        /// Specify the font variant.
        /// </summary>
        public string FontVariant { get; set; }

        /// <summary>
        /// Specify the font weight of the text.
        /// </summary>
        public string FontWeight { get; set; }

        /// <summary>
        /// Specifies the gap between rows and columns in a flex or grid container.
        /// </summary>
        public string Gap { get; set; }

        /// <summary>
        /// Specify the height of an element.
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// Specifies how flex items are aligned along the main axis of the flex container after any flexible lengths and auto margins have been resolved.
        /// </summary>
        public string JustifyContent { get; set; }

        /// <summary>
        /// Specify the location of the left edge of the positioned element.
        /// </summary>
        public string Left { get; set; }

        /// <summary>
        /// Sets the extra spacing between letters.
        /// </summary>
        public string LetterSpacing { get; set; }

        /// <summary>
        /// Sets the height between lines of text.
        /// </summary>
        public string LineHeight { get; set; }

        /// <summary>
        /// Defines the display style for a list and list elements.
        /// </summary>
        public string ListStyle { get; set; }

        /// <summary>
        /// Specifies the image to be used as a list-item marker.
        /// </summary>
        public string ListStyleImage { get; set; }

        /// <summary>
        /// Specifies the position of the list-item marker.
        /// </summary>
        public string ListStylePosition { get; set; }

        /// <summary>
        /// Specifies the marker style for a list-item.
        /// </summary>
        public string ListStyleType { get; set; }

        /// <summary>
        /// Sets the margin on all four sides of the element.
        /// </summary>
        public string Margin { get; set; }

        /// <summary>
        /// Sets the bottom margin of the element.
        /// </summary>
        public string MarginBottom { get; set; }

        /// <summary>
        /// Sets the left margin of the element.
        /// </summary>
        public string MarginLeft { get; set; }

        /// <summary>
        /// Sets the right margin of the element.
        /// </summary>
        public string MarginRight { get; set; }

        /// <summary>
        /// Sets the top margin of the element.
        /// </summary>
        public string MarginTop { get; set; }

        /// <summary>
        /// Specify the maximum height of an element.
        /// </summary>
        public string MaxHeight { get; set; }

        /// <summary>
        /// Specify the maximum width of an element.
        /// </summary>
        public string MaxWidth { get; set; }

        /// <summary>
        /// Specify the minimum height of an element.
        /// </summary>
        public string MinHeight { get; set; }

        /// <summary>
        /// Specify the minimum width of an element.
        /// </summary>
        public string MinWidth { get; set; }

        /// <summary>
        /// Specifies how the content of a replaced element (e.g., image or video) should be resized to fit its container.
        /// </summary>
        public string ObjectFit { get; set; }

        /// <summary>
        /// Specifies the transparency of an element.
        /// </summary>
        public string Opacity { get; set; }

        /// <summary>
        /// Specifies the order in which a flex items are displayed and laid out within a flex container.
        /// </summary>
        public string Order { get; set; }

        /// <summary>
        /// Sets the width, style, and color for all four sides of an element's outline.
        /// </summary>
        public string Outline { get; set; }

        /// <summary>
        /// Sets the color of the outline.
        /// </summary>
        public string OutlineColor { get; set; }

        /// <summary>
        /// Set the space between an outline and the border edge of an element.
        /// </summary>
        public string OutlineOffset { get; set; }

        /// <summary>
        /// Sets a style for an outline.
        /// </summary>
        public string OutlineStyle { get; set; }

        /// <summary>
        /// Sets the width of the outline.
        /// </summary>
        public string OutlineWidth { get; set; }

        /// <summary>
        /// Specifies the treatment of content that overflows the element's box.
        /// </summary>
        public string Overflow { get; set; }

        /// <summary>
        /// Specifies the treatment of content that overflows the element's box horizontally.
        /// </summary>
        public string OverflowX { get; set; }

        /// <summary>
        /// Specifies the treatment of content that overflows the element's box vertically.
        /// </summary>
        public string OverflowY { get; set; }

        /// <summary>
        /// Sets the padding on all four sides of the element.
        /// </summary>
        public string Padding { get; set; }

        /// <summary>
        /// Sets the padding to the bottom side of an element.
        /// </summary>
        public string PaddingBottom { get; set; }

        /// <summary>
        /// Sets the padding to the left side of an element.
        /// </summary>
        public string PaddingLeft { get; set; }

        /// <summary>
        /// Sets the padding to the right side of an element.
        /// </summary>
        public string PaddingRight { get; set; }

        /// <summary>
        /// Sets the padding to the top side of an element.
        /// </summary>
        public string PaddingTop { get; set; }

        /// <summary>
        /// Insert a page breaks after an element.
        /// </summary>
        public string PageBreakAfter { get; set; }

        /// <summary>
        /// Insert a page breaks before an element.
        /// </summary>
        public string PageBreakBefore { get; set; }

        /// <summary>
        /// Insert a page breaks inside an element.
        /// </summary>
        public string PageBreakInside { get; set; }

        /// <summary>
        /// Defines the perspective from which all child elements of the object are viewed.
        /// </summary>
        public string Perspective { get; set; }

        /// <summary>
        /// Defines the origin (the vanishing point for the 3D space) for the perspective property.
        /// </summary>
        public string PerspectiveOrigin { get; set; }

        /// <summary>
        /// Specifies how an element is positioned.
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Specifies quotation marks for embedded quotations.
        /// </summary>
        public string Quotes { get; set; }

        /// <summary>
        /// Specifies whether or not an element is resizable by the user.
        /// </summary>
        public string Resize { get; set; }

        /// <summary>
        /// Specify the location of the right edge of the positioned element.
        /// </summary>
        public string Right { get; set; }

        /// <summary>
        /// Specifies the stroke color for SVG elements.
        /// </summary>
        public string Stroke { get; set; }

        /// <summary>
        /// Specifies the length of the tab character.
        /// </summary>
        public string TabSize { get; set; }

        /// <summary>
        /// Specifies a table layout algorithm.
        /// </summary>
        public string TableLayout { get; set; }

        /// <summary>
        /// Sets the horizontal alignment of inline content.
        /// </summary>
        public string TextAlign { get; set; }

        /// <summary>
        /// Specifies how the last line of a block or a line right before a forced line break is aligned when text-align is justify.
        /// </summary>
        public string TextAlignLast { get; set; }

        /// <summary>
        /// Specifies the decoration added to text.
        /// </summary>
        public string TextDecoration { get; set; }

        /// <summary>
        /// Specifies the color of the text-decoration-line.
        /// </summary>
        public string TextDecorationColor { get; set; }

        /// <summary>
        /// Specifies what kind of line decorations are added to the element.
        /// </summary>
        public string TextDecorationLine { get; set; }

        /// <summary>
        /// Specifies the style of the lines specified by the text-decoration-line property
        /// </summary>
        public string TextDecorationStyle { get; set; }

        /// <summary>
        /// Indent the first line of text.
        /// </summary>
        public string TextIndent { get; set; }

        /// <summary>
        /// Specifies the justification method to use when the text-align property is set to justify.
        /// </summary>
        public string TextJustify { get; set; }

        /// <summary>
        /// Specifies how the text content will be displayed, when it overflows the block containers.
        /// </summary>
        public string TextOverflow { get; set; }

        /// <summary>
        /// Applies one or more shadows to the text content of an element.
        /// </summary>
        public string TextShadow { get; set; }

        /// <summary>
        /// Transforms the case of the text.
        /// </summary>
        public string TextTransform { get; set; }

        /// <summary>
        /// Specify the location of the top edge of the positioned element.
        /// </summary>
        public string Top { get; set; }

        /// <summary>
        /// Applies a 2D or 3D transformation to an element.
        /// </summary>
        public string Transform { get; set; }

        /// <summary>
        /// Defines the origin of transformation for an element.
        /// </summary>
        public string TransformOrigin { get; set; }

        /// <summary>
        /// Specifies how nested elements are rendered in 3D space.
        /// </summary>
        public string TransformStyle { get; set; }

        /// <summary>
        /// Defines the transition between two states of an element.
        /// </summary>
        public string Transition { get; set; }

        /// <summary>
        /// Specifies when the transition effect will start.
        /// </summary>
        public string TransitionDelay { get; set; }

        /// <summary>
        /// Specifies the number of seconds or milliseconds a transition effect should take to complete.
        /// </summary>
        public string TransitionDuration { get; set; }

        /// <summary>
        /// Specifies the names of the CSS properties to which a transition effect should be applied.
        /// </summary>
        public string TransitionProperty { get; set; }

        /// <summary>
        /// Specifies the speed curve of the transition effect.
        /// </summary>
        public string TransitionTimingFunction { get; set; }

        /// <summary>
        /// Sets the vertical positioning of an element relative to the current text baseline.
        /// </summary>
        public string VerticalAlign { get; set; }

        /// <summary>
        /// Specifies whether or not an element is visible.
        /// </summary>
        public string Visibility { get; set; }

        /// <summary>
        /// Specifies how white space inside the element is handled.
        /// </summary>
        public string WhiteSpace { get; set; }

        /// <summary>
        /// Specify the width of an element.
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// Specifies how to break lines within words.
        /// </summary>
        public string WordBreak { get; set; }

        /// <summary>
        /// Sets the spacing between words.
        /// </summary>
        public string WordSpacing { get; set; }

        /// <summary>
        /// Specifies whether to break words when the content overflows the boundaries of its container.
        /// </summary>
        public string WordWrap { get; set; }

        /// <summary>
        /// Specifies a layering or stacking order for positioned elements.
        /// </summary>
        public string ZIndex { get; set; }

        /// <summary>
        /// Specifies graphical effects to an element.
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// Specifies under what circumstances a particular element can be the target of mouse events.
        /// </summary>
        public string PointerEvents { get; set; }

        /// <summary>
        /// Specifies a collection of keyframe animations associated with this style.
        /// Each <see cref="SharpKeyframes"/> defines a named set of keyframes for use in CSS animations.
        /// </summary>
        public List<SharpKeyframes> Keyframes { get; set; }

        /// <summary>
        /// Specifies a collection of media queries that apply conditional styles based 
        /// on device characteristics such as screen size, orientation, or other media features.
        /// </summary>
        public List<MediaQuery> MediaQueries { get; set; }

        [Obsolete("ToCss is obsolete and only supports legacy nested style serialization." +
            " Use ToStyleCss() extension method instead.")]
        public string ToCss()
        {
            var reg = new Regex("([a-z,0-9](?=[A-Z])|[A-Z](?=[A-Z][a-z]))");

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            PropertyInfo[] properties = this.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType.IsEquivalentTo(typeof(SharpStyle)))
                {
                    string prefix = null;
                    string selectorCss = null;

                    foreach (var attribute in property.CustomAttributes)
                    {
                        if (attribute.NamedArguments.Any())
                        {
                            selectorCss = attribute.NamedArguments[0].TypedValue.Value.ToString();
                        }
                        else
                        {
                            prefix += attribute.AttributeType.Name switch
                            {
                                nameof(CssId) => "#",
                                nameof(CssClass) => ".",
                                nameof(CssDeep) => "::deep ",
                                _ => ""
                            };
                        }
                    }

                    if (selectorCss is null)
                    {
                        selectorCss = reg.Replace(property.Name, "$1-").ToLower();
                        stringBuilder.AppendLine();
                        stringBuilder.Append($"{prefix}{selectorCss} {{");
                    }
                    else
                    {
                        stringBuilder.AppendLine();
                        stringBuilder.Append($"{selectorCss} {{");
                    }

                    stringBuilder.AppendLine();
                    PropertyInfo[] innerProperties = property.PropertyType.GetProperties();
                    var propertyValue = property.GetValue(this);

                    if (propertyValue != null)
                    {
                        foreach (PropertyInfo innerProperty in innerProperties)
                        {
                            if (innerProperty.GetValue(propertyValue) != null)
                            {
                                string rawValue = $"\t{innerProperty.Name}: {innerProperty.GetValue(propertyValue)};";
                                stringBuilder.Append(reg.Replace(rawValue, "$1-").ToLower());
                                stringBuilder.AppendLine();
                            }
                        }
                    }

                    stringBuilder.Append("}");
                    stringBuilder.AppendLine();
                }
            }

            return stringBuilder.ToString();
        }
    }
}
