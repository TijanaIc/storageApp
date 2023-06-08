namespace Storage.Domain.BusnessLayer
{
    public interface IStorageService
    {       
        List<Storage> GetStorageList();
        Storage GetStorageById(int id);
        void DeleteStorageById(int id);
        void UpdateStorage(Storage s);
        Storage InsertStorage(Storage s);
    }
}
