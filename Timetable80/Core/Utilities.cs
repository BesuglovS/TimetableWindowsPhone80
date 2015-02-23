using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTest.Core
{
    public static class Utilities
    {

        public static int CalculateWeekNumber(string semesterStarts, DateTime dateTime)
        {
            var start = DateTime.ParseExact(semesterStarts, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            var ssDow = (start.DayOfWeek != DayOfWeek.Sunday) ? (int)start.DayOfWeek : 7;

            var ssWeeksMonday = start.AddDays((-1) * (ssDow - 1));

            return (dateTime - ssWeeksMonday).Days / 7 + 1;
        }

        public static string CombineWeeks(List<int> list)
        {
            var result = new List<string>();
            const int maxWeek = 54;
            var boolWeeks = new bool[maxWeek + 1];

            for (var i = 0; i <= maxWeek; i++)
            {
                boolWeeks[i] = list.Contains(i);
            }

            bool prev = false;
            int baseNum = maxWeek;
            for (var i = 1; i <= maxWeek - 2; i++)
            {
                if (!prev && boolWeeks[i])
                {
                    baseNum = i;
                }

                if (!boolWeeks[i] && ((i - baseNum) > 2))
                {
                    result.Add(baseNum + "-" + (i - 1));

                    for (var k = baseNum; k < i; k++)
                    {
                        boolWeeks[k] = false;
                    }
                }

                if (!boolWeeks[i])
                {
                    baseNum = maxWeek + 1;
                }

                prev = boolWeeks[i];
            }


            prev = false;
            baseNum = maxWeek + 1;
            for (var i = 1; i <= maxWeek; i += 2)
            {
                if (!prev && boolWeeks[i])
                {
                    baseNum = i;
                }

                if (!boolWeeks[i] && ((i - baseNum) > 4))
                {
                    result.Add(baseNum + "-" + (i - 2) + " (нечёт.)");

                    for (var k = baseNum; k < i; k += 2)
                    {
                        boolWeeks[k] = false;
                    }
                }

                if (!boolWeeks[i])
                {
                    baseNum = maxWeek + 1;
                }

                prev = boolWeeks[i];
            }

            prev = false;
            baseNum = maxWeek + 1;
            for (var i = 2; i <= maxWeek; i += 2)
            {
                if (!prev && boolWeeks[i])
                {
                    baseNum = i;
                }

                if (!boolWeeks[i] && ((i - baseNum) > 4))
                {
                    result.Add(baseNum + "-" + (i - 2) + " (чёт.)");

                    for (var k = baseNum; k < i; k += 2)
                    {
                        boolWeeks[k] = false;
                    }
                }

                if (!boolWeeks[i])
                {
                    baseNum = maxWeek + 1;
                }

                prev = boolWeeks[i];
            }



            for (var i = 1; i <= maxWeek; i++)
            {
                if (boolWeeks[i])
                {
                    result.Add(i.ToString(CultureInfo.InvariantCulture));
                }
            }

            result.Sort((a, b) =>
            {
                int aVal, bVal;

                if (a.Contains('-'))
                {
                    int.TryParse(a.Substring(0, a.IndexOf('-')), out aVal);
                }
                else
                {
                    int.TryParse(a, out aVal);
                }

                if (b.Contains('-'))
                {
                    int.TryParse(b.Substring(0, b.IndexOf('-')), out bVal);
                }
                else
                {
                    int.TryParse(b, out bVal);
                }

                if (aVal > bVal) return 1;
                if (bVal > aVal) return -1;
                return 0;
            });

            var final = result.Aggregate((current, str) => current + ", " + str);
            return final;
        }
    }
}
