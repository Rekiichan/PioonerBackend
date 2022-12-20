using MongoDB.Driver;
using Pioneer_Backend.Model;

namespace Pioneer_Backend.Service
{
    public class UnitOfWork
    {
        private readonly IMongoCollection<Member> _memberCollection;
        private readonly IMongoCollection<Project> _projectCollection;
        private readonly IMongoCollection<Reward> _rewardCollection;
    }
}
