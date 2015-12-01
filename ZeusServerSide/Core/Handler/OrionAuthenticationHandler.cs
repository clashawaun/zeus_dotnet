using OrionWindows.Entities.Authentication;
using OrionWindows.Entities.User;
using OrionWindowsDesktop;
using OrionWindowsDesktop.Logging;
using OrionWindowsDesktop.Authenticator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.Communication;
using ZeusEntities.Type;
using ZeusServerSide.DataParsing;
using ZeusServerSide.Entities;
using ZeusServerSide.Utils;

namespace ZeusServerSide.Core.Handler
{
    /// <summary>
    /// The orion authentication handler.
    /// </summary>
    public class OrionAuthenticationHandler : IHandler
    {
        /// <summary>
        /// Gets or sets the successor.
        /// </summary>
        public IHandler Successor { get; set; }

        /// <summary>
        /// Gets or sets the config.
        /// </summary>
        public IConfig Config { get; set; }

        /// <summary>
        /// The handle request.
        /// </summary>
        /// <param name="request">
        /// The requst.
        /// </param>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        
        public async Task HandleRequest(IServerMessage request, IServerMessage response)
        {
            var userOrionKey = ParserFactory.GetDataParser(request.DataType).ParseData<Key>(request.User);
            if (userOrionKey == null)
            {
                // Do something here to stop processing and return some error to the server to 
                // inform the client that auth has failed.
                request.User = null;
                await this.Successor.HandleRequest(request, response);
            }

            var orionContext = new Orion(new DeleteMeLogger())
            {
                Communicator =
                {
                    ApiAuthenticator = new OrgStandardAuthenticator()
                    {
                        PublicKey = this.Config.SystemPublicKey,
                        SecertKey = this.Config.SystemSecretKey
                    }
                }
            };

            // Set the authentication Information
            var user = await orionContext.CreateUserController().GetUserProfile(userOrionKey, "Zeus");
            if (user?.Result?.Meta == null || !user.Result.Meta.Any(x => x.Key.Equals("UserType")))
            {
                request.User = null;
            }
            else
            {
                // Parse the Orion user data into local user data
                var firstOrDefault = user.Result.Meta.FirstOrDefault(x => x.Key.Equals("UserType"));
                if (firstOrDefault != null)
                {
                    var parsedUser =
                        UserFactory.GetUser(
                            (UserType)
                                (Convert.ToInt32(firstOrDefault.Value)));
                    parsedUser.Email = user.Result.Email;
                    parsedUser.Firstname = user.Result.Firstname;
                    parsedUser.Surname = user.Result.Surname;
                    parsedUser.Phone = user.Result.Phone;
                    request.User = ParserFactory.GetDataParser(request.DataType).SerializeData(parsedUser);
                }
            }

            // Check the user type which should be contained in User Meta.
            await this.Successor.HandleRequest(request, response);

        }
    }
}
