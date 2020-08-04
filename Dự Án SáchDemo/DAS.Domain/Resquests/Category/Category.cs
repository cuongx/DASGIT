using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAS.Domain.Resquests
{
   public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Tên Thể Loại")]
        public string CategoryName { get; set; }
        public int SoluongSach { get; set; }
    }
}
