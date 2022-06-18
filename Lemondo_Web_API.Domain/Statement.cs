using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemondo_Web_API.Domain
{
    public class Statement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }

        public StatementDetail StatementDetail { get; set; }
        public int StatementDetailId { get; set; }

    }
}
