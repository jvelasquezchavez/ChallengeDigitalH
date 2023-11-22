using Model.Entities;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApplicationDbContext _context;

        public ActivityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddActivity(Activity activity)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();
        }

        public void DeleteActivity(int activityId)
        {
            var activity = _context.Activities.Find(activityId);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                _context.SaveChanges();
            }

        }

        public IEnumerable<Activity> GetActivitiesByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.Activities.Where(a => a.StartDate >= startDate && a.EndDate <= endDate).ToList();
        }

        public IEnumerable<Activity> GetActivitiesByEmployeeId(int employeeId)
        {
            return _context.Activities.Where(a => a.EmployeeId == employeeId).ToList();
        }

        public IEnumerable<Activity> GetActivitiesByTeamId(int teamId)
        {
            List<Employee> employeesInTeam = _context.Employees.Where(a => a.TeamId == teamId).ToList();
            List<int> employeeIds = employeesInTeam.Select(e => e.Id).ToList();
            return _context.Activities.Where(a => employeeIds.Contains(a.EmployeeId)).ToList();
        }

        public Activity GetActivityById(int activityId)
        {
            return _context.Activities.Find(activityId);
        }

        public IEnumerable<Activity> GetAllActivities()
        {
            return _context.Activities.ToList();
        }

        public void UpdateActivity(Activity activity)
        {
            _context.Activities.Update(activity);
            _context.SaveChanges();
        }
    }
}
