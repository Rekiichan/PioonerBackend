using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pioneer_Backend.DataAccess;
using Pioneer_Backend.Model;

namespace Pioneer_Backend.Service
{
    public class EventService
    {
        private readonly IMongoCollection<Event> _eventCollection;

        public EventService(IOptions<PioneerDatabaseSettings> PioneerDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                PioneerDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                (string)PioneerDatabaseSettings.Value.DatabaseName);

            _eventCollection = mongoDatabase.GetCollection<Event>(
                PioneerDatabaseSettings.Value.EventsCollectionName);
        }

        public async Task<List<Event>> GetAsyncAllEvents()
        {
            return await _eventCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Event?> GetAsyncEventById(string id)
        {
            return await _eventCollection.Find(x => x.EventId == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Event newEvent)
        {   
            await _eventCollection.InsertOneAsync(newEvent);
        }

        public async Task UpdateAsync(string eventId, Event updatedEvent)
        {
            await _eventCollection.ReplaceOneAsync(x => x.EventId == eventId, updatedEvent);
        }

        public async Task RemoveAsync(string id)
        {
            await _eventCollection.DeleteOneAsync(x => x.EventId == id);
        }
    }
}
