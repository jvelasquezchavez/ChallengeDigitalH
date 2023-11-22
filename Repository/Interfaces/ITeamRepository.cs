using Model.Entities;

namespace Repository.Interfaces
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetAllTeams();
        Team GetTeamById(int teamId);
        void AddTeam(Team team);
        void UpdateTeam(Team team);
        void DeleteTeam(int teamId);
    }
}
