using EmployeeManagement.Entities;
using EmployeeManagement.Interfaces;
using Microsoft.AspNetCore.Connections;
using System.Data;
using Dapper;
using System.Data.Common;

namespace EmployeeManagement.Repositories
{

    


    public class EmployeeRepository:IEmployeeRepository


    {

        private readonly IDatabaseConnectionFactory _connectionFactory;
        public EmployeeRepository(IDatabaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

       public async  Task<IEnumerable<EmployeeEntity>> GetAllEmployees() {

            using (IDbConnection dbConnection = _connectionFactory.createConnection("sql")) 
            {
                const string storedProcedureName = "dbo.GetAllEmployee";
                var emp= await dbConnection.QueryAsync<EmployeeEntity>(
                storedProcedureName,
                commandType: CommandType.StoredProcedure);

                


                return emp; 





            }






        }
       public async Task< EmployeeEntity> GetEmployeeById(int id) {


            using (IDbConnection dbConnection = _connectionFactory.createConnection("sql"))
            {
                const string storedProcedureName = "GetEmployeeByID"; // Assume this procedure exists in your DB

                var parameters =new  DynamicParameters();
                parameters.Add("@employeeId", id);

                return await dbConnection.QueryFirstOrDefaultAsync<EmployeeEntity>(
                    storedProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }







        }
       public async Task<int> AddEmployee(EmployeeEntity employee) {

            using (IDbConnection dbConnection = _connectionFactory.createConnection("sql"))
            {
                const string storedProcedureName = "dbo.AddEmployee"; // Assume this procedure exists in your DB

                var parameters = new DynamicParameters();
                parameters.Add("@name", employee.name);
                parameters.Add("@email", employee.email);
                parameters.Add("@address", employee.address);
                parameters.Add("@dob", employee.dob);
                parameters.Add("@dept_id", employee.dept_id);
                parameters.Add("@dsg_id", employee.dsg_id);

                var id= await dbConnection.ExecuteScalarAsync<int>(
                    storedProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return id;
            }


        }
        void UpdateEmployee(EmployeeEntity employee) { }
        public async Task DeleteEmployee(int id) {

            using (IDbConnection dbConnection = _connectionFactory.createConnection("sql"))
            {
                const string storedProcedureName = "DeleteEmpByID"; 
                var parameters = new DynamicParameters();
                parameters.Add("@empID", id);

                 await dbConnection.ExecuteAsync(
                    storedProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }






        }



    }
}
