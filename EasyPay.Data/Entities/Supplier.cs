using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay.Data.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CommisionPercentage { get; set; }
        public virtual List<Bill> Bills { get; set; }
        public virtual List<Field> Fields { get; set; }
    }
}
