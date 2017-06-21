using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataContext
/// </summary>
public static class DataContext
{
    public static Entities Current
    {
        get
        {
            var key = "WebMatix.Entities.DataContext";
            var httpContext = new HttpContextWrapper(HttpContext.Current);
            var dataContext = httpContext.Items[key] as Entities;

            if (dataContext == null)
            {
                dataContext = new Entities();
                httpContext.Items[key] = dataContext;
            }
            return dataContext;
        }
    }
}