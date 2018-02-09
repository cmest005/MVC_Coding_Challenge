using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestingTextRead.Models
{
     public class CurrencyModel
     {
         [Required(ErrorMessage ="Dataset is required.")]
         public string DataSets { get; set; }
         public int dataSetDifference { get; set; }
    }

}