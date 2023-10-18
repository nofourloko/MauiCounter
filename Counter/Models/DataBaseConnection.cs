using System;
using System.Collections.ObjectModel;
using MongoDB.Bson;
using MongoDB.Driver;
namespace Counter.Models
{
	
    public class DataBaseConnection
	{
        public IMongoCollection<BsonDocument> counters { get; set; }

        public DataBaseConnection() => Conn();

        public void Conn()
        {
            var dbClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase db = dbClient.GetDatabase("CounterDB");
            counters = db.GetCollection<BsonDocument>("Counters");
        }

        public void addCounter(int Count, string fileName, string counterColor)
        {
            BsonDocument counterToAdd = new BsonDocument {
                { "title", fileName },
                { "StartingCount" , Count },
                { "CounterColor" , counterColor },
                { "Count" , Count}
            };

            counters.InsertOne(counterToAdd);
        }

        public void saveCount(string fileName)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("title", fileName);
            var update = Builders<BsonDocument>.Update.Inc("Count", 1);

            counters.UpdateOne(filter, update);
        }
        //List<MongoDB.Bson.BsonDocument>
        public int getAllDocument(ObservableCollection<Counter> Counters, int index)
        {
            var filter = Builders<BsonDocument>.Filter.Empty;
            var doucments = counters.Find(filter).ToList();

            index = doucments.Count;

            foreach (var counters in doucments)
            {
                string Title = Convert.ToString(counters["title"]);
                int Count = Convert.ToInt32(counters["Count"]);
                string StringColor = Convert.ToString(counters["CounterColor"]);
                Color counterColor = ColorConverter.convertColor(StringColor);

                Counters.Add(new Counter { Title = Title, Count = Count, CounterColor = counterColor });
            }

            return index;
        }

        public void deleteCounter(String title)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("title", title);
            counters.DeleteOne(filter);
        }

        public int resetCounter(String title)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("title", title);
            var doucment = counters.Find(filter).ToList()[0];

            int startingCount = Convert.ToInt32(doucment["StartingCount"]);
            var update = Builders<BsonDocument>.Update.Set("Count", startingCount);

            counters.UpdateOne(filter, update);

            return startingCount;
        }
    }
}

