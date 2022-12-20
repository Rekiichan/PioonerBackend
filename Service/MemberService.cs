using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pioneer_Backend.DataAccess;

namespace Pioneer_Backend.Service
{
    public class MemberService
    {
        private readonly IMongoCollection<Member> _memberCollection;

        public MemberService(IOptions<MemberDatabaseSettings> MemberDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                MemberDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                MemberDatabaseSettings.Value.DatabaseName);

            _memberCollection = mongoDatabase.GetCollection<Member>(
                MemberDatabaseSettings.Value.BooksCollectionName);
        }

        public async Task<List<Member>> GetAsyncAllMember()
        {
            return await _memberCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Member?> GetAsyncMemberByName(string nameId)
        {
            return await _memberCollection.Find(x => x.NameID == nameId).FirstOrDefaultAsync();
        }

        public async Task<Member?> GetAsyncMemberById(string id)
        {
            return await _memberCollection.Find(x => x.MemberId == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Member newMember)
        {
            await _memberCollection.InsertOneAsync(newMember);
        }

        public async Task UpdateAsync(string memberId, Member updatedMember)
        {
            await _memberCollection.ReplaceOneAsync(x => x.MemberId == memberId, updatedMember);
        }

        public async Task RemoveAsync(string id)
        {
            await _memberCollection.DeleteOneAsync(x => x.MemberId == id);
        }
    }
}
