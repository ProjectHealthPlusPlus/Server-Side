using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Org.BouncyCastle.Crypto.Engines;

namespace HealthPlusPlus_AW.Extensions
{
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string str)
        {
            return string.Concat(
                str.Select((x, i) => i > 0 &&
                char.IsUpper(x) ? "_" + x.ToString() :
                x.ToString())).ToLower();
        }
    }
}