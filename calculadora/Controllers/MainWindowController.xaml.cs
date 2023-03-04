using calculadora.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace calculadora
{

    public partial class MainWindow : Window
    {
        string resultadoConvertido = "";
        string resultado = "";
        public static PersistenciaContas TelaBanco = new();
        public static int w2 = 0;
        bool contaFeita = false;

        public static ContextModels context;



        public MainWindow(ContextModels context_arg)
        {
            context = context_arg;
            var OperationList = context.Operations.ToList();
            foreach (var Operation in OperationList)
            {
                TelaBanco.persistenciaContas.AppendText(Operation.Text + "\n");
            }

            InitializeComponent();


        }

        private void btnAdicao_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("+");
        }

        private void btnSubtracao_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("-");
        }

        private void btnMultiplicacao_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("x");
        }

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("÷");
        }

        private void btnPorcentagem_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("%");
        }

        private void btnRaizQuadrada_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("^0.5");
        }

        private void btnParentesesDireita_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("(");
        }

        private void btnParentesesEsquerda_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText(")");
        }
        private void btnZero_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("0");
        }
        private void btnUm_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("1");
        }
        private void btnDois_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("2");
        }

        private void btnTres_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("3");
        }
        private void btnQuatro_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("4");
        }
        private void btnCinco_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("5");
        }

        private void btnSeis_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("6");
        }
        private void btnSete_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("7");
        }
        private void btnOito_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("8");
        }

        private void btnNove_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("9");
        }
        private void btnPonto_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText(".");
        }

        private void btnLn_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("ln");
        }

        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("log");
        }

        private void btnExp_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("^");
        }
        private void btnPi_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("pi");
        }
        private void btnSeno_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("sen");
        }

        private void btnCos_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("cos");
        }
        private void btnExponenciacao_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("exp");
        }
        private void btnFatorial_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("fact");
        }
        private void btnMod_Click(object sender, RoutedEventArgs e)
        {
            LimparContasAnteriores();
            boxContas1.AppendText("mod");
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            if (w2 == 0)
            {
                this.WindowState = WindowState.Minimized;
            }
        }

        private void btnDotsIcon_Click(object sender, RoutedEventArgs e)
        {

            if (w2 == 0)
            {
               
                TelaBanco.Show();
                w2 = 1;
            }
        }

        private void btnIgual_Click(object sender, RoutedEventArgs e)
        {

            string conta = boxContas1.Text;
            labelContas.Content = boxContas1.Text + " =";

            OperationModels op = new OperationModels
            {
                Id = Guid.NewGuid(),
                Text = conta,
                CreationTime = DateTime.Now,
            };
            context.Operations.Add(op);
            context.SaveChanges();

           
            //var OperationList = context.Operations.ToList();
            //TelaBanco.persistenciaContas.AppendText(OperationList[OperationList.Count-1].Text);

            NoModels raiz = new NoModels();
            string formatted = conta;
            do
            {
                formatted = InfixTreeRepositoriesModels.format(formatted);

            } while (!InfixTreeRepositoriesModels.isFormatted(formatted));

            InfixTreeModels.build(formatted, ref raiz);
            InfixTreeModels.calculate(ref raiz);
            
            boxContas1.Text = raiz.number.ToString();
            resultado = raiz.number.ToString();
            TelaBanco.persistenciaContas.AppendText(conta + " = " + resultado + "\n");
            contaFeita = true;
            InserirOperacaoExibicao();

            
        }

        private void backspace_Click(object sender, RoutedEventArgs e)
        {
            if (boxContas1.Text.Length > 0)
            {
                var text = boxContas1.Text;
                boxContas1.Text = text.Remove(text.Length - 1);
            }
        }
        private void btnErase_Click(object sender, RoutedEventArgs e)
        {
            boxContas1.Text = "";
            labelContas.Content = "";
        }
        private void LimparContasAnteriores()
        {
            if (contaFeita)
            {
                boxContas1.Text = "";
                labelContas.Content = "";
                resultadoConvertido = "";
                contaFeita = false;
            }
        }
        public void InserirOperacaoExibicao()
        {

            if(!boxContas1.Text.Equals(""))
            {
                string resultadoExibicao = labelContas.Content + " " + resultado + "\n";
                TelaBanco.exibicaoContas.AppendText(resultadoExibicao);
            }

        }

        public void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.ChangedButton == MouseButton.Left)
            //{
            //    MainWindow primeiraTela = new MainWindow();
            //    this.DragMove();
            //}
            //if (w2 == 1)
            //{
            //    Configs Mover2 = new();
            //    Mover2.segundaTela_MouseDown(sender, e);


            //}
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }

       
    }
}
