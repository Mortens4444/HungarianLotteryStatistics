using System;
using System.Collections.Generic;
using System.Text;

namespace Lottó
{
    public class Statistics
    {
        private readonly byte min;
        private readonly byte max;
        private readonly byte intervalMiddle_1;
        private readonly byte intervalMiddle_2;

        private uint[] frequencies;
        private readonly byte[] leastFrequentNumbers;

        public Statistics(byte min, byte max) : this(min, max, null, 0)
        {
        }

        public Statistics(byte min, byte max, List<Drawing> drawings) : this(min, max, drawings, drawings.Count)
        {
        }

        public Statistics(byte min, byte max, List<Drawing> drawings, int maximumNumberOfDrawns)
        {
            this.min = min;
            this.max = max;
            intervalMiddle_1 = (byte)Math.Truncate((double)(this.max - this.min) / 2 + this.min);
            intervalMiddle_2 = (byte)Math.Round((double)(this.max - this.min) / 2 + this.min);
            frequencies = new uint[this.max - this.min + 1];

            NumberCount = 0;

            BelowMiddle = 0;
            AboveMiddle = 0;
            EqualMiddle = 0;

            Even = 0;
            Odd = 0;
            DivisibleByThree = 0;
            NotDivisibleByThree = 0;
            DivisibleByFour = 0;
            NotDivisibleByFour = 0;
            DivisibleByFive = 0;
            NotDivisibleByFive = 0;
            DivisibleBySix = 0;
            NotDivisibleBySix = 0;
            DivisibleBySeven = 0;
            NotDivisibleBySeven = 0;
            DivisibleByEight = 0;
            NotDivisibleByEight = 0;
            DivisibleByNine = 0;
            NotDivisibleByNine = 0;

            byte number;
            Drawing draw;

            if (drawings != null)
            {
                for (int i = 0; i < maximumNumberOfDrawns; i++)
                {
                    draw = drawings[i];
                    NumberCount += draw.Numbers.Count;
                    for (int j = 0; j < draw.Numbers.Count; j++)
                    {
                        number = draw.Numbers[j];
                        frequencies[number - this.min]++;

                        if (number < intervalMiddle_1)
                        {
                            BelowMiddle++;
                        }
                        else if (number > intervalMiddle_2)
                        {
                            AboveMiddle++;
                        }
                        else
                        {
                            EqualMiddle++;
                        }

                        for (int divider = 2; divider < 10; divider++)
                        {
                            bool divisible = number % divider == 0;
                            switch (divider)
                            {
                                case 2:
                                    if (divisible) Even++;
                                    else Odd++;
                                    break;
                                case 3:
                                    if (divisible) DivisibleByThree++;
                                    else NotDivisibleByThree++;
                                    break;
                                case 4:
                                    if (divisible) DivisibleByFour++;
                                    else NotDivisibleByFour++;
                                    break;
                                case 5:
                                    if (divisible) DivisibleByFive++;
                                    else NotDivisibleByFive++;
                                    break;
                                case 6:
                                    if (divisible) DivisibleBySix++;
                                    else NotDivisibleBySix++;
                                    break;
                                case 7:
                                    if (divisible) DivisibleBySeven++;
                                    else NotDivisibleBySeven++;
                                    break;
                                case 8:
                                    if (divisible) DivisibleByEight++;
                                    else NotDivisibleByEight++;
                                    break;
                                case 9:
                                    if (divisible) DivisibleByNine++;
                                    else NotDivisibleByNine++;
                                    break;
                                default:
                                    throw new NotImplementedException();
                            }
                        }
                    }
                }

                leastFrequentNumbers = new byte[frequencies.Length];
                var least_frequent_values = new uint[frequencies.Length];
                for (int i = 0; i < least_frequent_values.Length; i++) least_frequent_values[i] = uint.MaxValue;
                for (byte i = 0; i < frequencies.Length; i++)
                {
                    int j = 0;

                    while (j < frequencies.Length)
                    {
                        if (least_frequent_values[j] >= frequencies[i])
                        {
                            byte k = (byte)(frequencies.Length - 1);
                            while (k > j)
                            {
                                least_frequent_values[k] = least_frequent_values[k - 1];
                                leastFrequentNumbers[k] = leastFrequentNumbers[k - 1];
                                k--;
                            }
                            least_frequent_values[k] = frequencies[i];
                            leastFrequentNumbers[k] = (byte)(i + 1);
                            break;
                        }
                        else j++;
                    }
                }
            }
        }

        public static string ArrayToString<T>(T[] array)
        {
            return String.Join(", ", array);
        }

        public byte[] LeastFrequentNumbers
        {
            get
            {
                return leastFrequentNumbers;
            }
        }

        public int NumberCount { get; set; }

        public int BelowMiddle { get; set; }

        public int AboveMiddle { get; set; }

        public int EqualMiddle { get; set; }

        public int Even { get; set; }

        public int Odd { get; set; }

        public int DivisibleByThree { get; set; }

        public int NotDivisibleByThree { get; set; }

        public int DivisibleByFour { get; set; }

        public int NotDivisibleByFour { get; set; }

        public int DivisibleByFive { get; set; }

        public int NotDivisibleByFive { get; set; }

        public int DivisibleBySix { get; set; }

        public int NotDivisibleBySix { get; set; }

        public int DivisibleBySeven { get; set; }

        public int NotDivisibleBySeven { get; set; }

        public int DivisibleByEight { get; set; }

        public int NotDivisibleByEight { get; set; }

        public int DivisibleByNine { get; set; }

        public int NotDivisibleByNine { get; set; }
    }
}