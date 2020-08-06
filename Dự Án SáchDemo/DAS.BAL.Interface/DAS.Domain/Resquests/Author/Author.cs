using System;
using System.Collections.Generic;
using System.Text;

namespace DAS.Domain.Resquests.Author
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AvatarPath { get; set; }
        public int SoluongSach { get; set; }
    }
}
