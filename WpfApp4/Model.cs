using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    static class Model
    {
        public static double? count = null;

        public static List<string> datalist = new List<string> { "Сложение", "Вычитание", "Деление", "Умножение" };
        public static List<string> dataSymb = new List<string> { "+", "-", "*", "/" };
    }
}
