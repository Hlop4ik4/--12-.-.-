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

		private void WriteToFile(string text, FileStream stream)
		{
			byte[] info = new UTF8Encoding(true).GetBytes(text);
			stream.Write(info, 0, info.Length);
		}

		public bool SaveData(string filename)
		{
			if (File.Exists(filename))
			{
				File.Delete(filename);
			}
			using (FileStream fs = new FileStream(filename, FileMode.Create))
			{
				WriteToFile($"BaseCollection{Environment.NewLine}", fs);
				foreach(var level in baseStages)
				{
					WriteToFile($"Base{separator}{level.Key}{Environment.NewLine}", fs);
					IAntiAir car = null;
					for(int i = 0; (car = level.Value.GetNext(i)) != null; i++)
					{
						if(car != null)
						{
							if(car.GetType().Name == "ArmoredCar")
							{
								WriteToFile($"ArmoredCar{separator}", fs);
							}
							if(car.GetType().Name == "AntiAir")
							{
								WriteToFile($"AntiAir{separator}", fs);
							}
							WriteToFile(car + Environment.NewLine, fs);
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
			string bufferTextFromFile = "";
			using(FileStream fs = new FileStream(filename, FileMode.Open))
			{
				byte[] b = new byte[fs.Length];
				UTF8Encoding temp = new UTF8Encoding(true);
				while(fs.Read(b, 0, b.Length) > 0)
				{
					bufferTextFromFile += temp.GetString(b);
				}
			}
			bufferTextFromFile = bufferTextFromFile.Replace("\r", "");
			var strs = bufferTextFromFile.Split('\n');
			if (strs[0].Contains("BaseCollection"))
			{
				baseStages.Clear();
			}
			else
			{
				return false;
			}
			Vehicle car = null;
			string key = string.Empty;
			for(int i = 1; i < strs.Length; i++)
			{
				if (strs[i].Contains("Base"))
				{
					key = strs[i].Split(separator)[1];
					baseStages.Add(key, new Base<Vehicle>(pictureWidth, pictureHeight));
					continue;
				}
				if (string.IsNullOrEmpty(strs[i]))
				{
					continue;
				}
				if(strs[i].Split(separator)[0] == "ArmoredCar")
				{
					car = new ArmoredCar(strs[i].Split(separator)[1]);
				}
				else if(strs[i].Split(separator)[0] == "AntiAir")
				{
					car = new AntiAir(strs[i].Split(separator)[1]);
				}
				var result = baseStages[key] + car;
				if (result >= 0)
				{
					return false;
				}
			}
			return true;
		}
	}
}
