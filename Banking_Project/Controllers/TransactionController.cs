using Banking_Project.Connection;
using Banking_Project.DTOS;
using Banking_Project.Models;
using Banking_Project.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Banking_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionnReposatory _repo;

        public TransactionController(ITransactionnReposatory repo)
        {
            _repo = repo;

        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {

            }
            catch (Exception ex)
            {
                return BadRequest($"Error for GetAll: {ex.Message}");
            }
            var transactions = _repo.GetAll();
            return Ok(transactions);
        }
        [HttpGet("GetTransaction")]
        public IActionResult GetTransaction(int id)
        {
            try
            {
                var transaction =_repo.GetTransaction(id);
                if (transaction == null)
                    return NotFound();
                return Ok(transaction);

            }
            catch (Exception ex)
            {
                return BadRequest($"Error for GetTransaction: {ex.Message}");
            }


        }

        [HttpPost("AddTransaction")]
        public IActionResult AddTransaction(TrainsitionDTO trainsitionDTO)
        {
            try
            {
                bool isadd =_repo.AddTransaction(trainsitionDTO);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest($"Error for AddTransaction: {ex.Message}");
            }

        }




    }
}
