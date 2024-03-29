﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class Course
    {
        [Key] public int Id { get; set; }
        [Required] public string? Name { get; set; }
        [Required(ErrorMessage = "Price Must be have fill")] public decimal CoursePrice { get; set; }
        [Required(ErrorMessage = "Must be selected Is-Active")] public bool IsActive { get; } = true;
        public string? Description { get; set; }
        [Required] public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public double? RegularRate { get; set; }
        public string? Details { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedDate { get; set; }
        public string? ImageUrl { get; set; }
        public string? UpdatedBy { get; set; }


    }
}
