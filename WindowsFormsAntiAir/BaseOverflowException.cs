using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAntiAir
{
    public class BaseOverflowException : Exception
    {
        public BaseOverflowException() : base("На базе нет свободных мест")
        {
        }
    }
}
