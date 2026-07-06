using System;
using System.Collections.Generic;
using System.Text;

namespace CostChef_Mobile
{
    internal class SimpleStorage
    {
        public static void SaveData<T>(string key, T data)
        {
            string jsonData = System.Text.Json.JsonSerializer.Serialize(data);
            Preferences.Default.Set(key, jsonData);
        }

        public static T LoadData<T>(string key)
        {
            string jsonData = Preferences.Default.Get(key, string.Empty);
            
            if (string.IsNullOrEmpty(jsonData))
            {
                return default(T);
            }

            return System.Text.Json.JsonSerializer.Deserialize<T>(jsonData);
        }
    }
}
