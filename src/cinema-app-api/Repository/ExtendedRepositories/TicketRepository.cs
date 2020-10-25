using cinema_app_api.Models;

namespace cinema_app_api.Repository.ExtendedRepositories
{
    public interface ITicketRepository : IBaseCrudService<Tickets>
    {
        public bool CheckIfFree(int x, int y);
        public bool CheckIfCanUpdate(int x, int y, string id);
    }
}