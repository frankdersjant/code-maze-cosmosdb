﻿using Azure;
using code_maze_cosmosdb.Models;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace code_maze_cosmosdb.Services
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient cosmosDbClient,
            string databaseName,
            string containerName)
        {
            _container = cosmosDbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddAsync(Item item)
        {
            await _container.CreateItemAsync(item, new PartitionKey(item.id));
        }

        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<Item>(id, new PartitionKey(id));
        }

        public async Task<Item> GetAsync(string id)
        {

            ItemResponse<Item> response = null;
            try
            {
                response = await _container.ReadItemAsync<Item>(id, new PartitionKey(id));
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound) {
                //log(ex.Message)}
            }
            return response;
        }

        public async Task<IEnumerable<Item>> GetMultipleAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<Item>(new QueryDefinition(queryString));

            var results = new List<Item>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateAsync(string id, Item item)
        {
            await _container.UpsertItemAsync(item, new PartitionKey(id));
        }
    }
}
