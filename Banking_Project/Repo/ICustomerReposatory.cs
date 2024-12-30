using Banking_Project.DTOS;

namespace Banking_Project.Repo
{
    public interface ICustomerReposatory
    {
        IEnumerable<object> GetAll();
        object GetCustomer(int id);
        bool AddCustomer(CustomerDTO customerDTO);
    }
}
