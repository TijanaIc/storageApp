namespace Storage.Domain.Repositories
{
    public interface IStorageRepository
    {
        List<Storage> GetList();
        Storage GetById(int id);
        //void Delete(int id);
        //void Insert(Storage s);
        //void Update(Storage s);
    }
}
