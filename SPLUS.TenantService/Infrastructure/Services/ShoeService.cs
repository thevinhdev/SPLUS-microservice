using Core.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IShoeService
    {
        Task<Shoe> GetByIdAsync(int id);
    }
    public class ShoeService : IShoeService
    {
        private readonly ApplicationDbContext _context;

        public ShoeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Shoe> GetByIdAsync(int id)
        {
            return await _context.Shoes.FindAsync(id);
        }
    }
}
