using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.API.ViewModels
{
    public class ResponseViewModel
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public dynamic Data {get; set;}

    }
}