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
    
    public partial class MCR_GRADE
    {
        public MCR_GRADE()
        {
            this.MCR_SUBJECT = new HashSet<MCR_SUBJECT>();
        }
    
        public string GRADE_ID { get; set; }
        public string EXAM_BOARD_ID { get; set; }
        public string SCHOOL_LEVEL_ID { get; set; }
        public string GRADE_NAME { get; set; }
        public string GRADE_DESCRIPT { get; set; }
    
        public virtual ICollection<MCR_SUBJECT> MCR_SUBJECT { get; set; }
    }
}
