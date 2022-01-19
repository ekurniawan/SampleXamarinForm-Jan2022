using BackendServices.Models;
using System.Data.SqlClient;
using Dapper;

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
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"delete from Employees where EmployeeId=@EmployeeId";
                var param = new { EmployeeId = id };
                try
                {
                    conn.Execute(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
            }
        }
        public IEnumerable<Employee> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Employees 
                                  order by EmployeeName asc";
                var results = conn.Query<Employee>(strSql);
                return results;
            }
        }
        
        /*public IEnumerable<Employee> GetAll()
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
        }*/

        public Employee GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Employees 
                                  where EmployeeId=@EmployeeId";
                var param = new { EmployeeId = id };
                var result = conn.QuerySingleOrDefault<Employee>(strSql,param);
                return result;
            }
        }

        /*public Employee GetById(int id)
        {
            Employee employee = new Employee();
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Employees 
                                  where EmployeeId=@EmployeeId";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("EmployeeId", id);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    employee.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                    employee.EmployeeName = dr["EmployeeName"].ToString();
                    employee.Email = dr["Email"].ToString();
                    employee.Department = dr["Department"].ToString();
                    employee.Qualification = dr["Qualification"].ToString();
                }
                else
                {
                    employee = null;
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return employee;
        }*/

        public void Insert(Employee employee)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into Employees(EmployeeName,Email,Qualification,Department) 
                                  values(@EmployeeName,@Email,@Qualification,@Department)";
                var param = new
                {
                    EmployeeName = employee.EmployeeName,
                    Email = employee.Email,
                    Qualification = employee.Qualification,
                    Department = employee.Department
                };
                try
                {
                    var result = conn.Execute(strSql, param);
                    if (result != 1)
                        throw new Exception("Gagal untuk insert employee data");
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
            }
        }

        public void Update(int id, Employee employee)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                var updateEmployee = GetById(id);
                if (updateEmployee == null)
                    throw new Exception("Data tidak ditemukan");

                var strSql = @"update Employees set EmployeeName=@EmployeeName,Email=@Email,
                Qualification=@Qualification,Department=@Department 
                where EmployeeId=@EmployeeId";

                var param = new
                {
                    EmployeeName = employee.EmployeeName,
                    Email = employee.Email,
                    Qualification = employee.Qualification,
                    Department = employee.Department,
                    EmployeeId = id
                };

                try
                {
                    var result = conn.Execute(strSql, param);
                    if (result != 1)
                        throw new Exception("Data gagal diupdate");
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
            }
        }

        public IEnumerable<ViewEmployeeAddress> GetAllEmployeeWithAddress()
        {
            throw new NotImplementedException();
        }
    }
}
