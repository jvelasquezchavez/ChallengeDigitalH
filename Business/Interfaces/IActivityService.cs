using Model.Entities;

namespace Business.Interfaces
{
    public interface IActivityService
    {
        Activity GetActivityById(int activityId);
        IEnumerable<Activity> GetActivitiesByEmployeeId(int employeeId);
        IEnumerable<Activity> GetActivitiesByTeamId(int teamId);
        IEnumerable<Activity> GetActivitiesByDateRange(DateTime startDate, DateTime endDate);
        void AddActivity(Activity activity);
        void GenerateEmployeeActivitiesReport(int employeeId, DateTime startDate, DateTime endDate);
        void UpdateActivity(Activity activity);
        void GenerateTeamActivitiesReport(int teamId, DateTime startDate, DateTime endDate);
    }
}
