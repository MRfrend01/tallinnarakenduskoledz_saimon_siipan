using System.ComponentModel.DataAnnotations;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Models
{
    public enum violations { nikotiin, Vandaliseerimine, Magamine, Mängimine, söömine,}
    public class Delinquent
    {
        [Key]
        public int DelinquentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public violations Violation { get; set; }
        public string situation { get; set; }
        public string TeacherOrStudent { get; set; }

    }
}

