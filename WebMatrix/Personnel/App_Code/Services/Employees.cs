using System.Json;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using ProSoft.Personnel.Data;

namespace ProSoft.Personnel.Services
{
    /// <summary>
    /// Summary description for Employees
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [ServiceContract]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Employees
    {
        private Entities DbContext
        {
            get { return DataContext.Current; }
        }

        /// <summary>
        /// Retrieves all the employees in the database
        /// </summary>
        /// <returns></returns>
        [WebGet(UriTemplate = "")]
        public JsonValue All()
        {
            return this.DbContext.Employees.ToJson();
        }

        /// <summary>
        /// Returns a specific employee by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebGet(UriTemplate="{id}")]
        public JsonValue Find(int id)
        {
            return this.DbContext.Employees.Find(id).ToJson();
        }

        /// <summary>
        /// Find all entities matching the supplied term
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        [WebGet(UriTemplate = "search?term={term}")]
        public JsonValue Search(string term)
        {
            var collection = new JsonArray();

            return collection;
        }

        /// <summary>
        /// This method updates an employee
        /// </summary>
        /// <param name="body">This is the data submitted in url encoded format. WCF wraps the data into a <see cref="JsonObject"/></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "update", Method = "POST")]
        public JsonValue Update(JsonObject body)
        {
            return new Employee().ToJson();
        }
    }
}