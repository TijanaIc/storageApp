using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Domain
{
    public class StateOfStorage
    {
        public int StateOfStorageId { get; set; }
        public int ProductId { get; set; }
        public int StorageId { get; set; }
        public int Quantity { get; set; }
    }
}
