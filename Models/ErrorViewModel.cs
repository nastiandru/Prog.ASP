using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog_Lab1.Models
{
    public interface ICRUDBlogItemRepository
    {
        BlogItem Save(BlogItem item);

        void Delete(int id);

        BlogItem Update(BlogItem item);

        BlogItem FindById(int id);

        IList<BlogItem> FindAll();
    }
}
