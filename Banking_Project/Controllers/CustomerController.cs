using Banking_Project.Connection;
using Banking_Project.DTOS;
using Banking_Project.Models;
using Banking_Project.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Banking_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerReposatory _repo;
        
        public CustomerController(ICustomerReposatory repo)
        {
            _repo = repo;
            
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var data = _repo.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error for GetAll: {ex.Message}");
            }

        }
        [HttpGet("GetCustomer")]
        public IActionResult GetCustomer(int id)
        {
            try
            {
                var data = _repo.GetCustomer(id);
                if (data == null)
                    return NotFound();
                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest($"Error for GetCustomer: {ex.Message}");
            }

        }
        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer(CustomerDTO customerDTO)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                bool isadd = _repo.AddCustomer(customerDTO);
                if (!isadd)
                    return BadRequest("This Customer Already Exist");
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error for AddCustomer: {ex.Message}");
            }


                
        }
    }
}
