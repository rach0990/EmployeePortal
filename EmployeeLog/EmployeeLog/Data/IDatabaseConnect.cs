using EmployeeLog.Models;

namespace EmployeeLog.Data
{
    public interface IDatabaseConnect
    {
        string CreateUser(Account acc);
        bool IsEmployer(Account acc);
        string Verify(Account acc);
    }
}