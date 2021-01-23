﻿
using MaterialDesignThemes.Wpf;

using System;
using System.Windows;
using System.Windows.Controls;

namespace Vaseis
{
    public class UserButtonComponent : DataButtonComponent
    {
        #region Public Properties

        /// <summary>
        /// The user
        /// </summary>
        public UserDataModel User { get; }

        /// <summary>
        /// The tab control
        /// </summary>
        public TabControl TabControl { get; }

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="user">The user</param>
        public UserButtonComponent(UserDataModel user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));

            Username = user.Username;
            FullName = user.FullName;
            Background = user.Department.Color.HexToBrush();
            Height = 150;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="user">The user</param>
        public UserButtonComponent(UserDataModel user, TabControl tabControl)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            TabControl = tabControl ?? throw new System.ArgumentNullException(nameof(tabControl));

            Username = user.Username;
            FullName = user.FullName;
            Background = user.Department.Color.HexToBrush();
            Height = 150;

            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            UserButton.Click += new RoutedEventHandler((sender, e) =>
            {
                var tabItem = new TabItemComponent(TabControl)
                {
                    Text = User.Username,
                    Icon = PackIconKind.AccountCircle,
                    Content = new ProfilePage(User),
                };

                TabControl.Items.Add(tabItem);

            });
        }

        #endregion
    }
}
