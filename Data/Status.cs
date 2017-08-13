using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTDNA_Coding_Task.Data
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        [Column("Status")]
        public string StatusName { get; set; }
    }
}
