﻿using DatingAppServer.DTos;
using DatingAppServer.Entities;
using DatingAppServer.Interfaces;
using System.Fabric.Query;

namespace DatingAppServer.Data
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _context;

        public MessageRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddMessage(Message message)
        {
            _context.Messages.Add(message);
        }

        public void DeleteMessage(Message message)
        {
            _context.Messages.Remove(message);
        }

        public async Task<Message> GetMessage(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public Task<PagedList<MessageDto>> GetMessageForUser()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MessageDto>> GetMessageThread(int currentUserId, int recipientId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
