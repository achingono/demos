using System.Json;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using ProSoft.Personnel.Data;

namespace ProSoft.Personnel.Services
{
    /// <summary>
    /// Summary description for Projects
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [ServiceContract]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Projects
    {
        private Entities DbContext
        {
            get { return DataContext.Current; }
        }

        /// <summary>
        /// Retrieves all the Projects in the database
        /// </summary>
        /// <returns></returns>
        [WebGet(UriTemplate = "")]
        public JsonValue All()
        {
            return this.DbContext.Projects.ToJson();
        }

        /// <summary>
        /// Returns a specific Project by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebGet(UriTemplate = "{id}")]
        public JsonValue Find(int id)
        {
            return this.DbContext.Projects.Find(id).ToJson();
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

            return array;
        }
        /// <summary>
        /// This method updates an Project
        /// </summary>
        /// <param name="body">This is the data submitted in url encoded format. WCF wraps the data into a <see cref="JsonObject"/></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "update", Method = "POST")]
        public JsonValue Update(JsonObject body)
        {
            return new Project().ToJson();
        }
    }
}