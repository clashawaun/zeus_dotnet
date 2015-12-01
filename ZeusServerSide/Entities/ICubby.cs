using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusServerSide.Entities
{
    public interface ICubby
    {
        int Id { get; set; }
        int Height { get; set; }
        int Width { get; set; }
        int Depth { get; set; }
        ICollection<IItem> Items { get; set; }
    }
}
