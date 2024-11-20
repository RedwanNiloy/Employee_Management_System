using EmployeeManagement.Entities;
using EmployeeManagement.Interfaces;

namespace EmployeeManagement.Services
{
    public class AttendenceService:IAttendenceService
    {

        private readonly IAttendenceRepo _attendanceRepository;

        public AttendenceService(IAttendenceRepo attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task AddAttendanceAsync(AttendanceEntity attendance)
        {
             await _attendanceRepository.AddAttendanceAsync(attendance);
        }

        public async Task<IEnumerable<AttendanceEntity>> GetAttendanceAsync(int id)
        {
            return await _attendanceRepository.GetAttendanceAsync(id);
        }

        public async Task<IEnumerable<AttendanceEntity>> GetAllAttendanceAsync()
        {
            return await _attendanceRepository.GetAllAttendanceAsync();
        }



    }
}
