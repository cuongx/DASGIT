using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAS.Domain.Responses.Books
{
   public class BookViews
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bạn Phải Nhập Tên Sách")]
        [Display(Name = "Tên Sách")]
        public string BookName { get; set; }

        public string Avatar { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập mô tả sách")]
        [Display(Name = "Mô Tả")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập ngày phát hành")]
        [Display(Name = "Ngày Phát Hành")]
        public string Updateday { get; set; }
        [Display(Name = "Tên Tác Giả")]
        public int AuthorId { get; set; }
        [Display(Name = "(Thể Loại Sách")]
        public int CategoryId { get; set; }
        [Display(Name = "Nhà Xuất Bản")]
        public int PublishingId { get; set; }
    }
}
