namespace Pioneer_Backend.DataAccess
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string MembersCollectionName { get; set; } = null!;
        public string UsersCollectionName { get; set; } = null!;
        public string RewardsCollectionName { get; set; } = null!;
        public string ProjectsCollectionName { get; set; } = null!;
        public string UserCollectionName { get; set; } = null!;
    }
}
