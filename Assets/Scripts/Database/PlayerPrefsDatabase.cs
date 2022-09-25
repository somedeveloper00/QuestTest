using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Database
{
    public class PlayerPrefsDatabase : Database
    {

#if UNITY_EDITOR
        [InitializeOnLoadMethod]
#endif
        [RuntimeInitializeOnLoadMethod]
        static void Init()
        {
            Debug.Log("Database setup.");
            Instance = new PlayerPrefsDatabase();
        }

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