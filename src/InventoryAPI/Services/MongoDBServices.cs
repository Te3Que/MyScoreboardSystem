using InventoryAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace InventoryAPI.Services;

public class MongoDBService
{

    Scores updatescores = new Scores();
    private readonly IMongoCollection<Scores> _scoreCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _scoreCollection = database.GetCollection<Scores>(mongoDBSettings.Value.CollectionName);
        }

     public async Task<List<Scores>> GetAsync()
        {
            return await _scoreCollection.Find(new BsonDocument()).ToListAsync();
        }

    public async Task CreateAsync(Scores score) 
        {
            await _scoreCollection.InsertOneAsync(score);
            return;
        }

    public async Task AddToScoresAsync(string _id, Scores updateScore) 
        {
            FilterDefinition<Scores> filter = Builders<Scores>.Filter.Eq("_id", _id);
            UpdateDefinition<Scores> update = Builders<Scores>.Update
                .Set(p => p.userName, updatescores.userName)
                .Set(p => p.scoreAmount, updatescores.scoreAmount)
                .Set(p => p.gameID, updatescores.gameID);
            await _scoreCollection.UpdateOneAsync(filter, update);
            return;
        }
    public async Task DeleteAsync(string _id)
    {
        FilterDefinition<Scores> filter = Builders<Scores>.Filter.Eq("_id", _id);
        await _scoreCollection.DeleteOneAsync(filter);
        return;
    }
}