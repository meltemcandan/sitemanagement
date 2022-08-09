using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SiteManagement.DAL.Abstract;
using SiteManagement.DAL.MongoBase;
using SiteManagement.Model.Document;

namespace SiteManagement.DAL.Concrete.Mongo
{
    public class CreditCardRepository : DocumentRepository<CreditCardEntity>, ICreditCartRepository
    {
        private const string CollectionName = "CreditCard";

        public CreditCardRepository(MongoClient client, IConfiguration configuration) : base(client, configuration, CollectionName)
        {

        }
    }
}
