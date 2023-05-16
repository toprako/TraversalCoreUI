using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public Guid CommentId { get; set; }
        public string NameSurname { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public bool State { get; set; }
        public Guid DestinationID { get; set; }
        public Destination Destination { get; set; }
    }
}
