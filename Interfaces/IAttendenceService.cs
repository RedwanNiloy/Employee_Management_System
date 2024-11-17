using EmployeeManagement.Entities;

namespace EmployeeManagement.Interfaces
{
    public interface IAttendenceService
    {
        Task<int> AddAttendanceAsync(AttendanceEntity attendance);
        Task<AttendanceEntity> GetAttendanceAsync(int id);

        Task<IEnumerable<AttendanceEntity>> GetAllAttendanceAsync();

    }
}
