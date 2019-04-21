using System;
using System.Collections.Generic;
using System.Text;

namespace Lottó
{
    public class Drawing
    {
        public short Year { get; set; }

        public byte Week { get; set; }

        public DateTime DrawingDate { get; set; }

        public List<HitDetail> HitDetails { get; set; }

        public List<byte> Numbers { get; set; }

        public Drawing(short year, byte week, DateTime? drawingDate, List<HitDetail> hitDetails, List<byte> numbers)
        {
            Year = year;
            Week = week;

            if (!drawingDate.HasValue)
            {
                DrawingDate = new DateTime(year, 1, 1);
                DrawingDate = DrawingDate.AddDays(7 * week);
            }
            else
            {
                DrawingDate = drawingDate.Value;
            }

            HitDetails = hitDetails;
            Numbers = numbers;
        }

        public override string ToString()
        {
            var toString = new StringBuilder();
            toString.AppendFormat("{0}:", DrawingDate.ToShortDateString());

            for (var i = 0; i < Numbers.Count; i++)
            {
                toString.AppendFormat(" {0}", Numbers[i]);
            }

            return toString.ToString();
        }
    }
}

