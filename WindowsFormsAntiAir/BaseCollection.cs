using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsAntiAir
{
	public class BaseCollection
	{
		readonly Dictionary<string, Base<Vehicle>> baseStages;
		public List<string> Keys => baseStages.Keys.ToList();
		private readonly int pictureWidth;
		private readonly int pictureHeight;
		private readonly char separator = ':';

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

		public bool SaveData(string filename)
		{
			if (File.Exists(filename))
			{
				File.Delete(filename);
			}
			using (StreamWriter sw = new StreamWriter(filename, true))
			{
				sw.Write($"BaseCollection{Environment.NewLine}");
				foreach (var level in baseStages)
				{
					sw.Write($"Base{separator}{level.Key}{Environment.NewLine}");
					IAntiAir car = null;
					for(int i = 0; (car = level.Value.GetNext(i)) != null; i++)
					{
						if(car != null)
						{
							if(car.GetType().Name == "ArmoredCar")
							{
								sw.Write($"ArmoredCar{separator}");
							}
							if(car.GetType().Name == "AntiAir")
							{
								sw.Write($"AntiAir{separator}");
							}
							sw.Write(car + Environment.NewLine);
						}
					}
				}
			}
			return true;
		}

		public bool LoadData(string filename)
		{
			if (!File.Exists(filename))
			{
				return false;
			}
			using(StreamReader sr = new StreamReader(filename))
			{
				string str = sr.ReadLine();
				if (str.Contains("BaseCollection"))
				{
					baseStages.Clear();
				}
				else
				{
					return false;
				}
				Vehicle car = null;
				string key = string.Empty;
				while ((str = sr.ReadLine()) != null)
				{
					if (str.Contains("Base"))
					{
						key = str.Split(separator)[1];
						baseStages.Add(key, new Base<Vehicle>(pictureWidth, pictureHeight));
					}
					else if (str.Contains(separator))
					{
						if (str.Contains("ArmoredCar"))
						{
							car = new ArmoredCar(str.Split(separator)[1]);
						}
						else if (str.Contains("AntiAir"))
						{
							car = new AntiAir(str.Split(separator)[1]);
						}
						var result = baseStages[key] + car;
						if (result < 0)
						{
							return false;
						}
					}
				}
			}
			return true;
		}
	}
}
