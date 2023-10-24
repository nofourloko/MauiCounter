using System;
using System.Collections.ObjectModel;
using MongoDB.Bson;
using MongoDB.Driver;
namespace Counter.Models
{
	
    public class DataBaseConnection
	{
        public IMongoCollection<BsonDocument> CountersCollection { get; set; }

        public DataBaseConnection() => Conn();

        public void Conn()
        {
            var dbClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase db = dbClient.GetDatabase("CounterDB");
            CountersCollection = db.GetCollection<BsonDocument>("Counters");
        }

        public void getAllDocument(ObservableCollection<Counter> Counters)
        {
            var counterDocuments = CountersCollection.Find(_ => true).ToList();

            foreach (var counters in counterDocuments)
            {
                string Title = Convert.ToString(counters["title"]);
                int Count = Convert.ToInt32(counters["Count"]);
                string StringColor = Convert.ToString(counters["CounterColor"]);
                Color counterColor = ColorConverter.convertColor(StringColor);

                Counters.Add(new Counter { Title = Title, Count = Count, CounterColor = counterColor });
            }
        }

        public void addCounter(int Count, string fileName, string counterColor)
        {
            BsonDocument counterToAdd = new BsonDocument {
                { "title", fileName },
                { "StartingCount" , Count },
                { "CounterColor" , counterColor },
                { "Count" , Count}
            };

            CountersCollection.InsertOne(counterToAdd);
        }

        public void saveCount(string fileName)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("title", fileName);
            var update = Builders<BsonDocument>.Update.Inc("Count", 1);

            CountersCollection.UpdateOne(filter, update);
        }

        public void deleteCounter(String title)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("title", title);
            CountersCollection.DeleteOne(filter);
        }

        public int resetCounter(String title)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("title", title);
            var doucment = CountersCollection.Find(filter).ToList()[0];

            int startingCount = Convert.ToInt32(doucment["StartingCount"]);
            var update = Builders<BsonDocument>.Update.Set("Count", startingCount);

            CountersCollection.UpdateOne(filter, update);

            return startingCount;
        }
    }
}

