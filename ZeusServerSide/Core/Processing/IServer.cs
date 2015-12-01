using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusServerSide.Utils;

namespace ZeusServerSide.Core.Processing
{
    public interface IServer
    {
        /// <summary>
        /// Gets or sets the config.
        /// </summary>
        IConfig Config { get; set; }

        /// <summary>
        /// The start server instance.
        /// </summary>
        void StartServerInstance();

        /// <summary>
        /// The start server instance.
        /// </summary>
        /// <param name="port">
        /// The port.
        /// </param>
        void StartServerInstance(object port);
    }
}
