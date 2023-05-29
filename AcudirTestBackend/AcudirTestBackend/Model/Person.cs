using System.ComponentModel.DataAnnotations;

namespace AcudirTestBackend.Model
{
    public partial class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string documentNumber { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public bool isDeleted { get; set; }

    }
}
