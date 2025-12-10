using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDolgozat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Dolgozat
    {
        public string Nev { get; set;}
        public int Eletkor { get; set;}
        public int Pontszam { get; set;}

        public Dolgozat(string nev, int eletkor, int pontszam)
        {
            Nev = nev;
            Eletkor = eletkor;
            Pontszam = pontszam;
        }
    }
    public partial class MainWindow : Window
    {
        public List <Dolgozat> dolgozatok=new List<Dolgozat> ();
        public MainWindow()
        {
            InitializeComponent();
            var sorok=File.ReadAllLines("dolgozatok.txt").Skip(1);
            foreach(var s in sorok)
            {
                string[] darabok = s.Split(';');
                string neve = darabok[0];
                int eletkora = Convert.ToInt32(darabok[1]);
                int pontszam = Convert.ToInt32(darabok[2]);
                dolgozatok.Add(new Dolgozat(neve,eletkora,pontszam));
            }
            dataGrid.ItemsSource = dolgozatok;
        }

        private void Hozzaadas(object sender, RoutedEventArgs e)
        {
            int eletkora;
            int pontszama;
            if(nevInput.Text.Length > 0 && int.TryParse(eletkorInput.Text,out eletkora) && eletkora >6&& int.TryParse(pontszamInput.Text, out pontszama) && pontszama < 101)
            {
                dolgozatok.Add(new Dolgozat(nevInput.Text, eletkora, pontszama));
                dataGrid.ItemsSource= dolgozatok;
                dataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Nem megfelelőek a beviteli adatok!");
            }
        }

        

        private void Mentes(object sender, RoutedEventArgs e)
        {

        }
    }
}