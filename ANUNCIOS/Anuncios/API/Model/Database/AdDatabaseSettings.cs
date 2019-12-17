namespace API.Model
{
    public class AdDatabaseSettings : IAdDatabaseSettings
    {
        public string UsersCollectionName { get; set; }
        public string AdsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    
    public interface IAdDatabaseSettings
    {
        string UsersCollectionName { get; set; }
        string AdsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}