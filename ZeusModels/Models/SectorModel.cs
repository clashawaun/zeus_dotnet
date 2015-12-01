using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusModels.Models
{
    /// <summary>
    /// The sector model.
    /// </summary>
    public class SectorModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the shelves.
        /// </summary>
        public ICollection<ShelfModel> Shelves { get; set; } 
    }
}
