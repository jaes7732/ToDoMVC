using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDo.Models
{
    public class ToDoDB
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool checkList { get; set; }
        //[ForeignKey]
        public string UserId { get; set; }
        public virtual ApplicationUser User {get; set;}
    }
}