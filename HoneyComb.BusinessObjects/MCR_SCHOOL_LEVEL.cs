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
    
    public partial class MCR_SCHOOL_LEVEL
    {
        public MCR_SCHOOL_LEVEL()
        {
            this.MCR_SCHOOL = new HashSet<MCR_SCHOOL>();
        }
    
        public string SCHOOL_LEVEL_ID { get; set; }
        public string SCHOOL_LEVEL_NAME { get; set; }
    
        public virtual ICollection<MCR_SCHOOL> MCR_SCHOOL { get; set; }
    }
}