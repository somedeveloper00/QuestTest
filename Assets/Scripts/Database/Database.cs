using Interfaces;

namespace Database
{
    public abstract class Database
    {
        protected static Database Instance;

        private static bool Has(string key) => Instance.has(key);
        protected abstract bool has(string key);

        private static string Load(string key) => Instance.load(key);
        protected abstract string load(string key);

        private static void Save(string key, string data) => Instance.save(key, data);
        protected abstract void save(string key, string data);

        public static void Flush() => Instance.flush();
        protected abstract void flush();


        // helpers
        public static int LoadInt(string key) => int.Parse(Load(key));
        public static long LoadBool(string key) => long.Parse(Load(key));
        public static string LoadString(string key) => Load(key);

        public static void SaveInt(string key, int value) => Save(key, value.ToString());
        public static void SaveBool(string key, bool value) => Save(key, value.ToString());
        public static void SaveString(string key, string value) => Save(key, value);

        public static void SaveData(ISavableData savableData) =>
            Save(savableData.GetDatabaseKey(), savableData.ToDatabaseString());
        
        public static void LoadData(ISavableData savableData)
        {
            var key = savableData.GetDatabaseKey();
            if(Has(key)) savableData.LoadFromDatabase(Load(key));
        }
    }
}