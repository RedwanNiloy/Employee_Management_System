using EmployeeManagement.Entities;
using EmployeeManagement.Interfaces;
using System.Data;
using Dapper;

namespace EmployeeManagement.Repositories
{
    public class DesignationRepository:IDesignationRepository
    {

        private readonly IDatabaseConnectionFactory _connectionFactory;
        public DesignationRepository(IDatabaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        public async Task<IEnumerable<Designation>> GetAllDesignation()
        {

            using (IDbConnection dbConnection = _connectionFactory.createConnection("sql"))
            {
                const string storedProcedureName = "GetAllDesignation";
                var emp = await dbConnection.QueryAsync<Designation>(
                storedProcedureName,
                commandType: CommandType.StoredProcedure);




                return emp;





            }
        }


        public async Task AddDesignation(Designation dsg)
        {

            using (IDbConnection dbConnection = _connectionFactory.createConnection("sql"))
            {
                const string storedProcedureName = "AddDesignation"; // Assume this procedure exists in your DB

                var parameters = new DynamicParameters();
                parameters.Add("@name", dsg.name);
              
                

                var id = await dbConnection.ExecuteScalarAsync<int>(
                    storedProcedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                
            }


        }



        public async Task DeleteDesignation(int id)
        {

            using (IDbConnection dbConnection = _connectionFactory.createConnection("sql"))
            {
                const string storedProcedureName = "DeleteDesignation";
                var parameters = new DynamicParameters();
                parameters.Add("@dsg_id", id);

                await dbConnection.ExecuteAsync(
                   storedProcedureName,
                   parameters,
                   commandType: CommandType.StoredProcedure
               );
            }


        }















    }
}
