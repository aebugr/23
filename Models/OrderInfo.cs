using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingGiftsBugrina.Models
{
    public class OrderInfo
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Message { get; set; }
        public string Adress { get; set; }
        public DateTime Date { get; set; }
        public string Mail { get; set; }
    }
}
