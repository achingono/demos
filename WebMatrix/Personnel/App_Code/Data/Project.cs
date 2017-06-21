﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProSoft.Personnel.Data
{
    /// <summary>
    /// Summary description for Project
    /// </summary>
    public class Project
    {
        #region Properties
        [Key]
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        public string Description { get; set; }
        #endregion

        #region Relationships
        public virtual Team Team { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
        #endregion
    }
}