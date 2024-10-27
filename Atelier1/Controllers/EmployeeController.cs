using Atelier1.Models.Repositories;
using Atelier1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Atelier1.Controllers
{
    public class EmployeeController : Controller
    {
        readonly IRepository<Employee> employeeRepository;

        //injection de dépendance
        public EmployeeController(IRepository<Employee> empRepository)
        {

            employeeRepository = empRepository;

        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            var employees = employeeRepository.GetAll();
            ViewData["EmployeesCount"] = employees.Count();
            ViewData["SalaryAverage"] = employeeRepository.SalaryAverage();
            ViewData["MaxSalary"] = employeeRepository.MaxSalary();
            ViewData["HREmployeesCount"] = employeeRepository.HrEmployeesCount();

            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var employee = employeeRepository.FindByID(id);

            return View(employee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
      
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
                
                employeeRepository.Add(employee);
            
                return RedirectToAction(nameof(Index));
            }
            
                return View(employee);
            
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var newemployee = employeeRepository.FindByID(id);
            
            return View(newemployee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee newemployee)
        {
            if(id != newemployee.Id)
            {
                return BadRequest();
            }
           if(ModelState.IsValid)
            {
                employeeRepository.Update(id, newemployee);
                return RedirectToAction(nameof(Index));
               
            }
            return View(newemployee);
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            employeeRepository.Delete(id);
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employee e)
        {
            try
            {
                employeeRepository.Delete(e.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search(string term)
        {

            var result = employeeRepository.Search(term);
            return View("Index", result);
        }
    }
}
