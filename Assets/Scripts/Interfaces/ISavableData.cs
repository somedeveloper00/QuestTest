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
        public static void Sync(this ISavableData savableData) => Database.Database.LoadData(savableData);
    }
}