using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto
{
    public class CourseDto
    {
        [Key] public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Course Name")] public string? Name { get; set; }
        [Required(ErrorMessage = "Please Enter Course Price")] public decimal CoursePrice { get; set; }
        [Required(ErrorMessage = "Must be selected Is-Active")] public bool IsActive { get; } = true;
        [Required(ErrorMessage = "Please Enter Course Description")] public string? Description { get; set; }
        [Required(ErrorMessage = "Please Enter Course Title")] public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public double? RegularRate { get; set; }
        public string? Details { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? ImageUrl { get; set; }
        public int TotalCount { get; set; }
        public string ImageBase64 { get; set; }
        public string CloudUrl { get; set; }
    }
}
