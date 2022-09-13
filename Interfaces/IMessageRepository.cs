using DatingAppServer.DTos;
using DatingAppServer.Entities;
using PagedList;

namespace DatingAppServer.Interfaces
{
    public interface IMessageRepository
    {
        void AddMessage(Message message);
        void DeleteMessage(Message message);
        Task<Message> GetMessage(int id);
        Task<PagedList<MessageDto>> GetMessageForUser();

        Task<IEnumerable<MessageDto>> GetMessageThread(int currentUserId, int recipientId);
        Task<bool> SaveAllAsync();


    }
}
