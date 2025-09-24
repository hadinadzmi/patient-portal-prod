using System;


namespace MedCubes.Appointment.Server
{
    /// <summary>
    /// Class to check a range for patientcalendarentries
    /// </summary>
    public class DateTimeOffsetRange
    {
        public DateTimeOffset From { get; set; }
        public DateTimeOffset Until { get; set; }

        /// <summary>
        /// empty constructor
        /// </summary>
        public DateTimeOffsetRange() { }

        /// <summary>
        /// constructor with from and until
        /// </summary>
        /// <param name="from"></param>
        /// <param name="until"></param>
        public DateTimeOffsetRange(DateTimeOffset from, DateTimeOffset until)
        {
            From = from;
            Until = until;
        }
    }
}
