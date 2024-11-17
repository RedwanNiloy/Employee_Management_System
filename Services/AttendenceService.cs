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

        public async Task<int> AddAttendanceAsync(AttendanceEntity attendance)
        {
            return await _attendanceRepository.AddAttendanceAsync(attendance);
        }

        public async Task<AttendanceEntity> GetAttendanceAsync(int id)
        {
            return await _attendanceRepository.GetAttendanceAsync(id);
        }

        public async Task<IEnumerable<AttendanceEntity>> GetAllAttendanceAsync()
        {
            return await _attendanceRepository.GetAllAttendanceAsync();
        }



    }
}
