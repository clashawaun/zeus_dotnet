using OrionWindows.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusServerSide.DataParsing;

namespace ZeusServerSide.Utils
{
    /// <summary>
    /// The Config interface.
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// Gets or sets the system public key.
        /// </summary>
        Key SystemPublicKey { get; set; }

        /// <summary>
        /// Gets or sets the system secret key.
        /// </summary>
        Key SystemSecretKey { get; set; }
    }
}
