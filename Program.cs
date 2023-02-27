using System;

namespace EmployeeTimeKeeping
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime timeIn, timeOut;
            int lunchBreakMinutes = 60 ;
            int gracePeriodMinutes = 60;
            int workHoursStartHour = 8;
            int workHoursEndHour = 17;

            Console.Write("Enter time in (e.g. 8:00 AM): ");
            timeIn = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter time out (e.g. 5:00 PM): ");
            timeOut = DateTime.Parse(Console.ReadLine());

            TimeSpan totalHours = timeOut - timeIn - TimeSpan.FromMinutes(lunchBreakMinutes);
            int regularHours = 0;
            int lateMinutes = 0;
            int undertimeMinutes = 0;
            int overtimeMinutes = 0;

            if (timeIn.Hour > workHoursStartHour)
            {
                lateMinutes = (timeIn.Hour - workHoursStartHour) * 60 + timeIn.Minute;
            }

            if (timeOut.Hour < workHoursEndHour)
            {
                undertimeMinutes = (workHoursEndHour - timeOut.Hour) * 60 - timeOut.Minute;
            }

            if (timeOut.Hour > workHoursEndHour)
            {
                overtimeMinutes = (timeOut.Hour - workHoursEndHour) * 60 + timeOut.Minute;
            }

            if (timeIn.Hour >= workHoursStartHour && timeOut.Hour <= workHoursEndHour)
            {
                regularHours = (int)totalHours.TotalMinutes;
            }
            else if (timeIn.Hour < workHoursStartHour && timeOut.Hour <= workHoursEndHour)
            {
                regularHours = (int)totalHours.TotalMinutes - lateMinutes;
            }
            else if (timeIn.Hour >= workHoursStartHour && timeOut.Hour > workHoursEndHour)
            {
                regularHours = (workHoursEndHour - workHoursStartHour) * 60;
                overtimeMinutes = (int)(totalHours.TotalMinutes - regularHours);
            }
            else
            {
                regularHours = (workHoursEndHour - workHoursStartHour) * 60 - lateMinutes;
                overtimeMinutes = (int)(totalHours.TotalMinutes - regularHours);
            }

            Console.WriteLine($"Total Hours: {(int)totalHours.TotalHours}:{totalHours.Minutes:d2}");
            Console.WriteLine($"Regular Hours: {(int)(regularHours / 60)}:{regularHours % 60:d2}");
            Console.WriteLine($"Late Time: {lateMinutes} minutes");
            Console.WriteLine($"Undertime: {undertimeMinutes} minutes");
            Console.WriteLine($"Overtime: {overtimeMinutes} minutes");
        }
    }
}
