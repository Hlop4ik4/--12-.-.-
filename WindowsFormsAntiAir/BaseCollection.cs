using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAntiAir
{
	public class BaseCollection
	{
		readonly Dictionary<string, Base<Vehicle>> baseStages;
		public List<string> Keys => baseStages.Keys.ToList();
		private readonly int pictureWidth;
		private readonly int pictureHeight;

		public BaseCollection(int pictureWidth, int pictureHeight)
		{
			baseStages = new Dictionary<string, Base<Vehicle>>();
			this.pictureWidth = pictureWidth;
			this.pictureHeight = pictureHeight;
		}

		public void AddBase(string name)
		{
			if (!baseStages.ContainsKey(name))
			{
				Base<Vehicle> baseStage = new Base<Vehicle>(pictureWidth, pictureHeight);
				baseStages.Add(name, baseStage);
			}
		}

		public void DelBase(string name)
		{
			if (!baseStages.ContainsKey(name))
			{
				baseStages.Remove(name);
			}
		}

		public Base<Vehicle> this[string ind]
		{
			get
			{
				if (baseStages.ContainsKey(ind))
				{
					return baseStages[ind];
				}
				else
				{
					return null;
				}
			}
		}
	}
}
