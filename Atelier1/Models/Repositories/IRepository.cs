namespace Atelier1.Models.Repositories
{
    public interface IRepository<Employee>
    {
        IList<Employee> GetAll();
        Employee FindByID(int id);
        void Add(Employee entity);
        void Update(int id, Employee entity);
        void Delete(int id);
        List<Employee> Search(string term);
        double SalaryAverage();
        double MaxSalary();
        int HrEmployeesCount();
    }
}
