using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace detect_overlapping_date_ranges
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var ranges = new List<DateRange>{
                new DateRange{Id=1,StartDate=new DateTime(2020,1,1), EndDate=new DateTime(2020,2,28)}, //true
                new DateRange{Id=2,StartDate=new DateTime(2020,2,28), EndDate=new DateTime(2020,3,31)}, //true
                new DateRange{Id=3,StartDate=new DateTime(2020,4,1), EndDate=new DateTime(2020,5,31)}, //false
                new DateRange{Id=4,StartDate=new DateTime(2020,6,1), EndDate=new DateTime(2020,7,31)}, //false
                new DateRange{Id=5,StartDate=new DateTime(2020,8,1), EndDate=new DateTime(2020,10,1)}, //true
                new DateRange{Id=6,StartDate=new DateTime(2020,10,1), EndDate=new DateTime(2020,12,31)}, //true
                new DateRange{Id=7,StartDate=new DateTime(2021,1,1), EndDate=new DateTime(2021,2,28)} //false
            };

            var detector = new OverlapDetector();
            detector.DetectOverlap(ranges);

            Assert.True(ranges.Single(c => c.Id == 1).HasOverlap);
            Assert.True(ranges.Single(c => c.Id == 2).HasOverlap);
            Assert.False(ranges.Single(c => c.Id == 3).HasOverlap);
            Assert.False(ranges.Single(c => c.Id == 4).HasOverlap);
            Assert.True(ranges.Single(c => c.Id == 5).HasOverlap);
            Assert.True(ranges.Single(c => c.Id == 6).HasOverlap);
            Assert.False(ranges.Single(c => c.Id == 7).HasOverlap);

        }
    }
}
