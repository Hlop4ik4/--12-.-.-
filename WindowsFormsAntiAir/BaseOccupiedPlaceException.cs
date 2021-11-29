using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAntiAir
{
    public class BaseOccupiedPlaceException : Exception
    {
        public BaseOccupiedPlaceException() : base("Место занято")
        {
        }
    }
}
