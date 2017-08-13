using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTDNA_Coding_Task.Data
{
    public class Sample
    {
        [Key]
        public int SampleId { get; set; }
        public string BarCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int StatusId { get; set; }

        [ForeignKey("CreatedBy")]
        public User User { get; set; }
        public Status Status { get; set; }
    }
}
