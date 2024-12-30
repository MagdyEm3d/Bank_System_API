using Banking_Project.DTOS;

namespace Banking_Project.Repo
{
    public interface ITransactionnReposatory
    {
        IEnumerable<object> GetAll();
        object GetTransaction(int id);

        bool AddTransaction(TrainsitionDTO trainsitionDTO);

    }
}
