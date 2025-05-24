// ---------------------------------------------------------------
// Copyright (c) Hassan Habib
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Reflection;
using System.Text;
using SharpStyles.Models;
using SharpStyles.Models.Queries;

namespace SharpStyles.Services.Styles
{
    internal partial class StyleService : IStyleService
    {
        public string ToCss(SharpStyle sharpStyle)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();

            foreach (PropertyInfo property in sharpStyle.GetType().GetProperties())
            {
                if (property.PropertyType.IsEquivalentTo(typeof(SharpStyle)))
                {
                    AppendStyleBlock(sharpStyle, property, stringBuilder);
                    continue;
                }

                if (property.PropertyType.IsGenericType &&
                        property.PropertyType.GetGenericTypeDefinition() == typeof(List<>) &&
                            property.PropertyType.GetGenericArguments()[0] == typeof(MediaQuery))
                {
                    AppendMediaQueryBlock(sharpStyle, property, stringBuilder);
                }

            }

            return stringBuilder.ToString();
        }
    }
}
