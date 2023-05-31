namespace Storage.Domain.Repositories
{
    public interface IStorageRepository
    {
        List<Storage> GetList();
        Storage GetById(int id);
        void DeleteById(int id);
        void Update(Storage s);
        Storage Insert(Storage s);
    }
}
