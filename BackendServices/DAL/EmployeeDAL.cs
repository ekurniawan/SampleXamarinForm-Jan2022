using BackendServices.Models;
using System.Data.SqlClient;

namespace BackendServices.DAL
{
    public class EmployeeDAL : IEmployee
    {
        private IConfiguration _config;
        public EmployeeDAL(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnStr()
        {
            return _config.GetConnectionString("DefaultConnection");
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Employees 
                                  order by EmployeeName asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        employees.Add(new Employee
                        {
                            EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                            EmployeeName = dr["EmployeeName"].ToString(),
                            Email = dr["Email"].ToString(),
                            Department = dr["Department"].ToString(),
                            Qualification = dr["Qualification"].ToString()
                        });
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return employees;
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Employee Insert(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee Update(int id, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
