using Model.Entities;

namespace Repository.Interfaces
{
    public interface IActivityRepository
    {
        IEnumerable<Activity> GetAllActivities();
        Activity GetActivityById(int activityId);
        void AddActivity(Activity activity);
        void UpdateActivity(Activity activity);
        void DeleteActivity(int activityId);
        IEnumerable<Activity> GetActivitiesByDateRange(DateTime startDate, DateTime endDate);
        IEnumerable<Activity> GetActivitiesByEmployeeId(int employeeId);
        IEnumerable<Activity> GetActivitiesByTeamId(int teamId);
    }
}
