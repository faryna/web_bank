using System;
using System.Collections.Generic;
using System.Linq;

namespace WebBank.WebUI.Helpers
{
    public class DateHelper
    {
        public static string GetFullDate(DateTime date)
        {
            return String.Format("{0} {1}, {2}", GetMonth(date), date.Day, date.Year);
        }

        public static string GetMonth(DateTime date)
        {
            string month = "";
            switch (date.Month)
            {
                case 1: month = "January";
                    break;
                case 2: month = "February";
                    break;
                case 3: month = "March";
                    break;
                case 4: month = "April";
                    break;
                case 5: month = "May";
                    break;
                case 6: month = "June";
                    break;
                case 7: month = "July";
                    break;
                case 8: month = "August";
                    break;
                case 9: month = "September";
                    break;
                case 10: month = "October";
                    break;
                case 11: month = "November";
                    break;
                case 12: month = "December";
                    break;
            }

            return month;
        }

        public static string GetMonthShortName(DateTime date)
        {
            string month = "";
            switch (date.Month)
            {
                case 1: month = "Jan";
                    break;
                case 2: month = "Feb";
                    break;
                case 3: month = "Mar";
                    break;
                case 4: month = "Apr";
                    break;
                case 5: month = "May";
                    break;
                case 6: month = "June";
                    break;
                case 7: month = "July";
                    break;
                case 8: month = "Aug";
                    break;
                case 9: month = "Sept";
                    break;
                case 10: month = "Oct";
                    break;
                case 11: month = "Nov";
                    break;
                case 12: month = "Dec";
                    break;
            }

            return month;
        }
    }
}