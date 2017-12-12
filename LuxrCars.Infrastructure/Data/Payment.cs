using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxrCars.Infrastructure.Data
{
    public class Payment
    {
        public int PaymentID { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }

        public string Status { get; set; }

        public string Reference { get; set; }

        public string ReceiptNo { get; set; }

        public virtual Order Order { get; set; }
    }
}
