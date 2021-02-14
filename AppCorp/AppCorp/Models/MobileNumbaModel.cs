using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppCorp.Models
{
    public class MobileNumbaModel
    {
        public int id { get; set; }
        public string mobile { get; set; }
        public Nullable<bool> isSend { get; set; }
    }
}