using MvvmCross.Platforms.Wpf.Views;
using System.Windows;
using System.Windows.Input;
using System.Globalization;
using System.Configuration;
using System.Threading;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Localization;
using System.Windows.Controls;
using System.Xml.Linq;
using System.Linq;
using System;
using System.Windows.Markup;

namespace Inventory.WPF.Views
{
    /// <summary>
    /// Lógica de interacción para TipView.xaml
    /// </summary>
    public partial class Login : MvxWpfView
    {
        public Login()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //DragMove();
        }
        void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void CBLang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(CBLang.SelectedValue.ToString());
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(CBLang.SelectedValue.ToString());
            }
            catch(Exception)
            {
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            }
            LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement), 
                new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag))
            );
        }
    }
}
