using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProSoft.Personnel.Data
{
    /// <summary>
    /// Summary description for Hours
    /// </summary>
    [ComplexType]
    public class Hours
    {
        #region Properties
        public double Billable { get; set; }
        public double NonBillable { get; set; }
        public double DoubleRate { get; set; }
        public double ERS { get; set; }
        #endregion
    } 
}