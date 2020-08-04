using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAS.Domain.Responses
{
   public class SaveBooksResult
    {
        public int Id { get; set; }
        public string Message { get; set; }
    }
}
