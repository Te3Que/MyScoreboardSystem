using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace InventoryAPI.Models;


//  This is the data that is needed for the bare minimum?
public class Scores
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? _id { get; set; }
    public string userName { get; set; }
    public int scoreAmount { get; set; }
    public string gameID { get; set; }
}