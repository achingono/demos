using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel.DomainServices.Hosting;
using System.ServiceModel.DomainServices.Server;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Services
{
    /// <summary>
    /// Summary description for People
    /// </summary>
    [ServiceContract]
    public class People
    {
        [WebGet(UriTemplate = "")]
        public List<Person> All()
        {
            return DataContext.Current.People.ToList();
        }

        [WebGet(UriTemplate = "{id}")]
        public Person Get(int id)
        {
            return DataContext.Current.People
                .SingleOrDefault(p => p.Id == id);
        }
    }
}