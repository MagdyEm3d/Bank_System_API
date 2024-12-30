using Banking_Project.Connection;
using Banking_Project.DTOS;
using Banking_Project.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Banking_Project.Repo
{
    public class CustomerReposatory:ICustomerReposatory
    {
        private readonly ApplicationDbContext _context;

        public CustomerReposatory(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddCustomer(CustomerDTO customerDTO)
        {
            try
            {
                
                var checkcustomer = _context.Customers.FirstOrDefault(x => x.CustomerEmail == customerDTO.CustomerEmail);
                if (checkcustomer != null)
                    return false;
                var customer = new Customer
                {
                    CustomerName = customerDTO.CustomerName,
                    CustomerEmail = customerDTO.CustomerEmail,
                    CustomerPhone = customerDTO.CustomerPhone,
                    BankCardId = customerDTO.BankCardId,


                };
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return true;    

            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");

            }
        }

        public IEnumerable<object> GetAll()
        {
            try
            {
                return _context.Customers.Include(x => x.BankCard).Include(x => x.Accounts).ThenInclude(x => x.Transactions).Select(x => new
                {
                    Id = x.CustomerId,
                    CustomerName = x.CustomerName,
                    Email = x.CustomerEmail,
                    Phone = x.CustomerPhone,

                    CardNumber = x.BankCard.CardNumber,
                    ExpireDate = x.BankCard.Expiredate,
                    AccountNumber = x.Accounts.Select(x => new
                    {
                        AccountNumber = x.AccountNumber,
                        Balance = x.balance,
                        Amount = x.Transactions.Select(x => new
                        {
                            Amount = x.amount,
                            Date = x.date,
                        }).ToList(),
                    }).ToList(),



                }).ToList();
                

            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");

            }
        }

        public object GetCustomer(int id)
        {
            try
            {
                return _context.Customers.Where(x => x.CustomerId == id).Include(x => x.BankCard).Include(x => x.Accounts).ThenInclude(x => x.Transactions).Select(x => new
                {
                    Id = x.CustomerId,
                    CustomerName = x.CustomerName,
                    Email = x.CustomerEmail,
                    Phone = x.CustomerPhone,

                    CardNumber = x.BankCard.CardNumber,
                    ExpireDate = x.BankCard.Expiredate,
                    AccountNumber = x.Accounts.Select(x => new
                    {
                        AccountNumber = x.AccountNumber,
                        Balance = x.balance,
                        Amount = x.Transactions.Select(x => new
                        {
                            Amount = x.amount,
                            Date = x.date,
                        }).ToList(),
                    }).ToList(),



                }).ToList().FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");

            }
        }
    }
}
