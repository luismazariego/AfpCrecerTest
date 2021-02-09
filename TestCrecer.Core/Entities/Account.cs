namespace TestCrecer.Core.Entities
{
    public class Account : BaseEntity
    {
        public string Company { get; set; }
        public double EmployeeSalary { get; set; }
        public double Interest { get; set; }
        public double Total { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}