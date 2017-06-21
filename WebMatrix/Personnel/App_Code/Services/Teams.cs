using System.Json;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using ProSoft.Personnel.Data;
using System.Linq;

namespace ProSoft.Personnel.Services
{
    /// <summary>
    /// Summary description for Teams
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [ServiceContract]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Teams
    {
        private Entities DbContext
        {
            get { return DataContext.Current; }
        }

        /// <summary>
        /// Retrieves all the Teams in the database
        /// </summary>
        /// <returns></returns>
        [WebGet(UriTemplate = "")]
        public JsonValue All()
        {
            return this.DbContext.Teams.ToJson();
        }

        /// <summary>
        /// Returns a specific Team by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebGet(UriTemplate = "{id}")]
        public JsonValue Find(int id)
        {
            return this.DbContext.Teams.Find(id).ToJson();
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

            var clients = this.DbContext.Teams
                .Where(t => t.Name.ToLower().Contains(term.ToLower()))
                .Select(delegate(Team t)
                {
                    dynamic json = new JsonObject();
                    json.label = t.Name;
                    json.id = t.Id;
                    return json as JsonObject;
                });

            array.AddRange(clients);

            return array;
        }
        /// <summary>
        /// This method updates an Team
        /// </summary>
        /// <param name="body">This is the data submitted in url encoded format. WCF wraps the data into a <see cref="JsonObject"/></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "update", Method = "POST")]
        public JsonValue Update(JsonObject body)
        {
            return new Team().ToJson();
        }
    }
}