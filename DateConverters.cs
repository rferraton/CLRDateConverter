using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using Microsoft.SqlServer.Server;

namespace clrconverter
{
    public partial class DateConverters

	{
		[SqlFunction(IsDeterministic = true, IsPrecise = true, DataAccess = DataAccessKind.None)]
		public static SqlDateTime SQLJulianToGregorian(SqlInt32 jdate, SqlInt32 jtime) => JulianToGregorian((int)jdate, (int)jtime);


		private static SqlDateTime JulianToGregorian(int jdate, int jtime)
		{
			DateTime result;

			if (jdate.ToString() is null)
			{
				jdate = 19000101;
			}			

			int day = jdate % 1000;
			int year = (jdate - day + 1900000) / 1000;
			var date1 = new DateTime(year, 1, 1);
			var resultdate = date1.AddDays(day - 1);			

			if ((jtime.ToString() is null) || (jtime==0))
			{
				result = resultdate;
			}
			else
			{
				var jtimestring = jtime.ToString("000000");
				double seconds = TimeSpan.ParseExact(jtimestring, "hhmmss", CultureInfo.InvariantCulture).TotalSeconds;
				result = resultdate.AddSeconds(seconds);
			}
			return result;

		}
	}
}
