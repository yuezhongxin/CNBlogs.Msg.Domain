using CNBlogsMsg.Domain.ValueObject;
using System.Threading.Tasks;

namespace CNBlogsMsg.Domain.Repositories
{
    public interface IContactRepository
    {
        Task<Contact> GetContactByLoginName(string loginName);

        Task<Contact> GetContactByDisplayName(string displayName);

        Task<Contact> GetContactBySpaceUserId(int spaceUserId);
    }
}
