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
using DataAccessLayer;
using Model;

namespace Nagaychuk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<BottomElement> BotElements { get; set; }
        public List<BottomElement> TopElements { get; set; }
        public BottomElement SelectedBottomElement { get; set; }
        public Material SelectedBottomMaterial { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Repository rep = new Repository();
            BotElements = rep.GetAllBottomElements();
            botType.ItemsSource = BotElements;
            botType.DisplayMemberPath = "Name";
        }

        private void topMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void topType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void botType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedBottomElement = (BottomElement) botType.SelectedItem;
            botMaterial.ItemsSource = SelectedBottomElement.Materials;
            botMaterial.DisplayMemberPath = "NameOfMaterial";
        }

        private void botMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedBottomMaterial = (Material)botMaterial.SelectedItem;
            botSize.ItemsSource = SelectedBottomMaterial.SizeValues;
            botSize.DisplayMemberPath = "SizeValue";
        }
    }
}
