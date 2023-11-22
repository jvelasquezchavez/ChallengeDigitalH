using Model.Entities;
using Repository.Interfaces;


namespace Repository.Repositories
{
    public class TeamRepository: ITeamRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public void DeleteTeam(int teamId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Team> GetAllTeams()
        {
            throw new NotImplementedException();
        }

        public Team GetTeamById(int teamId)
        {
            throw new NotImplementedException();
        }

        public void UpdateTeam(Team team)
        {
            throw new NotImplementedException();
        }
    }
}
