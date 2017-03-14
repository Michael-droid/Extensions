﻿using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Tyrrrz.Extensions
{
    public static partial class Ext
    {
        /// <summary>
        /// Returns true if the enum value has all of the given flags set
        /// </summary>
        [Pure]
        public static bool HasFlags(this Enum enumValue, params Enum[] flags)
        {
            return flags.All(enumValue.HasFlag);
        }

        /// <summary>
        /// Parses string to the given enum
        /// </summary>
        [Pure]
        public static TEnum ParseEnum<TEnum>([NotNull] this string str, bool ignoreCase = true) where TEnum : struct
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            return (TEnum) Enum.Parse(typeof (TEnum), str, ignoreCase);
        }

        /// <summary>
        /// Parses string to the given enum or returns default value if unsuccessful
        /// </summary>
        [Pure]
        public static TEnum ParseEnumOrDefault<TEnum>(this string str, bool ignoreCase = true, TEnum defaultValue = default(TEnum)) where TEnum : struct
        {
            if (str == null) return defaultValue;

            TEnum result;
            return Enum.TryParse(str, ignoreCase, out result) ? result : defaultValue;
        }

        /// <summary>
        /// Gets all possible values of an enum
        /// </summary>
        [Pure]
        public static IEnumerable<TEnum> GetAllEnumValues<TEnum>(this Type enumType) where TEnum : struct
        {
            return Enum.GetValues(enumType).Cast<TEnum>();
        }

        /// <summary>
        /// Returns a random enum value
        /// </summary>
        [Pure]
        public static TEnum RandomEnum<TEnum>() where TEnum : struct
        {
            var values = GetAllEnumValues<TEnum>(typeof(TEnum));
            return GetRandom(values);
        }
    }
}