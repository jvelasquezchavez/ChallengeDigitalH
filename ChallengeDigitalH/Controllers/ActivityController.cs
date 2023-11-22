using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;

namespace ChallengeDigitalH.Controllers
{
    [ApiController]
    [Route("api/activities")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet("employee/{employeeId}")]
        public IActionResult GetActivitiesByEmployeeId(int employeeId)
        {
            var activities = _activityService.GetActivitiesByEmployeeId(employeeId);
            return Ok(activities);
        }

        [HttpPost]
        public IActionResult CreateActivity(Activity activity)
        {
            _activityService.AddActivity(activity);
            return CreatedAtAction("GetActivityById", new { activityId = activity.Id }, activity);
        }

        [HttpPut("{activityId}")]
        public IActionResult UpdateActivity(int activityId, Activity activity)
        {
            var existingActivity = _activityService.GetActivityById(activityId);
            if (existingActivity == null)
                return NotFound();

            activity.Id = activityId;
            _activityService.UpdateActivity(activity);
            return NoContent();
        }

        [HttpGet("report/employee/{employeeId}")]
        public IActionResult GetEmployeeActivitiesReport(int employeeId, DateTime startDate, DateTime endDate)
        {
            _activityService.GenerateEmployeeActivitiesReport(employeeId, startDate, endDate);
            return Ok();
        }

        // Método para generar un reporte de actividades de un equipo en un rango de tiempo
        [HttpGet("report/team/{teamId}")]
        public IActionResult GetTeamActivitiesReport(int teamId, DateTime startDate, DateTime endDate)
        {
            _activityService.GenerateTeamActivitiesReport(teamId, startDate, endDate);
            return Ok();
        }

        [HttpDelete("{activityId}")]
        public IActionResult DeleteActivity(int activityId)
        {
            try
            {
                _activityService.DeleteActivity(activityId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar la actividad: {ex.Message}");
            }
        }
    }
}