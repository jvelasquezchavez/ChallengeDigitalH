using Business.Interfaces;
using Model.Entities;
using Repository.Interfaces;

namespace Business.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITeamRepository _teamRepository;

        public ActivityService(IActivityRepository activityRepository, IEmployeeRepository employeeRepository, ITeamRepository teamRepository)
        {
            _activityRepository = activityRepository;
            _employeeRepository = employeeRepository;
            _teamRepository = teamRepository;
        }

        public void AddActivity(Model.Entities.Activity activity)
        {
            _activityRepository.AddActivity(activity);
        }

        public void DeleteActivity(int activityId)
        {
            _activityRepository.DeleteActivity(activityId);
        }

        public void GenerateEmployeeActivitiesReport(int employeeId, DateTime startDate, DateTime endDate)
        {
            var employee = _employeeRepository.GetEmployeeById(employeeId);
            if (employee == null)
            {
                throw new NotFoundException("Employee not found");
            }

            var activities = _activityRepository.GetActivitiesByEmployeeId(employeeId)
                .Where(a => a.StartDate >= startDate && a.EndDate <= endDate)
                .Select(a => new
                {
                    a.StartDate,
                    a.EndDate,
                    a.Description,
                    Duration = (a.EndDate - a.StartDate).TotalHours // Calcular la duración en horas, por ejemplo
                }).ToList();

            //TODO: método para imprimir reportes
        }

        public void GenerateTeamActivitiesReport(int teamId, DateTime startDate, DateTime endDate)
        {
            var team = _teamRepository.GetTeamById(teamId);
            if (team == null)
            {
                throw new NotFoundException("Team not found");
            }

            var activities = _activityRepository.GetActivitiesByTeamId(teamId)
                .Where(a => a.StartDate >= startDate && a.EndDate <= endDate)
                .Select(a => new
                {
                    a.StartDate,
                    a.EndDate,
                    a.Description,
                    Duration = (a.EndDate - a.StartDate).TotalHours // Calcular la duración en horas, por ejemplo
                }).ToList();


            //TODO: método para imprimir reportes
        }

        public IEnumerable<Activity> GetActivitiesByDateRange(DateTime startDate, DateTime endDate)
        {
            return _activityRepository.GetActivitiesByDateRange(startDate, endDate);
        }

        public IEnumerable<Activity> GetActivitiesByEmployeeId(int employeeId)
        {
            return _activityRepository.GetActivitiesByEmployeeId(employeeId);
        }

        public IEnumerable<Activity> GetActivitiesByTeamId(int teamId)
        {
            return _activityRepository.GetActivitiesByTeamId(teamId);
        }

        public Activity GetActivityById(int activityId)
        {
            return _activityRepository.GetActivityById(activityId);
        }

        public void UpdateActivity(Model.Entities.Activity activity)
        {
            _activityRepository.UpdateActivity(activity);
        }
    }
}
