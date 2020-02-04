namespace detect_overlapping_date_ranges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class DateRange
    {
        public int Id;
        public DateTime StartDate;
        public DateTime EndDate;
        public bool HasOverlap;
    }

    public class OverlapDetector
    {
        public void DetectOverlap(List<DateRange> ranges)
        {
            foreach (var range in ranges)
            {
                if (ranges.Any(c => c.Id != range.Id &&
                ((range.StartDate >= c.StartDate && range.StartDate <= c.EndDate) ||
                     range.EndDate >= c.StartDate && range.EndDate <= c.EndDate)))
                {
                    range.HasOverlap = true;
                }

            }
        }
    }
}