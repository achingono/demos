using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace ProSoft.Personnel.Data
{
    /// <summary>
    /// Summary description for Client
    /// </summary>
    public class Client
    {
        #region Properties
        [Key]
        public int Id { get; set; }

        public string Company { get; set; }

        public Contact Mailing { get; set; }

        public Contact Billing { get; set; }

        public Contact Technical { get; set; }

        public double Rate { get; set; }

        [MaxLength]
        public string Notes { get; set; }
        #endregion

        #region Relationships
        [ScriptIgnore]
        public virtual ICollection<Project> Projects { get; set; }
        #endregion
    }
}