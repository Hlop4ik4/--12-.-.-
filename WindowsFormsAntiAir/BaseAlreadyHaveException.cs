using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAntiAir
{
    public class BaseAlreadyHaveException : Exception
    {
        public BaseAlreadyHaveException() : base("На базе уже есть такой транспорт") { }
    }
}
