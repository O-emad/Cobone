﻿using Ganss.Xss;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobone.Utils
{
    public struct MarkupStringSanitized
    {
        public MarkupStringSanitized(string value)
        {
            Value = Sanitize(value);
        }

        public string Value { get; }

        public static explicit operator MarkupStringSanitized(string value) => new MarkupStringSanitized(value);

        public static explicit operator MarkupString(MarkupStringSanitized value) => new MarkupString(value.Value);

        public override string ToString() => Value ?? string.Empty;

        private static string Sanitize(string value)
        {
            var sanitizer = new HtmlSanitizer();
            return sanitizer.Sanitize(value);
        }
    }
}
