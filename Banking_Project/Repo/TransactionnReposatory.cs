using Banking_Project.Connection;
using Banking_Project.DTOS;
using Banking_Project.Models;

namespace Banking_Project.Repo
{
    public class TransactionnReposatory : ITransactionnReposatory
    {
        private readonly ApplicationDbContext _context;

        public TransactionnReposatory(ApplicationDbContext context)
        {
            _context = context; 
        }

        public bool AddTransaction(TrainsitionDTO trainsitionDTO)
        {
            try
            {
                var tran = new Transactionn
                {
                    amount = trainsitionDTO.amount,
                    date = trainsitionDTO.date,
                    AccountId = trainsitionDTO.AccountId,
                };

                _context.Transactions.Add(tran);
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
                return _context.Transactions.Select(x => new
                {
                    Id = x.TransactionId,
                    Amount = x.amount,
                    Date = x.date,
                }).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public object GetTransaction(int id)
        {
            try
            {
                return _context.Transactions.Where(x => x.TransactionId == id).Select(x => new
                {
                    Id = x.TransactionId,
                    Amount = x.amount,
                    Date = x.date,
                }).ToList().FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }
    }
}
