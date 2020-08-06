using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAS.Domain.Resquests.Publishing
{
  public  class Publishing
    {
        public int PublishingId { get; set; }
        [Required]
        [Display(Name = "Nhà Xuất Bản")]
        public string PublishingName { get; set; }
        [Display(Name ="Số Lượng Sách")]
        public int SoluongSach { get; set; }
    }
}
