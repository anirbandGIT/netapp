using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseOperation _courseOperation;
        public CourseController(ICourseOperation courseOpeartion)
        {
            this._courseOperation = courseOpeartion;
        }
        [HttpGet]
        public async Task<IActionResult> getCourseDetails()
        {
            var course = new Courses()
            {
                courseName = "React",
                courseDesc = "React is a JavaScript library for building user interfaces. Declarative: " +
                "React makes it painless to create interactive UIs.",
                courseUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FReact_(web_framework)&psig=AOvVaw3mcIzAApClspd1j1PmBoMt&ust=1585945422885000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCNDdhrPJyugCFQAAAAAdAAAAABAD",
                courseRating = "5",
                courseCreation = DateTime.Parse("8014-04-01"),
                ccId = 5
            };
            var courseq = await _courseOperation.getCourseList();
            return Ok(courseq);
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> getCourseById(int id)
        {
            var course = await _courseOperation.getCourseById(id);
            return Ok(course);
        }
    }
}