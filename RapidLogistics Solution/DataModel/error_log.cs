//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class error_log
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string AppCode { get; set; }
        public string ErrorCode { get; set; }
        public Nullable<double> ErrorMessage { get; set; }
    }
}
