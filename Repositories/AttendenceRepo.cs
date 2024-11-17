using EmployeeManagement.Entities;
using EmployeeManagement.Interfaces;
using Dapper;

namespace EmployeeManagement.Repositories
{
    public class AttendenceRepo:IAttendenceRepo
    {
        private readonly IDatabaseConnectionFactory _connectionFactory;

        public AttendenceRepo(IDatabaseConnectionFactory connectionFactory)  
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddAttendanceAsync(AttendanceEntity attendance)
        {
            using (var dbConnection = _connectionFactory.createConnection("pgs"))
            {
                const string query = "INSERT INTO attendance (employee_id, check_in_time, date) VALUES (@EmployeeId, @CheckInTime, @Date) RETURNING id;";
                var result = await dbConnection.ExecuteScalarAsync<int>(query, attendance);
                return result;
            }
        }

        public async Task<AttendanceEntity> GetAttendanceAsync(int id)
        {
            using (var dbConnection = _connectionFactory.createConnection("pgs"))
            {
                const string query = "SELECT * FROM attendance WHERE id = @Id";
                var result = await dbConnection.QuerySingleOrDefaultAsync<AttendanceEntity>(query, new { Id = id });
                return result;
            }
        }

        public async Task<IEnumerable<AttendanceEntity>> GetAllAttendanceAsync()
        {
            using (var dbConnection = _connectionFactory.createConnection("pgs"))
            {
                const string query = "SELECT * FROM attendance";
                var result = await dbConnection.QueryAsync<AttendanceEntity>(query);
                return result;
            }
        }
    }
}
