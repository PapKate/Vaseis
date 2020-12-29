using MaterialDesignThemes.Wpf;

using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shell;
using System.Windows.Interop;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Vaseis
{
    class HeaderComponent : ContentControl
    {
        #region For Window

        private static IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:
                    WmGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
            }
            return (IntPtr)0;
        }

        private static void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
        {
            var mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));
            var MONITOR_DEFAULTTONEAREST = 0x00000002;
            var monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);
            if (monitor != IntPtr.Zero)
            {
                var monitorInfo = new MONITORINFO();
                GetMonitorInfo(monitor, monitorInfo);
                var rcWorkArea = monitorInfo.rcWork;
                var rcMonitorArea = monitorInfo.rcMonitor;
                mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.left - rcMonitorArea.left);
                mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.top - rcMonitorArea.top);
                mmi.ptMaxSize.x = Math.Abs(rcWorkArea.right - rcWorkArea.left);
                mmi.ptMaxSize.y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top);
            }
            Marshal.StructureToPtr(mmi, lParam, true);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            /// <summary>x coordinate of point.</summary>
            public int x;
            /// <summary>y coordinate of point.</summary>
            public int y;
            /// <summary>Construct a point of coordinates (x,y).</summary>
            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MONITORINFO
        {
            public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));
            public RECT rcMonitor = new RECT();
            public RECT rcWork = new RECT();
            public int dwFlags = 0;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
            public static readonly RECT Empty = new RECT();
            public int Width { get { return Math.Abs(right - left); } }
            public int Height { get { return bottom - top; } }
            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }
            public RECT(RECT rcSrc)
            {
                left = rcSrc.left;
                top = rcSrc.top;
                right = rcSrc.right;
                bottom = rcSrc.bottom;
            }
            public bool IsEmpty { get { return left >= right || top >= bottom; } }
            public override string ToString()
            {
                if (this == Empty) { return "RECT {Empty}"; }
                return "RECT { left : " + left + " / top : " + top + " / right : " + right + " / bottom : " + bottom + " }";
            }
            public override bool Equals(object obj)
            {
                if (!(obj is Rect)) { return false; }
                return (this == (RECT)obj);
            }
            /// <summary>Return the HashCode for this struct (not garanteed to be unique)</summary>
            public override int GetHashCode() => left.GetHashCode() + top.GetHashCode() + right.GetHashCode() + bottom.GetHashCode();
            /// <summary> Determine if 2 RECT are equal (deep compare)</summary>
            public static bool operator ==(RECT rect1, RECT rect2) { return (rect1.left == rect2.left && rect1.top == rect2.top && rect1.right == rect2.right && rect1.bottom == rect2.bottom); }
            /// <summary> Determine if 2 RECT are different(deep compare)</summary>
            public static bool operator !=(RECT rect1, RECT rect2) { return !(rect1 == rect2); }
        }

        [DllImport("user32")]
        internal static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

        [DllImport("User32")]
        internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);

        #endregion

        #region Protected Properties

        /// <summary>
        /// The title
        /// </summary>
        protected TextBlock TitleTextBlock { get; private set; }

        /// <summary>
        /// The location of the image
        /// </summary>
        protected Border ImageBorder { get; private set; }

        /// <summary>
        /// The image
        /// </summary>
        protected Image Image { get; private set; }

        #endregion

        #region Dependency Properties

        #region Title

        /// <summary>
        /// The title (empty or username)
        /// </summary>
        public string Title
        {
            get { return GetValue(TitleProperty).ToString(); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Title"/> dependency property
        /// </summary>
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(HeaderComponent));

        #endregion

        #region Image

        /// <summary>
        /// The path of the image
        /// </summary>
        public string ImagePath
        {
            get { return GetValue(ImagePathProperty).ToString(); }
            set { SetValue(ImagePathProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="ImagePath"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ImagePathProperty = DependencyProperty.Register(nameof(ImagePath), typeof(string), typeof(HeaderComponent), new PropertyMetadata(OnImagePathChanged));

        /// <summary>
        /// Handles the change of the <see cref="ImagePath"/> property
        /// </summary>
        private static void OnImagePathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as HeaderComponent;

            sender.OnImagePathChangedCore(e);
        }

        #endregion

        #endregion

        #region Protected Methods

        /// <summary>
        /// Handles the change of the <see cref="HeaderImageAndTitleComponent.ImagePath"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnImagePathChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion

        #region Constructors

        public HeaderComponent(Window window)
        {
            // Creates the GUI
            CreateGUI();
            // Set's window as the application's window if exists
            Window = window ?? throw new ArgumentNullException(nameof(window));

            Window.SourceInitialized += (s, e) =>
            {
                var handle = (new WindowInteropHelper(Window)).Handle;
                HwndSource.FromHwnd(handle).AddHook(new HwndSourceHook(WindowProc));
            };
        }

        #endregion

        /// <summary>
        /// The application's window
        /// </summary>
        public Window Window { get; }

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // The header's grid
            var headerGrid = new Grid()
            {
                // Has a dark blue color
                Background = StyleHelpers.HexToBrush(Styles.DarkBlue),
                // Height is set to auto
                Height = double.NaN
            };

            // A stack panel for the image and title 
            var imageAndTitleStackPanel = new StackPanel()
            {
                // Has horizontal orientation
                Orientation = Orientation.Horizontal,
            };

            // An image that fpr the Image property
            Image = new Image()
            {
                Margin = new Thickness(16, 8, 8, 8),
                Width = 40,
                Height = 40,
                HorizontalAlignment = HorizontalAlignment.Center,
                // Fills the area it's to
                Stretch = Stretch.Fill,
                // Clips the image to a circle
                Clip = new EllipseGeometry(new Point(20, 20), 20, 20),
            };

            // Add's to the left stack panel the image
            imageAndTitleStackPanel.Children.Add(Image);

            // A text block for the Title property
            var titleTextBlock = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = StyleHelpers.HexToBrush(Styles.GhostWhite),
                FontFamily = new FontFamily("Calibri"),
                FontWeight = FontWeights.Bold,
                FontStyle = FontStyles.Normal,
                FontSize = 28
            };

            // Binds the text property of the text block to the Title property
            titleTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Title))
            {
                Source = this
            });

            // Adds to the left stack panel the title text block
            imageAndTitleStackPanel.Children.Add(titleTextBlock);

            // Adds to the header's grid the stack panel with the image and title
            headerGrid.Children.Add(imageAndTitleStackPanel);

            // A text block for the application's name
            var appTitle = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(8),
                Foreground = StyleHelpers.HexToBrush(Styles.GhostWhite),
                FontFamily = new FontFamily("Calibri"),
                FontWeight = FontWeights.Bold,
                FontStyle = FontStyles.Normal,
                FontSize = 36,
                Text = "Courabiedes"
            };

            // Adds to the header the text block with the application's name
            headerGrid.Children.Add(appTitle);

            #region Control Buttons 

            // A stack panel for the control buttons positioned to the parent's top right
            var headerControlStackPanel = new StackPanel()
            {
                Height = headerGrid.Height,
                Width = headerGrid.Height,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Right,
                Orientation = Orientation.Horizontal
            };

            WindowChrome.SetIsHitTestVisibleInChrome(headerControlStackPanel, true);

            // Adds to the header's grid the control buttons' stack panel
            headerGrid.Children.Add(headerControlStackPanel);

            // Creates a flat button with a minimize window icon
            var minimizeButton = new Button()
            {
                Style = MaterialDesignStyles.FlatButton,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 50,
                Height = 50,
                Content = StyleHelpers.MaterialIcon(Styles.GhostWhite, PackIconKind.WindowMinimize)
            };

            // Creates flat a button with a maximize window icon
            var expandButton = new Button()
            {
                Style = MaterialDesignStyles.FlatButton,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 50,
                Height = 50,
                Content = StyleHelpers.MaterialIcon(Styles.GhostWhite, PackIconKind.WindowMaximize)
            };

            // Creates flat a button with a close window icon
            var closeButton = new Button()
            {
                Style = MaterialDesignStyles.FlatButton,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 50,
                Height = 50,
                Content = StyleHelpers.MaterialIcon(Styles.GhostWhite, PackIconKind.WindowClose),
                Background = Brushes.Transparent
            };

            // Adds to the right stack panel the minimize button
            headerControlStackPanel.Children.Add(minimizeButton);

            // Adds to the right stack panel the maximize button
            headerControlStackPanel.Children.Add(expandButton);

            // Adds to the right stack panel the close button
            headerControlStackPanel.Children.Add(closeButton);

            // If minimize button is clicked, minimize the application's window
            minimizeButton.Click += (s, e) => Window.WindowState = WindowState.Minimized;
            // If maximize button is clicked, maximize the application's window
            expandButton.Click += (s, e) => Window.WindowState = Window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            // If close button is clicked, terminate the application
            closeButton.Click += (s, e) => Window.Close();

            #endregion

            // Sets the ContentControl's content as the header's grid
            Content = headerGrid;
        }

        /// <summary>
        /// Handles the change of the <see cref="ImagePath"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnImagePathChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (string)e.NewValue;

            if (newValue == null)
            {
                Image.Source = null;
            }
            else
            {
                // Create the bitmap image
                var bitmapImage = new BitmapImage(new Uri(newValue));

                // Set it to the image
                Image.Source = bitmapImage;
            }

            // Further handle the change
            OnImagePathChanged(e);
        }

        #endregion
    }
}
