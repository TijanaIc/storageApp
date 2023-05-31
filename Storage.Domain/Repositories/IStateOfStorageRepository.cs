namespace Storage.Domain.Repositories
{
    public interface IStateOfStorageRepository
    {
        List<StateOfStorage> GetList();
        StateOfStorage GetById(int id);
        //void Delete(int id);
        //void Insert(StateOfStorage st);
        //void Update(StateOfStorage st);
    }
}
