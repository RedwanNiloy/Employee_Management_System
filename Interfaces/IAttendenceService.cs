using EmployeeManagement.Entities;

namespace EmployeeManagement.Interfaces
{
    public interface IAttendenceService
    {
        Task AddAttendanceAsync(AttendanceEntity attendance);
        Task<IEnumerable<AttendanceEntity>> GetAttendanceAsync(int id);

        Task<IEnumerable<AttendanceEntity>> GetAllAttendanceAsync();

    }
}
