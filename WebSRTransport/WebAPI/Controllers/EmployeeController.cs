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
        public readonly IDapperRepository<Employee> EmployeeRepository;

        public EmployeeController(IDapperRepository<Employee> employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }

        // GET: EmployeeController
        [HttpGet]
        public ActionResult Index()
        {
            return Ok(EmployeeRepository.GetList());
        }

        // GET: EmployeeController/Details/5
        [HttpGet]
        public ActionResult Card(int id)
        {
            return Ok(EmployeeRepository.Get(id));
        }

        // POST: EmployeeController/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            EmployeeRepository.Create(employee);
            return Ok();
        }

        // GET: EmployeeController/Edit/5
        [HttpPut]
        public ActionResult Edit(Employee employee)
        {
            EmployeeRepository.Update(employee);
            return Ok();
        }

        // GET: EmployeeController/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            EmployeeRepository.Delete(id);
            return Ok();
        }
    }
}
