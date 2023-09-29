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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tema2_CalculadoraBasica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComprobarOperador(object sender, TextChangedEventArgs e)
        {
            CalcularButton.IsEnabled = OperadorTextBox.Text switch
            {
                "*" or "+" or "-" or "/" => true,
                _ => false
            };
        }

        private void Limpiar(object sender, RoutedEventArgs e) => PrimerNumeroTextBox.Text = SegundoNumeroTextBox.Text = OperadorTextBox.Text = ResultadoTextBox.Text = "";

        private void Calcular(object sender, RoutedEventArgs e)
        {
            try
            {
                int primerNumero = int.Parse(PrimerNumeroTextBox.Text);
                int segundoNumero = int.Parse(SegundoNumeroTextBox.Text);

                int resultado = OperadorTextBox.Text switch
                {
                    "+" => primerNumero + segundoNumero,
                    "-" => primerNumero - segundoNumero,
                    "*" => primerNumero * segundoNumero,
                    "/" => primerNumero / segundoNumero
                };
                ResultadoTextBox.Text = resultado.ToString();
            } catch (Exception ex)
            {
                MessageBox.Show($"Se ha producido una excepción al tratar de realizar la operación:\n{ex}");
            }
        }
    }
}
