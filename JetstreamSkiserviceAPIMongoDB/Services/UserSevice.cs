using JetstreamSkiserviceAPIMongoDB.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JetstreamSkiserviceAPIMongoDB.Services
{
    public class UserSevice : IUserService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly IMongoCollection<User> _userCollection;

        public ObjectId ObId { get; set; }


        public UserSevice(IOptions<RegistrationDatabaseSettings> registrationDatabaseSettings, IConfiguration config)
        {
            try
            {
                _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));

                var mongoClient = new MongoClient(
                registrationDatabaseSettings.Value.ConnectionString);

                var mongoDatabase = mongoClient.GetDatabase(
                    registrationDatabaseSettings.Value.DatabaseName);

                _userCollection = mongoDatabase.GetCollection<User>(
                    registrationDatabaseSettings.Value.UserCollectionName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string CreateToken(string username)
        {
            try
            {
                //Creating Claims. You can add more information in these claims. For example email id.
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.NameId, username)
                };

                //Creating credentials. Specifying which type of Security Algorithm we are using
                var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

                //Creating Token description
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(tokenDescriptor);

                //Finally returning the created token
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Ban(string id)
        {
            User user = new User();
            user = _userCollection.Find(x => x.Id == id).FirstOrDefault();
            if (user != null)
            {
                user.Counter++;

                //var client = new MongoClient("mongodb://localhost:27017");
                //var database = client.GetDatabase("SkiServiceDB");
                //var collection = database.GetCollection<User>("users");

              //var filter = Builders<User>.Filter.Eq("_id",  user.Id);
                var update = Builders<User>.Update.Set("counter", user.Counter);
                _userCollection.UpdateOne(x => x.Id == id, update);
            }
        }

        public void Unban(string id)
        {
            User user = new User();
            user = _userCollection.Find(x => x.Id == id).FirstOrDefault();
            if (user != null)
            {
                user.Counter = 0;
                var update = Builders<User>.Update.Set("counter", user.Counter);
                _userCollection.UpdateOne(x => x.Id == id, update);
            }
        }

        public List<User> Get()
        {
            return _userCollection.Find(_ => true).ToList();
        }
    }
}
