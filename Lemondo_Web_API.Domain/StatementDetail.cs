using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemondo_Web_API.Domain
{
    public class StatementDetail
    {
        [ForeignKey("Statement")]
        public int StatementDetailId { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }

    }
}
