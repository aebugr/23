using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingGiftsBugrina.Interfaces
{
    public interface Icontext
    {
        void Save(bool Update = false);
        List<Classes.OrderContext> All();
        void Delete();
    }
}
