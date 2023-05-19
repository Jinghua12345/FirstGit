using CommonLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserControls.Controls
{
    /// <summary>
    /// TestUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class TestUserControl : UserControl
    {
        public TestUserControl()
        {
            InitializeComponent();
        }

        public delegate void OnCylinderBackHandler();
        public event OnCylinderBackHandler OnCylinderBack;

        public delegate void OnCylinderOutHandler();
        public event OnCylinderOutHandler OnCylinderOut;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnCylinderBack?.Invoke();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OnCylinderOut?.Invoke();
        }
    }
}
