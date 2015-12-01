using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeusEntities.State
{
    /// <summary>
    /// The item state.
    /// </summary>
    public enum ItemState
    {
        /// <summary>
        /// The awaiting stocker.
        /// </summary>
        AwaitingStocker,

        /// <summary>
        /// The pending stocking.
        /// </summary>
        PendingStocking,

        /// <summary>
        /// The available.
        /// </summary>
        Available,

        /// <summary>
        /// The awaiting picker.
        /// </summary>
        AwaitingPicker,

        /// <summary>
        /// The awaiting check in.
        /// </summary>
        AwaitingCheckIn,

        /// <summary>
        /// The a waiting packer.
        /// </summary>
        AwaitingPacker,

        /// <summary>
        /// The packed.
        /// </summary>
        Packed,

        /// <summary>
        /// The shipped.
        /// </summary>
        Shipped
    }
}
