using System.ComponentModel.DataAnnotations;

namespace CExplorerService.lib.Models
{
    public class QuestionBase
    {
        [Key]
        public int Id { get; set; }

        public string Question { get; set; }
    }
}
