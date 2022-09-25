using UnityEngine;

namespace Database
{
    public class PlayerPrefsDatabase : Database
    {

        [RuntimeInitializeOnLoadMethod]
        static void Init() => Instance = new PlayerPrefsDatabase();

        protected override bool has(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

        protected override string load(string key)
        {
            return PlayerPrefs.GetString(key);
        }

        protected override void save(string key, string data)
        {
            PlayerPrefs.SetString(key, data);
        }

        protected override void flush()
        {
            PlayerPrefs.Save();
        }
    }
}