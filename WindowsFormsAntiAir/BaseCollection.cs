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
			using (FileStream fs = new FileStream(filename, FileMode.Create))
			{
				StreamWriter sw = new StreamWriter(fs);
				sw.WriteLine($"BaseCollection{Environment.NewLine}", fs);
				foreach(var level in baseStages)
				{
					sw.WriteLine($"Base{separator}{level.Key}{Environment.NewLine}", fs);
					IAntiAir car = null;
					for(int i = 0; (car = level.Value.GetNext(i)) != null; i++)
					{
						if(car != null)
						{
							if(car.GetType().Name == "ArmoredCar")
							{
								sw.WriteLine($"ArmoredCar{separator}", fs);
							}
							if(car.GetType().Name == "AntiAir")
							{
								sw.WriteLine($"AntiAir{separator}", fs);
							}
							sw.WriteLine(car + Environment.NewLine, fs);
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
			string bufferTextFromFile = "0";
			using(FileStream fs = new FileStream(filename, FileMode.Open))
			{
				StreamReader sr = new StreamReader(fs);
				while (!string.IsNullOrEmpty(bufferTextFromFile))
				{
					bufferTextFromFile = sr.ReadLine();
					if (bufferTextFromFile.Contains("BaseCollection"))
					{
						baseStages.Clear();
					}
					else
					{
						return false;
					}
					Vehicle car = null;
					string key = string.Empty;
					if (bufferTextFromFile.Contains("Base"))
					{
						key = bufferTextFromFile.Split(separator)[1];
						baseStages.Add(key, new Base<Vehicle>(pictureWidth, pictureHeight));
					}
					if (bufferTextFromFile.Split(separator)[0] == "ArmoredCar")
					{
						car = new ArmoredCar(bufferTextFromFile.Split(separator)[1]);
					}
					else if (bufferTextFromFile.Split(separator)[0] == "AntiAir")
					{
						car = new AntiAir(bufferTextFromFile.Split(separator)[1]);
					}
					var result = baseStages[key] + car;
					if (result < 0)
					{
						return false;
					}
				}
				return true;
			}
		}
	}
}
