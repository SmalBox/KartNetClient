using System;
using UnityEngine;

namespace SmalBox
{
    public class TimeUtil
    {
        /// <summary>
        /// 时间转换时间戳
        /// </summary>
        public static long GetTimeStamp(DateTime dt = default)
        {
            if (dt == DateTime.MinValue)
            {
                dt = DateTime.UtcNow;
            }

            TimeSpan span = dt - new DateTime(1970, 1, 1);
            return Convert.ToInt64(span.TotalMilliseconds);
        }

        /// <summary>
        /// 时间戳转换时间
        /// </summary>
        public static DateTime GetDateTime(long ts)
        {
            DateTime dt = TimeZoneInfo.ConvertTimeToUtc(new DateTime(1970, 1, 1));
            TimeSpan span = new TimeSpan(ts);
            return dt.Add(span);
        }
    }
}