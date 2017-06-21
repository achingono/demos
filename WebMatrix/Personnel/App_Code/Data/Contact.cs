using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProSoft.Personnel.Data
{
    /// <summary>
    /// Summary description for Contact
    /// </summary>
    [ComplexType]
    public class Contact
    {
        #region Properties
        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public Address Address { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }
        #endregion
    } 
}