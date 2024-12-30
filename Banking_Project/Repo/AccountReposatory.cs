using Banking_Project.Connection;
using Banking_Project.DTOS;
using Banking_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Banking_Project.Repo
{
    public class AccountReposatory:IAccountReposatory
    {
        private readonly ApplicationDbContext _context;

        public AccountReposatory(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddAccount(AccountDTO accountDTO)
        {
            try
            {
                var checkaccount = _context.Accounts.FirstOrDefault(x => x.AccountNumber == accountDTO.AccountNumber);
                if (checkaccount != null)
                    return false;
                var account = new Account
                {
                    AccountNumber = accountDTO.AccountNumber,
                    balance = accountDTO.balance,
                    CustomerId = accountDTO.CustomerId,

                };

                _context.Accounts.Add(account);
                _context.SaveChanges();
                return true;    

            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
                
            }

        }

        public bool DeleteAccount(int id)
        {
            try
            {
                var account = _context.Accounts.FirstOrDefault(x => x.AccountId == id);
                if (account == null)
                    return false;
                _context.Accounts.Remove(account);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public object GetAccount(int id)
        {
            try
            {
                return _context.Accounts.Where(x => x.AccountId == id).Include(x => x.Transactions).Include(x => x.Customer).Select(x => new
                {
                    AccountNumber = x.AccountNumber,
                    Balance = x.balance
                }).ToList().FirstOrDefault();

            }
            catch(Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public IEnumerable<object> GetAll()
        {
            try
            {
                return _context.Accounts.Include(x => x.Transactions).Include(x => x.Customer).Select(x => new
                {
                    Id = x.AccountId,
                    AccountNumber = x.AccountNumber,
                    Balance = x.balance
                }).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public bool UpdateAccount(AccountDTO accountDTO, int id )
        {
            try
            {
                var account = _context.Accounts.FirstOrDefault(x => x.AccountId == id);
                if (account == null)
                    return false;
                account.balance = accountDTO.balance;
                account.AccountNumber = accountDTO.AccountNumber;
                account.CustomerId = accountDTO.CustomerId;
                _context.Accounts.Update(account);
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }
    }
}
