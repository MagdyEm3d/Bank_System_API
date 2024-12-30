using Banking_Project.DTOS;

namespace Banking_Project.Repo
{
    public interface IBankReposatory
    {
        IEnumerable<object> GetAll();
        object GetBank(int id);
        bool AddBank(BankDTO bankDTO);
    }
}
