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
    
    public partial class MCR_CONTENT
    {
        public string CONTENT_ID { get; set; }
        public string CONTENT_TYPE_ID { get; set; }
        public string CONTENT_SIZE { get; set; }
        public string ACTIVATED { get; set; }
    
        public virtual MCR_CONTENT_TYPE MCR_CONTENT_TYPE { get; set; }
    }
}
