//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Online_Inventory.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class CategoryTable
    {
        [Required(ErrorMessage = "Must Have Category ID")]
        public int categoryID { get; set; }


        [Required(ErrorMessage = "Category Name Can't be Empty")]
        public string categoryName { get; set; }

    }
}
