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
    
    public partial class MCR_ASSESSMENT_WEIGHT
    {
        public string ASSESSMENT_WEIGHT_ID { get; set; }
        public string LEVEL_ID { get; set; }
        public string WEIGHT { get; set; }
    
        public virtual MCR_WEIGHT_LEVEL MCR_WEIGHT_LEVEL { get; set; }
    }
}
