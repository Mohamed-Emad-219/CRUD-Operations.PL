using CRUD.BLL.Interfacies;
using CURD.DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;

namespace CRUD_Operations.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IWebHostEnvironment _env;

        public DepartmentController(IDepartmentRepository repository,IWebHostEnvironment env)
        {
            _departmentRepository = repository;
            _env = env;
        }
        public IActionResult Index()
        {
            //to view all department ==> GetAll()
            var Department = _departmentRepository.GetAll();
            return View(Department);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                var count = _departmentRepository.Add(department);
                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(department);// of department to complete data not remove it 
        }
 
        public IActionResult Details([FromRoute]int? id,string viewName)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var department = _departmentRepository.GetById(id.Value);
            if (department == null)
            {
                return NotFound();
            }
            return View(viewName,department);
        }
		//public IActionResult Edit( int? id)
		//{
		//	if (!id.HasValue)
		//	{
		//		return BadRequest();
		//	}
		//	var department = _departmentRepository.GetById(id.Value);
		//	if (department == null)
		//	{
		//		return NotFound();
		//	}
		//	return View(department);
		//}
        [HttpPost]
        public IActionResult Edit([FromRoute]int? id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
                return View(department);
            try
            {
                _departmentRepository.Update(department);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                    ModelState.AddModelError(string.Empty, "An Error occured During Update Department");
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Department department)
        {
            try
            {
                _departmentRepository.Delete(department);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                    ModelState.AddModelError(string.Empty, "An Error occured During Deleting Department");
            }
            return View(department);

        }
    }
}

