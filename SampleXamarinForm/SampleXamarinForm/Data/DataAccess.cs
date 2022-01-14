using SampleXamarinForm.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace SampleXamarinForm.Data
{
    public class DataAccess
    {
        private SQLiteConnection db;
        public SQLiteConnection GetConnection()
        {
            var dbName = "MyDb.db3";
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, dbName);
            var sqlConn = new SQLiteConnection(dbPath);
            return sqlConn;
        }
        public DataAccess()
        {
            db = GetConnection();
            db.CreateTable<Employee>();
        }

        public int InsertEmployee(Employee emp)
        {
            var result = db.Insert(emp);
            return result;
        }

        public Employee GetById(int id)
        {
            var result = (from e in db.Table<Employee>()
                          where e.EmployeeId == id
                          select e).FirstOrDefault();
            return result;
        }

        public IEnumerable<Employee> GetAll()
        {
            //var results = db.Query<Employee>("select * from Employee order by EmpName");
            var results = from e in db.Table<Employee>()
                          orderby e.EmployeeName ascending
                          select e;

            return results;
        }

        public int UpdateEmployee(Employee emp)
        {
            var updateEmp = GetById(emp.EmployeeId);
            if (updateEmp == null)
                throw new Exception("Data employee tidak ditemukan");
            var result = db.Update(emp);
            return result;
        }

        public int DeleteEmployee(Employee emp)
        {
            var deleteEmp = GetById(emp.EmployeeId);
            if (deleteEmp == null)
                throw new Exception("Data employee tidak ditemukan");
            var result = db.Delete(emp);
            return result;
        }
    }
}
