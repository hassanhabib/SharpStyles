﻿// ---------------------------------------------------------------
// Copyright (c) Hassan Habib.
// Licensed under the TSSL License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;

namespace SharpStyles.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CssElement : Attribute
    {
        public string Selector;
    }
}
