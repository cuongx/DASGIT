using System;
using System.Collections.Generic;
using System.Text;

namespace DAS.Domain.Responses.Author
{
   public class SaveAuthorResquest
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AvatarPath { get; set; }
    }
}
