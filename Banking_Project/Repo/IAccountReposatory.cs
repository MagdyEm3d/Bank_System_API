using Banking_Project.DTOS;

namespace Banking_Project.Repo
{
    public interface IAccountReposatory
    {
        IEnumerable<object> GetAll();
        object GetAccount(int id);
        bool AddAccount(AccountDTO accountDTO);
        bool UpdateAccount(AccountDTO accountDTO, int id);
        bool DeleteAccount(int id);
    }
}
