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
    
    public partial class MCR_ANSWERS
    {
        public string ANSWERS_ID { get; set; }
        public string QUESTIONS_ID { get; set; }
        public string ANSWER_DESCRIPTION { get; set; }
        public string ANSWER1 { get; set; }
        public string ANSWER2 { get; set; }
        public string ANSWER3 { get; set; }
        public string ANSWER4 { get; set; }
        public string ANSWER5 { get; set; }
        public string INCORRECT_ANSWER { get; set; }
        public string CORRECT_ANSWER { get; set; }
    
        public virtual MCR_QUESTIONS MCR_QUESTIONS { get; set; }
    }
}
