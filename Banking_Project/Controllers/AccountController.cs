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
    public class AccountController : ControllerBase
    {
        private readonly IAccountReposatory _repo;

        public AccountController(IAccountReposatory repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var accounts = _repo.GetAll();
                return Ok(accounts);


            }
            catch (Exception ex)
            {
                return BadRequest($"Error for DeleteAccount: {ex.Message}");
            }


        }

        [HttpGet("GetAccount")]
        public IActionResult GetAccount(int id)
        {
            try
            {
                var accounts = _repo.GetAccount(id);

                if (accounts == null)
                    return NotFound();
                return Ok(accounts);


            }
            catch (Exception ex)
            {
                return BadRequest($"Error for DeleteAccount: {ex.Message}");
            }


        }

        [HttpPost("AddAccount")]
        public IActionResult AddAccount(AccountDTO accountDTO)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                bool isadd=_repo.AddAccount(accountDTO);
                if (!isadd)
                    return BadRequest("This Customer Already Exist");
                return Ok();    



            }
            catch (Exception ex)
            {
                return BadRequest($"Error for DeleteAccount: {ex.Message}");
            }

        }

        [HttpPut("UpdateAccount")]
        public IActionResult UpdateAccount(AccountDTO accountDTO,int id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                bool isupdate= _repo.UpdateAccount(accountDTO,id);
                if (!isupdate)
                    return NotFound();
                return Ok();



            }
            catch (Exception ex)
            {
                return BadRequest($"Error for DeleteAccount: {ex.Message}");
            }


        }

        [HttpDelete("DeleteAccount")]
        public IActionResult DeleteAccount(int id)
        {
            try
            {
                bool isdelete = _repo.DeleteAccount(id);
                if(!isdelete)   
                    return NotFound();
                return Ok();    


            }
            catch (Exception ex)
            {
                return BadRequest($"Error for DeleteAccount: {ex.Message}");

            }


        }

    }
}
