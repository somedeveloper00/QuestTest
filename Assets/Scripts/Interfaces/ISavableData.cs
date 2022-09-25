namespace Interfaces
{
    /// <summary>
    /// data used to store for database
    /// </summary>
    public interface ISavableData<T>
    {
        public string GetDatabaseKey();
        public T ParseDatabaseString(string data);
        public string ToDatabaseString();
    }
}