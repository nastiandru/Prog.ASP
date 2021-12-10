using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prog_Lab1.Models
{
    public class Tag
    {
        BlogItems = new HashSet<BlogItem>();
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public IColection<BlogItem> BlogItems { get; set; }

}
