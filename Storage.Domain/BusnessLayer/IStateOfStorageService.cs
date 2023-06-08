namespace Storage.Domain.BusnessLayer
{
    public interface IStateOfStorageService
    {
        List<StateOfStorage> GetList();
        StateOfStorage GetById(int id);
        void DeleteId(int id);
        void Update(StateOfStorage st);
        StateOfStorage Insert(StateOfStorage st);
    }
}
