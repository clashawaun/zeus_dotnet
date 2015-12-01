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
    /// The config.
    /// </summary>
    public class Config : IConfig
    {
        /// <summary>
        /// Gets or sets the system public key.
        /// </summary>
        public Key SystemPublicKey { get; set; }

        /// <summary>
        /// Gets or sets the system secret key.
        /// </summary>
        public Key SystemSecretKey { get; set; }
    }
}
