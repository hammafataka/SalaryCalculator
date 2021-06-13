using SQLite;

namespace SalaryCalculator.Models
{
    [Table("SalaryDb")]
    public class SalaryInfo
    {
        [PrimaryKey]
        [NotNull]
        [AutoIncrement]
        public int id { get; set; }
        public int PerHour { get; set; }
        public int Hours { get; set; }
        public int  Days { get; set; }
        public int Total { get; set; }

    }
}
