using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Mvc.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            CourseViewModel model = _courseService.GetCourses();
            return View(model);
        }
    }
}
