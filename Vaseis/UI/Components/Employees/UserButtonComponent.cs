
using System;

namespace Vaseis
{
    public class UserButtonComponent : DataButtonComponent
    {
        #region Public Properties

        /// <summary>
        /// The user
        /// </summary>
        public UserDataModel User { get; }

        #endregion

        #region Constructors

        /// <param name="user">The user</param>
        public UserButtonComponent(UserDataModel user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));

            Username = user.Username;
            FullName = user.FullName;
            Background = user.Department.Color.HexToBrush();
            Height = 150;
        }

        #endregion
    }
}
