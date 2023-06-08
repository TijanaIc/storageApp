namespace Storage.Domain.BusnessLayer
{
    public interface IStateOfStorageService
    {
        List<StateOfStorage> GetStateOfStorageList();
        StateOfStorage GetStateOfStorageById(int id);
        void DeleteStateOfStorageById(int id);
        void UpdateStateOfStorage(StateOfStorage st);
        StateOfStorage InsertStateOfStorage(StateOfStorage st);
    }
}
