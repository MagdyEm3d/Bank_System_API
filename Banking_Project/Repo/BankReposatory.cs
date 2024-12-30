using Banking_Project.Connection;
using Banking_Project.DTOS;
using Banking_Project.Models;

namespace Banking_Project.Repo
{
    public class BankReposatory:IBankReposatory
    {
        private readonly ApplicationDbContext _context;

        public BankReposatory(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddBank(BankDTO bankDTO)
        {
            try
            {
                var checkbankname = _context.BankCards.FirstOrDefault(x => x.CardNumber == bankDTO.CardNumber);
                if (checkbankname != null)
                    return false;
                var bank = new BankCard
                {
                    CardNumber = bankDTO.CardNumber,
                    Expiredate = DateTime.Now,

                };
                _context.BankCards.Add(bank);
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
                return _context.BankCards.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public object GetBank(int id)
        {
            try
            {
                return _context.BankCards.FirstOrDefault(x => x.BankCardId == id);

            }
            catch(Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }
    }
}
