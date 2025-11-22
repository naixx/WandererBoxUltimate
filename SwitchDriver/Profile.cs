using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ASCOM.WandererBoxes
{
    public class Profile : IDisposable
    {
        private static readonly object SyncRoot = new object();

        public string DeviceType { get; set; } = "Unknown";

        // Файл где будем хранить настройки
        private static readonly string ConfigPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "ASCOM", "naixxWanderer", "profile.json");

        // Вся структура данных
        private class ConfigFile
        {
            public Dictionary<string, Dictionary<string, Dictionary<string, string>>> Data
                = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
        }

        private static ConfigFile config;

        static Profile()
        {
            Load();
        }

        private static void Load()
        {
            lock (SyncRoot)
            {
                try
                {
                    if (File.Exists(ConfigPath))
                    {
                        config = JsonConvert.DeserializeObject<ConfigFile>(File.ReadAllText(ConfigPath));
                        if (config == null)
                            config = new ConfigFile();
                    }
                    else
                    {
                        config = new ConfigFile();
                    }
                }
                catch
                {
                    config = new ConfigFile(); // гарантируем живую структуру
                }
            }
        }

        private static void Save()
        {
            lock (SyncRoot)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(ConfigPath));
                File.WriteAllText(ConfigPath,
                    JsonConvert.SerializeObject(config, Formatting.Indented));
            }
        }

        // ==== СТАНДАРТНЫЕ МЕТОДЫ API ASCOM Profile ====

        public string GetValue(string driverId, string key, string subKey = "", string defaultValue = "")
        {
            lock (SyncRoot)
            {
                string device = DeviceType ?? "Unknown";

                if (config.Data.ContainsKey(device) &&
                    config.Data[device].ContainsKey(driverId) &&
                    config.Data[device][driverId].ContainsKey(key))
                {
                    return config.Data[device][driverId][key];
                }

                return defaultValue;
            }
        }

        public void WriteValue(string driverId, string key, string value)
        {
            lock (SyncRoot)
            {
                string device = DeviceType ?? "Unknown";

                if (!config.Data.ContainsKey(device))
                    config.Data[device] = new Dictionary<string, Dictionary<string, string>>();

                if (!config.Data[device].ContainsKey(driverId))
                    config.Data[device][driverId] = new Dictionary<string, string>();

                config.Data[device][driverId][key] = value;

                Save();
            }
        }

        public void DeleteValue(string driverId, string key)
        {
            lock (SyncRoot)
            {
                string device = DeviceType ?? "Unknown";

                if (config.Data.ContainsKey(device) &&
                    config.Data[device].ContainsKey(driverId) &&
                    config.Data[device][driverId].ContainsKey(key))
                {
                    config.Data[device][driverId].Remove(key);
                    Save();
                }
            }
        }

        // Для совместимости
        public void WriteProfile() => Save();
        public void ReadProfile() => Load();

        public void Dispose()
        {
            // Ничего не надо, просто для совместимости
        }
    }
}