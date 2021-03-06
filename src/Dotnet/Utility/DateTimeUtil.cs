﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Dotnet.Utility
{
    /// <summary>时间帮助类
    /// </summary>
    public class DateTimeUtil
    {

        /// <summary> 将时间转换成int32类型
        /// </summary>
        public static int ToInt32(DateTime datetime, int defaultValue = 0)
        {
            //默认情况下以1970.01.01为开始时间计算
            try
            {
                var datezero = new DateTime(1970, 1, 1, 0, 0, 0);
                // TimeSpan seconds = end.AddDays(1) - startdate;
                var seconds = datetime - datezero;
                defaultValue = Convert.ToInt32(seconds.TotalSeconds);
            }
            catch (Exception)
            {
                // ignored
            }
            return defaultValue;
        }

        /// <summary> 将时间转换成long类型,以毫秒为单位
        /// </summary>
        public static long ToInt64(DateTime datetime, long defaultValue = 0)
        {
            //默认情况下以1970.01.01为开始时间计算
            try
            {
                var datezero = new DateTime(1970, 1, 1, 0, 0, 0);
                // TimeSpan seconds = end.AddDays(1) - startdate;
                var seconds = datetime - datezero;
                defaultValue = Convert.ToInt64(seconds.TotalMilliseconds);
            }
            catch (Exception)
            {
                // ignored
            }
            return defaultValue;
        }

        /// <summary>将string类型的时间转换成int32
        /// </summary>
        public static int ToInt32(string datetime, int defaultValue = 0)
        {
            if (!RegexUtil.IsDataTime(datetime)) return defaultValue;
            var end = Convert.ToDateTime(datetime);
            return ToInt32(end, defaultValue);
        }

        /// <summary> 将Int32类型的整数转换成时间
        /// </summary>
        public static DateTime ToDateTime(int seconds)
        {

            var begtime = Convert.ToInt64(seconds) * 10000000; //100毫微秒为单位
            var dt1970 = new DateTime(1970, 1, 1, 0, 0, 0);
            var tricks1970 = dt1970.Ticks; //1970年1月1日刻度
            var timeTricks = tricks1970 + begtime; //日志日期刻度
            var dt = new DateTime(timeTricks); //转化为DateTime
            //DateTime enddt = dt.Date;//获取到日期整数
            return dt;
        }

        /// <summary>将long类型的整数时间(以毫秒为单位)转换成时间
        /// </summary>
        public static DateTime ToDateTime(long millSeconds)
        {
            var begtime = millSeconds * 10000; //100毫微秒为单位
            var dt1970 = new DateTime(1970, 1, 1, 0, 0, 0);
            var tricks1970 = dt1970.Ticks; //1970年1月1日刻度
            var timeTricks = tricks1970 + begtime; //日志日期刻度
            var dt = new DateTime(timeTricks); //转化为DateTime
            //DateTime enddt = dt.Date;//获取到日期整数
            return dt;
        }

        /// <summary>获取String类型的时间拼接,拼接到天
        /// </summary>
        public static string GetPadDay(DateTime time)
        {
            var month = time.Month.ToString().PadLeft(2, '0');
            var day = time.Day.ToString().PadLeft(2, '0');
            var pad = $"{time.Year}{month}{day}";
            return pad;
        }

        /// <summary>获取string类型拼接的时间 拼接到秒
        /// </summary>
        public static string GetPadSecond(DateTime time)
        {
            var month = time.Month.ToString().PadLeft(2, '0');
            var day = time.Day.ToString().PadLeft(2, '0');
            var hour = time.Hour.ToString().PadLeft(2, '0');
            var minute = time.Minute.ToString().PadLeft(2, '0');
            var second = time.Second.ToString().PadLeft(2, '0');
            var pad = $"{time.Year}{month}{day}{hour}{minute}{second}";
            return pad;
        }

        /// <summary> 获取string类型拼接的时间 拼接到秒,但是不包括最早的2位
        /// </summary>
        public static string GetPadSecondWithoutPrefix(DateTime time)
        {
            var month = time.Month.ToString().PadLeft(2, '0');
            var day = time.Day.ToString().PadLeft(2, '0');
            var hour = time.Hour.ToString().PadLeft(2, '0');
            var minute = time.Minute.ToString().PadLeft(2, '0');
            var second = time.Second.ToString().PadLeft(2, '0');
            var pad = $"{time.Year.ToString().Substring(2)}{month}{day}{hour}{minute}{second}";
            return pad;
        }

        /// <summary>获取到毫秒的拼接
        /// </summary>
        public static string GetPadMillSecond(DateTime time)
        {
            var month = time.Month.ToString().PadLeft(2, '0');
            var day = time.Day.ToString().PadLeft(2, '0');
            var hour = time.Hour.ToString().PadLeft(2, '0');
            var minute = time.Minute.ToString().PadLeft(2, '0');
            var second = time.Second.ToString().PadLeft(2, '0');
            var minSecond = time.Millisecond.ToString().PadLeft(3, '0');
            var pad = $"{time.Year}{month}{day}{hour}{minute}{second}{minSecond}";
            return pad;
        }

        /// <summary> 获取string类型拼接的时间 拼接到秒,但是不包括最早的2位,精确到毫秒
        /// </summary>
        public static string GetPadMillSecondWithoutPrefix(DateTime time)
        {
            var month = time.Month.ToString().PadLeft(2, '0');
            var day = time.Day.ToString().PadLeft(2, '0');
            var hour = time.Hour.ToString().PadLeft(2, '0');
            var minute = time.Minute.ToString().PadLeft(2, '0');
            var second = time.Second.ToString().PadLeft(2, '0');
            var minSecond = time.Millisecond.ToString().PadLeft(3, '0');
            var pad = $"{time.Year.ToString().Substring(2)}{month}{day}{hour}{minute}{second}{minSecond}";
            return pad;
        }

        /// <summary>获取两个时间之间经历的星期几
        /// </summary>
        public static string GetWeekCross(DateTime begin, DateTime end)
        {
            if (begin.Date > end)
            {
                return "";
            }
            var weekArray = new[] { 1, 2, 3, 4, 5, 6 };

            if ((end.Date - begin.Date).TotalDays >= 7)
            {
                return string.Join(",", weekArray);
            }
            var endWeek = (int)end.DayOfWeek;
            var beginWeek = (int)begin.DayOfWeek;
            if (beginWeek <= endWeek)
            {
                var containList = new List<int>();
                for (var i = beginWeek; i <= endWeek; i++)
                {
                    containList.Add(weekArray[i]);
                }
                return string.Join(",", containList);
            }
            var removeList = new List<int>();
            for (var i = endWeek + 1; i <= beginWeek - 1; i++)
            {
                removeList.Add(weekArray[i]);
            }
            var target = weekArray.Except(removeList);
            return string.Join(",", target);
        }

        /// <summary>获取某个时间的中文星期
        /// </summary>
        public static string GetChineseWeekOfDay(DateTime time)
        {
            var dayOfWeek = (int)time.DayOfWeek;
            return GetWeekDays().FirstOrDefault(x => x.Key == dayOfWeek).Value;
        }

        /// <summary>获取星期中的所有天数
        /// </summary>
        public static Dictionary<int, string> GetWeekDays()
        {
            var weekDict = new Dictionary<int, string>
            {
                {0, "星期日"},
                {1, "星期一"},
                {2, "星期二"},
                {3, "星期三"},
                {4, "星期四"},
                {5, "星期五"},
                {6, "星期六"}
            };
            return weekDict;
        }

        /// <summary>获取某时间点第一天
        /// </summary>
        public static DateTime GetFirstDayOfMonth(DateTime time)
        {
            return new DateTime(time.Year, time.Month, 1);
        }

        /// <summary>获取某个时间点当月的最后一天
        /// </summary>
        public static DateTime GetLastDayOfMonth(DateTime time)
        {
            return new DateTime(time.Year, time.Month, 1).AddMonths(1).AddDays(-1);
        }

        /// <summary>获取某个时间点当年的第一天
        /// </summary>
        public static DateTime GetFirstDayOfYear(DateTime time)
        {
            return new DateTime(time.Year, 1, 1);
        }

        /// <summary>获取某个时间点当年的最后一天
        /// </summary>
        public static DateTime GetLastDayOfYear(DateTime time)
        {
            return new DateTime(time.Year + 1, 1, 1).AddDays(-1);
        }

        /// <summary>判断某个时间是否为当月的第一天
        /// </summary>
        public static bool IsFirstDayOfMonth(DateTime time)
        {
            var firstDay = GetFirstDayOfMonth(time);
            return firstDay.Date == time.Date;
        }

        /// <summary>判断某个时间是否为当月的最后一天
        /// </summary>
        public static bool IsLastDayOfMonth(DateTime time)
        {
            var lastDay = GetLastDayOfMonth(time);
            return lastDay.Date == time.Date;
        }

        /// <summary>判断某个时间是否为当年的第一天
        /// </summary>
        public static bool IsFirstDayOfYear(DateTime time)
        {
            var firstDay = GetFirstDayOfYear(time);
            return firstDay.Date == time.Date;
        }

        /// <summary>判断某个时间是否为当年的最后一天
        /// </summary>
        public static bool IsLastDayOfYear(DateTime time)
        {
            var lastDay = GetLastDayOfYear(time);
            return lastDay.Date == time.Date;
        }

        /// <summary>将日期转换成时间
        /// </summary>
        public static DateTime DayStrToTime(string day, DateTime formatDate = default(DateTime), DateTime defaultDate = default(DateTime))
        {
            var fullTime = $"{formatDate:yyyy-MM}-{day}";
            try
            {
                var date = Convert.ToDateTime(fullTime);
                return date;
            }
            catch (Exception)
            {
                // ignored
            }
            return defaultDate;
        }

        /// <summary>将日期转换成时间
        /// </summary>
        public static DateTime TimeStrToTime(string time, DateTime formatDate = default(DateTime), DateTime defaultDate = default(DateTime))
        {
            var fullTime = $"{formatDate:yyyy-MM-dd} {time}";
            try
            {
                var date = Convert.ToDateTime(fullTime);
                return date;
            }
            catch (Exception)
            {
                return defaultDate;
                // ignored
            }
        }

        /// <summary>
        /// 日期
        /// </summary>
        private static DateTime? _dateTime;

        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="dateTime">时间</param>
        public static void SetTime(DateTime? dateTime)
        {
            _dateTime = dateTime;
        }

        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="dateTime">时间</param>
        public static void SetTime(string dateTime)
        {
            _dateTime = ConvertUtil.ToDateOrNull(dateTime);
        }

        /// <summary>
        /// 重置时间
        /// </summary>
        public static void Reset()
        {
            _dateTime = null;
        }

        /// <summary>
        /// 获取当前日期时间
        /// </summary>
        public static DateTime GetDateTime()
        {
            if (_dateTime == null)
                return DateTime.Now;
            return _dateTime.Value;
        }

        /// <summary>
        /// 获取当前日期,不带时间
        /// </summary>
        public static DateTime GetDate()
        {
            return GetDateTime().Date;
        }

        /// <summary>
        /// 获取Unix时间戳
        /// </summary>
        public static long GetUnixTimestamp()
        {
            return GetUnixTimestamp(DateTime.Now);
        }

        /// <summary>
        /// 获取Unix时间戳
        /// </summary>
        /// <param name="time">时间</param>
        public static long GetUnixTimestamp(DateTime time)
        {
            var start = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
            long ticks = (time - start.Add(new TimeSpan(8, 0, 0))).Ticks;
            return ConvertUtil.ToLong(ticks / TimeSpan.TicksPerSecond);
        }

        /// <summary>
        /// 从Unix时间戳获取时间
        /// </summary>
        /// <param name="timestamp">Unix时间戳</param>
        public static DateTime GetTimeFromUnixTimestamp(long timestamp)
        {
            var start = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
            TimeSpan span = new TimeSpan(long.Parse(timestamp + "0000000"));
            return start.Add(span).Add(new TimeSpan(8, 0, 0));
        }
    }
}
