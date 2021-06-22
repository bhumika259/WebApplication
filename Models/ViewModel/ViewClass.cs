using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models.ViewModel
{
    
    public class NewMessageViewModel
    {
        public int Id { get; set; }
        public object Username { get; internal set; }
        public string MessageBody { get; internal set; }
        public DateTime? PostDateTime { get; set; }
    }
}