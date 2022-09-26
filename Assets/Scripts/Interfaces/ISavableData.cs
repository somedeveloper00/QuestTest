namespace Interfaces
{
    /// <summary>
    /// data used to store for database
    /// </summary>
    public interface ISavableData
    {
        public string GetDatabaseKey();
        public void LoadFromDatabase(string data);
        public string ToDatabaseString();

    }

    public static class ISavableExtentions
    {
        public static void Load(this ISavableData savableData) => Database.Database.LoadData(savableData);
        public static void Save(this ISavableData savableData) => Database.Database.SaveData(savableData);
    }
}