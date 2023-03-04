using calculadora.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace calculadora
{
    /// <summary>
    /// Lógica interna para PersistenciaContas.xaml
    /// </summary>
    public partial class PersistenciaContas : Window
    {
        
        public PersistenciaContas()
        {
            InitializeComponent();
        }
        private void btnToCloseW2_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.w2 = 0;
            Hide();
        }

        private void ApagarHistorico_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.context.Operations.ExecuteDelete();
            persistenciaContas.Text = "";
        }
    }
}