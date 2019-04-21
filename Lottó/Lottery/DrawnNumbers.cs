using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace Lottó
{
    public abstract class DrawnNumbers
    {
        protected ArrayList unorderedNumbers;
        protected ArrayList numbers;
        protected DateTime drawnDate;
        protected int longestSequential;
        protected int numberOfSequentials;
        public static int IntervalMinimum;
        public static int IntervalMaximum;
        public static int IntervalMiddle_1;
        public static int IntervalMiddle_2;

        protected DrawnNumbers()
            : this(DateTime.MinValue, null)
        {
        }

        protected DrawnNumbers(params object[] numbers)
            : this(DateTime.MinValue, numbers)
        {
        }

        protected DrawnNumbers(DateTime drawnDate, params object[] numbers)
        {
            this.drawnDate = drawnDate;
            unorderedNumbers = new ArrayList();
            if (numbers != null)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] is int[])
                    {
                        var nums = numbers[i] as int[];
                        for (int j = 0; j < nums.Length; j++)
                        {
                            unorderedNumbers.Add(Convert.ToInt32(nums[j]));
                        }
                    }
                    else
                    {
                        unorderedNumbers.Add(Convert.ToInt32(numbers[i]));
                    }
                }
            }
            this.numbers = (ArrayList)unorderedNumbers.Clone();
            this.numbers.Sort();
            longestSequential = CheckLongestSequential(out numberOfSequentials);
        }

        public void Add(object number)
        {
            int num = Convert.ToInt32(number);
            if (!numbers.Contains(num))
            {
                unorderedNumbers.Add(num);
                numbers = (ArrayList)unorderedNumbers.Clone();
                numbers.Sort();
            }
            longestSequential = CheckLongestSequential(out numberOfSequentials);
        }

        private int CheckLongestSequential(out int numberOfSequentials)
        {
            numberOfSequentials = 0;
            int longestSequential = 1, actualSequentialLength;
            for (int i = 0; i < numbers.Count; i++)
            {
                actualSequentialLength = 1;
                if ((i + 1 < numbers.Count) && (Convert.ToInt32(numbers[i + 1]) == Convert.ToInt32(numbers[i]) + 1))
                {
                    numberOfSequentials++;
                    while ((i + 1 < numbers.Count) && (Convert.ToInt32(numbers[i + 1]) == Convert.ToInt32(numbers[i]) + 1))
                    {
                        i++;
                        actualSequentialLength++;
                    }
                }
                if (actualSequentialLength > longestSequential)
                {
                    longestSequential = actualSequentialLength;
                }
            }
            return longestSequential;
        }

        public bool Contains(params object[] numbers)
        {
            int number;

            if ((numbers.Length == 1) && (numbers[0] is ArrayList))
            {
                numbers = ((ArrayList)numbers[0]).ToArray();
            }

            if (this.numbers.Count >= numbers.Length)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    number = Convert.ToInt32(numbers[i]);
                    if (!this.numbers.Contains(number))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public int NumberCount
        {
            get
            {
                return numbers.Count;
            }
        }

        public DateTime DrawnDate
        {
            get
            {
                return drawnDate;
            }
        }

        public ArrayList Numbers
        {
            get
            {
                return numbers;
            }
        }

        public ArrayList UnorderedNumbers
        {
            get
            {
                return unorderedNumbers;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var drawnNumbers = obj as DrawnNumbers;
            if (drawnNumbers != null)
            {
                if (NumberCount == drawnNumbers.NumberCount)
                {
                    for (int i = 0; i < NumberCount; i++)
                    {
                        if (Convert.ToInt32(Numbers[i]) != Convert.ToInt32(drawnNumbers.Numbers[i]))
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            var toString = new StringBuilder();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i < numbers.Count - 1)
                {
                    toString.AppendFormat("{0}, ", (Convert.ToInt32(numbers[i])).ToString("D2"));
                }
                else
                {
                    toString.Append(numbers[i]);
                }
            }
            return toString.ToString();
        }

        public string UnorderedToString()
        {
            var toString = new StringBuilder();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i < unorderedNumbers.Count - 1)
                {
                    toString.AppendFormat("{0}, ", (Convert.ToInt32(unorderedNumbers[i])).ToString("D2"));
                }
                else
                {
                    toString.Append(unorderedNumbers[i]);
                }
            }
            return toString.ToString();
        }

        public static bool HasBeenDrawn(ArrayList drawns, DrawnNumbers numbers, out DateTime drawnDate)
        {
            return HasBeenDrawn(drawns, numbers.Numbers, out drawnDate);
        }

        public static bool HasBeenDrawn(ArrayList drawns, ArrayList numbers, out DateTime drawnDate)
        {
            DrawnNumbers drawn;
            if (numbers.Count > 0)
            {
                for (int i = 0; i < drawns.Count; i++)
                {
                    drawn = (DrawnNumbers)drawns[i];
                    if (drawn.Contains(numbers))
                    {
                        drawnDate = drawn.DrawnDate;
                        return true;
                    }
                }
            }
            drawnDate = DateTime.MinValue;
            return false;
        }

        public static void HasBeenDrawn(ArrayList drawns, DrawnNumbers numbers, CheckBox chk)
        {
            HasBeenDrawn(drawns, numbers.Numbers, chk);
        }

        public static void HasBeenDrawn(ArrayList drawns, ArrayList numbers, CheckBox chk)
        {
            DateTime drawnDate;
            chk.Checked = DrawnNumbers.HasBeenDrawn(drawns, numbers, out drawnDate);
            if (drawnDate != DateTime.MinValue)
            {
                chk.Text = String.Format("Has been drawn at: {0}", drawnDate.ToShortDateString());
            }
            else
            {
                chk.Text = "Hasn't been drawn yet";
            }
        }

        public int LongestSequential
        {
            get
            {
                return longestSequential;
            }
        }

        public int NumberOfSequentials
        {
            get
            {
                return numberOfSequentials;
            }
        }

        /*public static Statistics GetStatistics(ArrayList drawns)
        {
            return GetStatistics(drawns, drawns.Count);
        }

        public static Statistics GetStatistics(ArrayList drawns, int max)
        {
            int number;
            DrawnNumbers dn;

            Statistics stats = new Statistics();
            for (int i = 0; i < max; i++)
            {
                dn = (DrawnNumbers)drawns[i];
                stats.NumberCount += dn.NumberCount;
                for (int j = 0; j < dn.NumberCount; j++)
                {
                    number = Convert.ToInt32(dn.Numbers[j]);

                    if (number < DrawnNumbers.IntervalMiddle_1) stats.BelowMiddle++;
                    else if (number > DrawnNumbers.IntervalMiddle_2) stats.AboveMiddle++;
                    else stats.EqualMiddle++;

                    if (number % 2 == 0) stats.Even++;
                    else stats.Odd++;

                    if (number % 3 == 0) stats.DivisibleByThree++;
                    else stats.NotDivisibleByThree++;
                }
            }
            return stats;
        }*/
    }
}
