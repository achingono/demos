using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace ProSoft.Personnel
{
    /// <summary>
    /// Summary description for JsonMediaTypeFormatter
    /// </summary>
    public class JsonMediaTypeFormatter: MediaTypeFormatter
    {
        public JsonMediaTypeFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }

        protected override object OnReadFromStream(Type type, System.IO.Stream stream, HttpContentHeaders contentHeaders)
        {
            throw new NotImplementedException();
        }

        protected override void OnWriteToStream(Type type, object value, System.IO.Stream stream, HttpContentHeaders contentHeaders, System.Net.TransportContext context)
        {
            
        }
    } 
}