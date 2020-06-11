using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Courses
    {
        [Key]
        public int courseId { get; set; }
        public string courseName { get; set; }
        public string courseDesc { get; set; }
        public string courseUrl { get; set; }
        public string courseRating { get; set; }
        public DateTime courseCreation { get; set; }
        [ForeignKey("CourseCategory")]
        public int ccId { get; set; }
        
        public CourseCategory CourseCategories;
    }
}
