using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HandHistories.Parser.Utils.Time
{
    public enum TimeZoneType
    {
        EST,
        PST,
        CET,
        GMT,
        GMT1,
        CEST
    }

    public static class TimeZoneUtil
    {
        public static DateTime ConvertDateTimeToUtc(DateTime dateTime, TimeZoneType timeZone)
        {
            //TODO: CoreConversion: Test to make sure this works the same as ConvertTimeToUtc
            DateTime convertedUtcTime = TimeZoneInfo.ConvertTime(dateTime, GetTimeZoneInfo(timeZone), TimeZoneInfo.Utc);
            convertedUtcTime = DateTime.SpecifyKind(convertedUtcTime, DateTimeKind.Utc);

            return convertedUtcTime;
        }
        
        // Reference for time zones:
        // http://www.xiirus.net/articles/article-_net-convert-datetime-from-one-timezone-to-another-7e44y.aspx
        public static TimeZoneInfo GetTimeZoneInfo(TimeZoneType timeZoneTypes)
        {
            string timeZoneId = "NotSet";
            try
            {
                switch (timeZoneTypes)
                {
                    case TimeZoneType.EST:
                        timeZoneId = "Eastern Standard Time";
                        break;
                    case TimeZoneType.PST:
                        timeZoneId = "Pacific Standard Time";
                        break;
                    case TimeZoneType.CET:
                        timeZoneId = "Central European Standard Time";
                        break;
                    case TimeZoneType.GMT:
                        timeZoneId = "GMT Standard Time";
                        break;
                    case TimeZoneType.GMT1:
                        timeZoneId = "W. Europe Standard Time";
                        break;
                    case TimeZoneType.CEST:
                        timeZoneId = "Central European Summer Time";
                        break;
                    default:
                        throw new NotImplementedException("GetTimeZoneInfo: Not implemented for time zone " +
                                                          timeZoneTypes);
                }

                return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            }
            catch (InvalidTimeZoneException)
            {
                //Console.WriteLine("Registry data on the {0} zone has been corrupted.", timeZoneId);
                throw;
            }
            catch (Exception)
            {
                //TODO: CoreConversion: TimeZoneNotFoundException no longer exposed (https://github.com/dotnet/corefx/issues/7552)
                throw;
            }
        }
    }
}
