using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay.Data.Entities
{
    public class Field
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual FieldType FieldType { get; set; }
        public virtual BillField BillField { get; set; }
    }
}
