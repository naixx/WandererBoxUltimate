using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ASCOM.Utilities
{
    // Minimal stub to emulate ASCOM RegistryAccess without real registry
    public class RegistryAccess : IDisposable
    {
        private readonly string configPath;
        private Dictionary<string, Dictionary<string, string>> store;

        public RegistryAccess()
        {
            configPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "ASCOM_FakeRegistry.json"
            );

            Load();
        }

        // Load config from file
        private void Load()
        {
            if (File.Exists(configPath))
            {
                string json = File.ReadAllText(configPath);
                //TODO store = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json);
            }
            else
            {
                store = new Dictionary<string, Dictionary<string, string>>();
            }
        }

        // Save config to file
        private void Save()
        {
           //TODO string json = JsonSerializer.Serialize(store, new JsonSerializerOptions { WriteIndented = true });
           // File.WriteAllText(configPath, json);
        }

        // Simulate reading a registry key
        public string GetProfile(string key, string valueName)
        {
            if (store.ContainsKey(key) && store[key].ContainsKey(valueName))
                return store[key][valueName];

            return "";
        }

        // Simulate writing a registry key
        public void WriteProfile(string key, string valueName, string value)
        {
            if (!store.ContainsKey(key))
                store[key] = new Dictionary<string, string>();

            store[key][valueName] = value;
            Save();
        }

        // Simulate enumerating values under a key
        public SortedList<string, string> EnumProfile(string key)
        {
            var list = new SortedList<string, string>();

            if (store.ContainsKey(key))
            {
                foreach (var pair in store[key])
                    list.Add(pair.Key, pair.Value);
            }

            return list;
        }

        public void Dispose()
        {
            Save();
        }
    }
}
