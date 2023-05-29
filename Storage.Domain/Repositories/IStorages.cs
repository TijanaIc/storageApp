using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Domain.Repositories
{
    public interface IStorages
    {
        List<Storages> GetStorages();
        void DeleteStorage(int storageId);
        void InsertStorage(Storages s);
        void UpdateStorage(Storages s);
    }
}
