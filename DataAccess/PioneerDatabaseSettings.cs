namespace Pioneer_Backend.DataAccess
{
    public class PioneerDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string MembersCollectionName { get; set; } = null!;
        public string EventsCollectionName { get; set; } = null!;
        public string RewardsCollectionName { get; set; } = null!;
        public string ProjectsCollectionName { get; set; } = null!;
    }
}
