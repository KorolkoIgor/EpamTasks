//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SalesDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Manager
    {
        public Manager()
        {
            this.Sales = new HashSet<Sales>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
