using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RIDEAPI.Model;

namespace RIDEAPI.Services
{
    public class RideServices
    {
        private readonly IMongoCollection<Rides> ridecollection;
        private readonly IMongoCollection<Login> logincollection;
        private readonly IMongoCollection<Book> bookcollection;
        private readonly IMongoCollection<Feedback> feedcollection;
        public RideServices(IOptions<DBSettings> dbSettings)
        {
            var rideConnection = new MongoClient(dbSettings.Value.ConnectionString);
            var foodb = rideConnection.GetDatabase(dbSettings.Value.DatabaseName);
            
            ridecollection = foodb.GetCollection<Rides>(dbSettings.Value.CollectionName);
            logincollection = foodb.GetCollection<Login>(dbSettings.Value.CollectionName);
            bookcollection = foodb.GetCollection<Book>(dbSettings.Value.CollectionName1);
            feedcollection = foodb.GetCollection<Feedback>(dbSettings.Value.CollectionName2);
        }

        //public async Task<List<Foods>> GetAsync()
        //    => await foodcollection.Find(_ => true).ToListAsync();
      
        public async Task<List<Rides>> GettheRide()
        {
            return await ridecollection.Find(_ => true).ToListAsync();
        }

        public async Task InsertRideDetails(Rides rides)
        {
            await ridecollection.InsertOneAsync(rides);
        }
        public async Task<Feedback> GetById1(string id)
        {
            return await feedcollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Rides> GetById(string id)
        {
            return await ridecollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task UpdateFeedbackDetails(string id, Feedback feedback)
        {
            await feedcollection.ReplaceOneAsync(x => x.Id == id, feedback);
        }

        public async Task UpdateRideDetails(string id, Rides ride)
        {
            await ridecollection.ReplaceOneAsync(x => x.Id == id, ride);
        }
        public async Task DeleteFeedbackDetails(string id)
        {
            await feedcollection.DeleteOneAsync(x => x.Id == id);
        }
        public async Task DeleteRideDetails(string id)
        {
            await ridecollection.DeleteOneAsync(x => x.Id == id);
        }
        public async Task<List<Feedback>> GettheFeedback()
        {
            return await feedcollection.Find(_ => true).ToListAsync();
        }

        public async Task InsertFeedbackDetails(Feedback feedback)
        {
            await feedcollection.InsertOneAsync(feedback);
        }
        public async Task<List<Book>> GettheBook()
        {
            return await bookcollection.Find(_ => true).ToListAsync();
        }

        public async Task InsertBookDetails(Book book)
        {
            await bookcollection.InsertOneAsync(book);
        }
        public async Task<List<Login>> GettheLogin()
        {
            return await logincollection.Find(_ => true).ToListAsync();
        }
    }
}
