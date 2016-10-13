using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay.Data.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual BillField BillField { get; set; }
    }
}
