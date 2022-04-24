using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace AutoClicker3._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwDlags, int dx, int dy, int dwdata, int dweytrainfo);
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int num);

        bool Stop = true;
        static int parsedMinValue;
        static int parsedMaxValue;
        static Thread ClickThread = new Thread(Click);
        static Thread AskForKeyThread = new Thread(AskForKey);
        static ManualResetEvent ClickMre = new ManualResetEvent(false);
        static Random delayBetweenUpAndDown = new Random();
        static Random delayBetweenNewClick = new Random();
        static bool LeftClickActivated = false;
        static bool RightClickActivated = false;

        public enum Mouseeventflags
        {
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x00010
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            AskForKeyThread.Start();
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Accept_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(Max_Value_TextBox.Text, out parsedMaxValue) 
                || (Max_Value_TextBox.Text == null) 
                || (Convert.ToInt32(Max_Value_TextBox.Text) == 0))
            { 
                MessageBox.Show("Bitte nur Zahlen > 0 einfügen");
            }
            else if (!int.TryParse(Min_Value_TextBox.Text, out parsedMinValue) 
                || (Min_Value_TextBox.Text == null) 
                || (Convert.ToInt32(Min_Value_TextBox.Text) == 0))
            {
                MessageBox.Show("Bitte nur Zahlen > 0 einfügen");
            }
            else
            {
                parsedMaxValue = Convert.ToInt32(Max_Value_TextBox.Text);
                parsedMinValue = Convert.ToInt32(Min_Value_TextBox.Text);
                MessageBox.Show("Input successful");
            }
        }

        public static void Click()
        {
            while (true)
            {
                if(LeftClickActivated && !RightClickActivated)
                {
                    ClickMre.WaitOne();
                    mouse_event((int)(Mouseeventflags.LeftDown), 0, 0, 0, 0);
                    Thread.Sleep(delayBetweenUpAndDown.Next(10, 20));
                    mouse_event((int)(Mouseeventflags.LeftUp), 0, 0, 0, 0);
                    Thread.Sleep(delayBetweenNewClick.Next(parsedMinValue, parsedMaxValue));
                }
                if (RightClickActivated && !LeftClickActivated)
                {
                    ClickMre.WaitOne();
                    mouse_event((int)(Mouseeventflags.RightDown), 0, 0, 0, 0);
                    Thread.Sleep(delayBetweenUpAndDown.Next(10, 20));
                    mouse_event((int)(Mouseeventflags.RightUp), 0, 0, 0, 0);
                    Thread.Sleep(delayBetweenNewClick.Next(parsedMinValue, parsedMaxValue));
                }  
            }

        }

        public static void AskForKey()
        {
            while (true)
            {
                //Pause Thread F7
                if (GetAsyncKeyState(118) < 0)
                {
                    LeftClickActivated = false;
                    RightClickActivated = false;
                    ClickMre.Reset();                  
                }

                //Left Click F6
                if (GetAsyncKeyState(117) < 0)
                {
                    LeftClickActivated = true;
                    if(RightClickActivated)
                    {
                        RightClickActivated = false;
                    }
                    if (!ClickThread.IsAlive)
                    {
                        ClickThread.Start();
                    }
                    ClickMre.Set();
                }

                //Right Click F8
                if(GetAsyncKeyState(119) < 0)
                {
                    RightClickActivated = true;
                    if(LeftClickActivated) 
                    {
                        LeftClickActivated = false;
                    }
                    if (!ClickThread.IsAlive)
                    {
                        ClickThread.Start();
                    }
                    ClickMre.Set();
                }
              
                Thread.Sleep(30);

            }
        }
    }
}
