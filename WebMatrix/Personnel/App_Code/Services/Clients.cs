using System.Json;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using ProSoft.Personnel.Data;
using System.Linq;

namespace ProSoft.Personnel.Services
{
    /// <summary>
    /// Summary description for Clients
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [ServiceContract]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Clients
    {
        private Entities DbContext
        {
            get { return DataContext.Current; }
        }

        /// <summary>
        /// Retrieves all the Clients in the database
        /// </summary>
        /// <returns></returns>
        [WebGet(UriTemplate = "")]
        public JsonValue All()
        {
            return this.DbContext.Clients.ToJson();
        }

        /// <summary>
        /// Returns a specific Client by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebGet(UriTemplate = "{id}")]
        public JsonValue Find(int id)
        {
            return this.DbContext.Clients.Find(id).ToJson();
        }

        /// <summary>
        /// Find all entities matching the supplied term
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        [WebGet(UriTemplate = "search?term={term}")]
        public JsonValue Search(string term)
        {
            var array = new JsonArray();

            var clients = this.DbContext.Clients
                .Where(c => c.Company.ToLower().Contains(term.ToLower()))
                .Select(delegate(Client c)
                {
                    dynamic json = new JsonObject();
                    json.label = c.Company;
                    json.id = c.Id;
                    return json as JsonObject;
                });

            array.AddRange(clients);

            return array;
        }
        /// <summary>
        /// This method updates an Client
        /// </summary>
        /// <param name="body">This is the data submitted in url encoded format. WCF wraps the data into a <see cref="JsonObject"/></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "update", Method = "POST")]
        public JsonValue Update(JsonObject body)
        {
            return new Client().ToJson();
        }
    }
}