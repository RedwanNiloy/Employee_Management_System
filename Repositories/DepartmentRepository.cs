using EmployeeManagement.Entities;
using EmployeeManagement.Interfaces;
using System.Data;
using Dapper;

namespace EmployeeManagement.Repositories
{
    public class DepartmentRepository(IDatabaseConnectionFactory connectionFactory) :IDepartmentRepository
    {
        private readonly IDatabaseConnectionFactory _connectionFactory=connectionFactory;
        

        public async Task<IEnumerable<Department>> GetAllDepartment() {
            using IDbConnection dbConnection = _connectionFactory.createConnection("sql");
            
            var dept  = await dbConnection.QueryAsync<Department>(
            "GetAllDept",
            commandType: CommandType.StoredProcedure);




            return dept;




        }
        //public Task<Department> GetDepartemtById(int id);
        public async Task AddDepartment(Department dept) {



            using (IDbConnection dbConnection = _connectionFactory.createConnection("sql"))
            {
                const string storedProcedureName = "AddDepartment"; // Assume this procedure exists in your DB

                var parameters = new DynamicParameters();
                parameters.Add("@name", dept.name);
                

                var id = await dbConnection.ExecuteScalarAsync(
                    storedProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                
            }






        }
        //void UpdateEmployee(EmployeeEntity employee);
        public async Task DeleteDepartment(int id)
        {

            using (IDbConnection dbConnection = _connectionFactory.createConnection("sql"))
            {
                const string storedProcedureName = "DeleteDept";
                var parameters = new DynamicParameters();
                parameters.Add("@dept_id", id);

                await dbConnection.ExecuteAsync(
                   storedProcedureName,
                   parameters,
                   commandType: CommandType.StoredProcedure
               );
            }


        }











    }
}
