using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAntiAir
{
    public class CarComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {
            if(x.GetType().Name != y.GetType().Name)
            {
                return x.GetType().FullName.CompareTo(y.GetType().FullName);
            }
            if(x.GetType() == y.GetType() && x is ArmoredCar)
            {
                return ComparerArmoredCar((ArmoredCar)x, (ArmoredCar)y);
            }
            if(x.GetType() == y.GetType() && x is AntiAir)
            {
                return ComparerAntiAir((AntiAir)x, (AntiAir)y);
            }
            return 0;
        }

        private int ComparerArmoredCar(ArmoredCar x, ArmoredCar y)
        {
            if(x.MaxSpeed != y.MaxSpeed)
            {
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            }
            if(x.Weight != y.Weight)
            {
                return x.Weight.CompareTo(y.Weight);
            }
            if(x.MainColor != y.MainColor)
            {
                return x.MainColor.Name.CompareTo(y.MainColor.Name);
            }
            return 0;
        }

        private int ComparerAntiAir(AntiAir x, AntiAir y)
        {
            var res = ComparerArmoredCar(x, y);
            if(res != 0)
            {
                return res;
            }
            if(x.DopColor != y.DopColor)
            {
                return x.DopColor.Name.CompareTo(y.DopColor.Name);
            }
            if(x.StarEmblem != y.StarEmblem)
            {
                return x.StarEmblem.CompareTo(y.StarEmblem);
            }
            if(x.Gun != y.Gun)
            {
                return x.Gun.CompareTo(y.Gun);
            }
            return 0;
        }
    }
}
