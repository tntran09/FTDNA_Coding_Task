using System.ComponentModel.DataAnnotations;

namespace FTDNA_Coding_Task.Data
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
