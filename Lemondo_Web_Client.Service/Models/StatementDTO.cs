using System.Collections.Generic;

namespace Lemondo_Web_Client.Service
{
    public class StatementDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public StatementDetailDTO StatementDetail { get; set; }
        public int StatementDetailId { get; set; }
        public List<string> ErrrorMessage { get; set; } = new List<string>();
    }
}
