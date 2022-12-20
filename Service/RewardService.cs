using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pioneer_Backend.DataAccess;
using Pioneer_Backend.Model;

namespace Pioneer_Backend.Service
{
    public class RewardService
    {
        private readonly IMongoCollection<Reward> _rewardCollection;

        public RewardService(IOptions<RewardDatabaseSettings> RewardDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                RewardDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                (string)RewardDatabaseSettings.Value.DatabaseName);

            _rewardCollection = mongoDatabase.GetCollection<Reward>(
                RewardDatabaseSettings.Value.RewardsCollectionName);
        }

        public async Task<List<Reward>> GetAsyncAllRewards()
        {
            return await _rewardCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Reward?> GetAsyncRewardById(string id)
        {
            return await _rewardCollection.Find(x => x.RewardId == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Reward newReward)
        {
            await _rewardCollection.InsertOneAsync(newReward);
        }

        public async Task UpdateAsync(string rewardId, Reward updatedReward)
        {
            await _rewardCollection.ReplaceOneAsync(x => x.RewardId == rewardId, updatedReward);
        }

        public async Task RemoveAsync(string id)
        {
            await _rewardCollection.DeleteOneAsync(x => x.RewardId == id);
        }
    }
}
