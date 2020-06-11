using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class CourseOperation : ICourseOperation
    {
        private readonly DataContext _dataContext;
        public CourseOperation(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public void addCourseBy<T>(T data)
        {
            _dataContext.Add(data);
        }

        public async Task<Courses> getCourseById(int id)
        {
            var course = await _dataContext.Courses.FirstOrDefaultAsync(x => x.courseId == id);
            return course;
        }

        public async Task<IEnumerable<Courses>> getCourseList()
        {
            var course = await _dataContext.Courses.ToListAsync();
            return course;
        }
    }
}
