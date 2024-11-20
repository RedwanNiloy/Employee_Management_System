using EmployeeManagement.Entities;
using EmployeeManagement.Interfaces;
using Dapper;
using System.Data;

namespace EmployeeManagement.Repositories
{
    public class AttendenceRepo:IAttendenceRepo
    {
        private readonly IDatabaseConnectionFactory _connectionFactory;

        public AttendenceRepo(IDatabaseConnectionFactory connectionFactory)  
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddAttendanceAsync(AttendanceEntity attendance)
        {
            using var dbConnection = _connectionFactory.createConnection("pgs");

            var parameters = new DynamicParameters();
            parameters.Add("p_employee_id", attendance.EmployeeId);
            parameters.Add("p_check_in_time", attendance.CheckInTime);  // Timestamp without time zone
            parameters.Add("p_check_out_time", attendance.CheckOutTime);  // Timestamp without time zone
            parameters.Add("p_date", attendance.Date);  // Date type
            Console.WriteLine(attendance.CheckInTime);

            await dbConnection.ExecuteAsync("SELECT insert_attendance(@p_employee_id, @p_check_in_time, @p_check_out_time, @p_date)", parameters);
        }

            public async Task<IEnumerable<AttendanceEntity>> GetAttendanceAsync(int id)
        {
            using (var dbConnection = _connectionFactory.createConnection("pgs"))
            {
                const string query = "SELECT * FROM get_attendance_by_id(@p_employee_id);";

                //var parameters = new { p_employee_id = id };
                var parameters =  new DynamicParameters();
                parameters.Add("p_employee_id", id);

                return await dbConnection.QueryAsync<AttendanceEntity>(query, parameters);
            }
        }

        public async Task<IEnumerable<AttendanceEntity>> GetAllAttendanceAsync()
        {
            using (var dbConnection = _connectionFactory.createConnection("pgs"))
            {
                const string query = "SELECT * FROM get_all_attendance();";

                return await dbConnection.QueryAsync<AttendanceEntity>(query);
            }
        }
    }
}
