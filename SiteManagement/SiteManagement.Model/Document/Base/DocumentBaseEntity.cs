using MongoDB.Bson;

namespace SiteManagement.Model.Document.Base
{
    public abstract class DocumentBaseEntity
    {
        public ObjectId Id { get; set; }

        public string ObjectId => Id.ToString();
    }
}
