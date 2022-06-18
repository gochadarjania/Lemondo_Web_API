using System.Collections.Generic;

namespace Lemondo_Web_Client.Models
{
    public class StatementViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageTitle { get; set; }
        public string ImageURL { get; set; }
        public StatementDetailViewModel StatementDetail { get; set; }
        public int StatementDetailId { get; set; }
        public List<string> ErrrorMessage { get; set; } = new List<string>();
    }
}
