using Microsoft.EntityFrameworkCore;
using MVCCore_EmployeeManagementSystem.Models;
using MVCCore_EmployeeManagementSystem.Repository;

namespace MVCCore_EmployeeManagementSystem.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IRepository<Attendance> _repo;

        public AttendanceService(IRepository<Attendance> repo)
        {
            _repo = repo;
        }

        public async Task AddAttendanceAsync(Attendance attendance)
        {
            var existing = await _repo.FindAsync(a =>
                a.EmployeeId == attendance.EmployeeId && a.Date.Date == attendance.Date.Date
            );
            if (existing.Any())
            {
                throw new InvalidOperationException(
                    "Attendance already marked for this employee on this date."
                );
            }

            await _repo.AddAsync(attendance);
        }

        public async Task DeleteAttendanceAsync(int id) => await _repo.DeleteAsync(id);

        public async Task<IEnumerable<Attendance>> GetAllAttendancesAsync()
        {
            if (_repo is Repository<Attendance> attendanceRepo)
            {
                return await attendanceRepo.Table.Include(a => a.Employee).ToListAsync();
            }

            // Fallback
            return await _repo.GetAllAsync();
        }

        public async Task<Attendance> GetAttendanceByIdAsync(int id) =>
            await _repo.GetByIdAsync(id);

        public async Task UpdateAttendanceAsync(Attendance attendance) =>
            await _repo.UpdateAsync(attendance);
    }
}
