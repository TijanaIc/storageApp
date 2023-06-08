namespace Storage.Domain.BusnessLayer
{
    public interface IStorageService
    {       
        List<Storage> GetList();
        Storage GetById(int id);
        void DeleteById(int id);
        void Update(Storage s);
        Storage Insert(Storage s);
    }
}
