using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAntiAir
{
    public class BaseNotFoundException : Exception
    {
        public BaseNotFoundException(int i) : base("Не найден транспорт по месту " + i)
        {
        }
    }
}
