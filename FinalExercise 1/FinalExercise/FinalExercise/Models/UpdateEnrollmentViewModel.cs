using FinalExercise.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalExercise.Models
{
    public class UpdateEnrollmentViewModel
    {
        public string CourseName { get; set; }
        public SelectList StudentList { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}
