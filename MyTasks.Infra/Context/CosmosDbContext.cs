using Microsoft.Azure.Cosmos;


namespace MyTasks.Infra.Context
{
    public class CosmosDbContext : IDisposable
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Database _database;
        private readonly string _containerName;

        public CosmosDbContext(string connectionString, string databaseName, string containerName)
        {
            _cosmosClient = new CosmosClient(connectionString);
            _database = _cosmosClient.GetDatabase(databaseName);
            _containerName = containerName;
        }

        public Container GetContainer()
        {
            return _database.GetContainer(_containerName);
        }

        public void Dispose()
        {
            _cosmosClient?.Dispose();
        }
    }
}
