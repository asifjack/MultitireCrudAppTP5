using BussinessAceessLayer;
using CommonLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultitireCrudAppTP5.Controllers
{
    public class EmployeesController : Controller
    {
        private BLEmployeeBussiness bussiness = new BLEmployeeBussiness();
        public IActionResult Index()
        {
            var emp = bussiness.GetEmployees();
            return View(emp);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employees employee)
        {
            var result = bussiness.CreateEmployee(employee);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("error", "Error Accured");
                return View();
            }
        }

        public IActionResult Update(int id)
        {

            var checkEmp = bussiness.GetEmployeesById(id);
            return View(checkEmp);
        }
        [HttpPost]
        public IActionResult Update(Employees employee)
        {

            var checkEmp = bussiness.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            bussiness.DeleteEmployee(id);
            return RedirectToAction("Index");
           
        }
    }
}
