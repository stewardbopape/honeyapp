//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HoneyComb.BusinessObjects
{
    using System;
    using System.Collections.Generic;
    
    public partial class MCR_PROVINCE
    {
        public MCR_PROVINCE()
        {
            this.MCR_DISTRICT = new HashSet<MCR_DISTRICT>();
        }
    
        public string PROVINCE_ID { get; set; }
        public string COUNTRY_ID { get; set; }
        public string PROVINCE_NAME { get; set; }
    
        public virtual MCR_COUNTRY MCR_COUNTRY { get; set; }
        public virtual ICollection<MCR_DISTRICT> MCR_DISTRICT { get; set; }
    }
}