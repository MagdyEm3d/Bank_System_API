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
    public class BankController : ControllerBase
    {
        private readonly IBankReposatory _repo;

        public BankController(IBankReposatory repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var bank = _repo.GetAll();
                return Ok(bank);


            }
            catch (Exception ex)
            {
                return BadRequest($"Error for GetAll: {ex.Message}");
            }


        }

        [HttpGet("GetBank")]
        public IActionResult GetBank(int id)
        {
            try
            {
                var bank = _repo.GetBank(id);
                if (bank == null)
                    return NotFound();
                return Ok(bank);

            }
            catch (Exception ex)
            {
                return BadRequest($"Error for GetBank: {ex.Message}");
            }

        }

        [HttpPost("AddBank")]
        public IActionResult AddBank(BankDTO bankDTO)
        {            
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                bool isadd=_repo.AddBank(bankDTO);
                if (!isadd)
                    return BadRequest("This Card Already Exist");
                return Ok();


            }
            catch (Exception ex)
            {
                         
                return BadRequest($"Error for AddBank: {ex.Message}");
            }

        }


           
        
    }

}
