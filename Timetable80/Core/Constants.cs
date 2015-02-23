using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTest.Core
{
    public static class Constants
    {
        public static Dictionary<int, int> DowRemap = new Dictionary<int, int>() { { 0, 7 }, { 1, 1 }, { 2, 2 }, { 3, 3 }, { 4, 4 }, { 5, 5 }, { 6, 6 } };

        public static Dictionary<int, String> dowLocal = new Dictionary<int, String>() { { 1, "Понедельник" }, { 2, "Вторник" }, { 3, "Среда" }, { 4, "Четверг" }, { 5, "Пятница" }, { 6, "Суббота" }, { 7, "Воскресенье" } };
    }
}
