using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusServerSide.Entities
{
    public interface ISector
    {
        int Id { get; set; }
        ICollection<IItem> ItemsToProcess { get; set; }
        ICollection<IShelf> Shelves { get; set; }
        
    }
}
