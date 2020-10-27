using System.ComponentModel.DataAnnotations;

namespace RepositoryUnitOfWorkNoSql.Model
{
    public class User : Document
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public int age { get; set; }
    
    }
}