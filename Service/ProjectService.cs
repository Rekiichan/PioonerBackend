using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pioneer_Backend.DataAccess;
using Pioneer_Backend.Model;

namespace Pioneer_Backend.Service
{
    public class ProjectService
    {
        private readonly IMongoCollection<Project> _projectCollection;

        public ProjectService(IOptions<PioneerDatabaseSettings> PioneerDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                PioneerDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                PioneerDatabaseSettings.Value.DatabaseName);

            _projectCollection = mongoDatabase.GetCollection<Project>(
                PioneerDatabaseSettings.Value.ProjectsCollectionName);
        }

        public async Task<List<Project>> GetAsyncAllProjects()
        {
            return await _projectCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Project?> GetAsyncProjectById(string id)
        {
            return await _projectCollection.Find(x => x.ProjectId == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Project newProject)
        {
            await _projectCollection.InsertOneAsync(newProject);
        }

        public async Task UpdateAsync(string id, Project updatedProject)
        {
            await _projectCollection.ReplaceOneAsync(x => x.ProjectId == id, updatedProject);
        }

        public async Task RemoveAsync(string id)
        {
            await _projectCollection.DeleteOneAsync(x => x.ProjectId == id);
        }
    }
}
