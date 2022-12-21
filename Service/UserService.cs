using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using Pioneer_Backend.DataAccess;
using Pioneer_Backend.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pioneer_Backend.Service
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;
        private readonly string key;
        public UserService(IOptions<DatabaseSettings> PioneerDatabaseSettings, IConfiguration config)
        {
            var mongoClient = new MongoClient(
                PioneerDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(
                (string)PioneerDatabaseSettings.Value.DatabaseName);
            _users = mongoDatabase.GetCollection<User>(
                PioneerDatabaseSettings.Value.UsersCollectionName);
            this.key = config.GetSection("JwtKey").ToString();
        }
        public List<User> GetUsers()
        {
            return _users.Find(user => true).ToList();
        }
        public User GetUser(string id)
        {
            return _users.Find<User>(user => user.UserId == id).FirstOrDefault();
        }
        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }
        public string Authenticate(string email, string password)
        {
            var user = _users.Find(x => x.Email == email && x.Password == password).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
