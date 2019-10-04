using CustomerAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CustomerAPI.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerService(ICustomerDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _customers = database.GetCollection<Customer>(settings.UserCollectionName);
        }

        public List<Customer> Get() =>
            _customers.Find(book => true).ToList();

        public Customer Get(string id) =>
            _customers.Find<Customer>(customer => customer.username == id).FirstOrDefault();


        public Customer Create(Customer customer)
        {
            _customers.InsertOne(customer);
            return customer;
        }

        public void Update(string username, int balance)
        {
            var updateDef = Builders<Customer>.Update.Set("balance", balance);
            _customers.UpdateOne(customer => customer.username == username, updateDef);
        }
        public void Remove(Customer customerIn) =>
            _customers.DeleteOne(customer => customer.Id == customerIn.Id);

        public void Remove(string id) =>
            _customers.DeleteOne(customer => customer.Id == id);
    }
}