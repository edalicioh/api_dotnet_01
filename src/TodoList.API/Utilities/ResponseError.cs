using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.API.ViewModels;

namespace TodoList.API.Utilities
{
    public class ResponseError
    {
         public static ResponseViewModel ApplicationErrorMessage()
         { 
            return new ResponseViewModel{
                Message = "Error interno",
                Success = false,
                Data = null
            };
         }

          public static ResponseViewModel DomainErrorMessage(string message)
         { 
            return new ResponseViewModel{
                Message = message,
                Success = false,
                Data = null
            };
         }


    }
}