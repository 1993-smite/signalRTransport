using DBDapper;
using DBDapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IDapperRepository<Employee> _employeeRepository;

        public EmployeeController(IDapperRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: EmployeeController
        [HttpGet]
        public ActionResult Index()
        {
            return Ok(_employeeRepository.GetList());
        }

        // GET: EmployeeController/Details/5
        [HttpGet]
        public ActionResult Card(int id)
        {
            return Ok(_employeeRepository.Get(id));
        }

        // POST: EmployeeController/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            _employeeRepository.Create(employee);
            return Ok();
        }

        // GET: EmployeeController/Edit/5
        [HttpPut]
        public ActionResult Edit(Employee employee)
        {
            _employeeRepository.Update(employee);
            return Ok();
        }

        // GET: EmployeeController/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            return Ok();
        }
    }
}
