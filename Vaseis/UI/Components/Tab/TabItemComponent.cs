
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using MaterialDesignThemes.Wpf;
using System.Windows.Input;
using System;

namespace Vaseis
{
    public class TabItemComponent : TabItem
    {
        #region Dependency Properties

        #region Text

        /// <summary>
        /// The title
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(TabItemComponent));

        #endregion

        #region Icon

        /// <summary>
        /// The icon
        /// </summary>
        public PackIconKind Icon
        {
            get { return (PackIconKind)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Icon"/> dependency property
        /// </summary>
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof(Icon), typeof(PackIconKind), typeof(TabItemComponent));

        #endregion

        #region Close Command

        /// <summary>
        /// The close command
        /// </summary>
        public ICommand CloseCommand
        {
            get { return (ICommand)GetValue(CloseCommandProperty); }
            set { SetValue(CloseCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CloseCommandProperty = DependencyProperty.Register(nameof(CloseCommand), typeof(ICommand), typeof(TabItemComponent));

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public TabItemComponent()
        {

        }

        /// <summary>
        /// Tab control based constructor.
        /// NOTE
        /// </summary>
        /// <param name="tabControl">The tab control</param>
        public TabItemComponent(TabControl tabControl)
        {
            _ = tabControl ?? throw new ArgumentNullException(nameof(tabControl));

            // When fired removes the tab item 
            CloseCommand = new RelayCommand(() => tabControl.Items.Remove(this));
        }

        #endregion
    }
}
