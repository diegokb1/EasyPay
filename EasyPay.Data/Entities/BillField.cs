using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay.Data.Entities
{
    public class BillField
    {
        public int Id { get; set; }
        public String Value { get; set; }
        public virtual List<Bill> Bills { get; set; }
        public virtual List<Field> Fields { get; set; }
    }
}
