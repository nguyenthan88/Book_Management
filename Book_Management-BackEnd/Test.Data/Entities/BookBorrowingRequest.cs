using Common.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test.Data.Entities
{
    public class BookBorrowingRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public int RequestByUserId { get; set; }

        public virtual User? RequestedBy { get; set; }

        public int ProcessedByUserId { get; set; }

        public virtual User? ProcessedBy { get; set; }

        public DateTime RequestedDate { get; set; }

        //[DefaultValue(RequestStatus.Waiting)]
        public int  Status { get; set; }

        public List<BookBorrowingRequestDetails>? Details { get; set; }
    }
}