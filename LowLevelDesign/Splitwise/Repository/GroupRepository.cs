using Splitwise.Models;
using System.Runtime.InteropServices;

namespace Splitwise.Repository
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        private Dictionary<long, Group> groupRepo;
        private static long lastId = 1;
        public GroupRepository(AppDBContext context) : base(context)
        {
        }

        public override Group Add(Group entity)
        {
            entity.Id = lastId++;
            groupRepo[entity.Id] = entity;
            return entity;
        }

        public override Group GetById(long id)
        {
            return groupRepo.TryGetValue(id, out var entity) ? entity : null;
        }
    }
}
