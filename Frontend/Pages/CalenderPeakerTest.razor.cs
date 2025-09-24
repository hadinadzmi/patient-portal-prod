//using System.Globalization;

//namespace Patient_Portal.Pages
//{
//    public partial class CalenderPeakerTest
//    {
//        private DateTime currentMonth = DateTime.Now;
//        private DateTime selectedDate = DateTime.MinValue;
//        private readonly string[] daysOfWeek = CultureInfo.InvariantCulture.DateTimeFormat.AbbreviatedDayNames;

//        private void PreviousMonth()
//        {
//            currentMonth = currentMonth.AddMonths(-1);
//        }

//        private void NextMonth()
//        {
//            currentMonth = currentMonth.AddMonths(1);
//        }

//        private IEnumerable<DateTime> GetDaysInMonth()
//        {
//            var firstDayOfMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);
//            var daysInMonth = DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month);
//            for (int i = 0; i < daysInMonth; i++)
//            {
//                yield return firstDayOfMonth.AddDays(i);
//            }
//        }

//        private void SelectDate(DateTime date)
//        {
//            if (!IsPastDate(date))
//            {
//                selectedDate = date;
//            }
//        }

//        private bool IsPastDate(DateTime date)
//        {
//            return date.Date < DateTime.Now.Date;
//        }

//        private string GetDayClass(DateTime day)
//        {
//            if (IsPastDate(day))
//            {
//                return "past";
//            }
//            return day.Date == selectedDate.Date ? "selected" : string.Empty;
//        }

//        private bool IsCurrentMonth()
//        {
//            return currentMonth.Year == DateTime.Now.Year && currentMonth.Month == DateTime.Now.Month;
//        }
//    }
//}
