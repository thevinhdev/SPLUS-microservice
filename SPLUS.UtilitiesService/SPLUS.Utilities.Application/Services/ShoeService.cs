using SPLUS.Utilities.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLUS.Utilities.Application.Services
{
    public interface IShoeService
    {
        public Shoe GetShoeById(int id);
    }
    public class ShoeService : IShoeService
    {
        public Shoe GetShoeById(int id)
        {
            Shoe shoe = new()
            {
                Id = id,
                Brand = "abc",
                Name = "abc"
            };
            return shoe;
        }
    }
}
