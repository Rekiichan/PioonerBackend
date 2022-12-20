namespace Pioneer_Backend.DataAccess
{
    public class RewardDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string RewardsCollectionName { get; set; } = null!;
    }
}
