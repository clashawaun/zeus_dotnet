using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusEntities.Type;

namespace ZeusServerSide.Entities
{
    /// <summary>
    /// The user factory.
    /// </summary>
    public static class UserFactory
    {
        /// <summary>
        /// The get user.
        /// </summary>
        /// <param name="userType">
        /// The user type.
        /// </param>
        /// <returns>
        /// The <see cref="User"/>.
        /// </returns>
        public static User GetUser(UserType userType)
        {
            switch (userType)
            {
                case UserType.Picker:
                {
                    return new Picker();
                }   
                
                case UserType.Packer:
                {
                    return new Packer();
                }

                case UserType.Stocker:
                {
                    return new Stocker();
                }

                case UserType.Manager:
                {
                   return new Manager(); 
                }

                case UserType.Customer:
                {
                    return new Customer();
                }

                default:
                {
                    return null;
                }
            }
        }    
    }
}
