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
        public List<TopElement> TopElements { get; set; }
        public List<BottomElement> BotElements { get; set; }
        public List<Penal> Penals { get; set; }


        public TopElement SelectedTopElement { get; set; }
        public BottomElement SelectedBottomElement { get; set; }
        public Penal SelectedPenal { get; set; }



        public Material SelectedTopMaterial { get; set; }
        public Material SelectedBottomMaterial { get; set; }
        public Material SelectedPenalMaterial { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Repository rep = new Repository();

            TopElements = rep.GetAllTopElements();
            topType.ItemsSource = TopElements;
            topType.DisplayMemberPath = "Name";

            BotElements = rep.GetAllBottomElements();
            botType.ItemsSource = BotElements;
            botType.DisplayMemberPath = "Name";

            Penals = rep.GetAllPenals();
            penalType.ItemsSource = Penals;
            penalType.DisplayMemberPath = "Name";
        }

        //top
        private void topType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            SelectedTopElement = (TopElement)topType.SelectedItem;
            topMaterial.ItemsSource = SelectedTopElement.Materials;
            topMaterial.DisplayMemberPath = "NameOfMaterial";
        }

        private void topMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            SelectedTopMaterial = (Material)topMaterial.SelectedItem;
            if (SelectedTopMaterial != null)
            {
                topSize.ItemsSource = SelectedTopMaterial.SizeValues;
                topSize.DisplayMemberPath = "SizeValue";
            }
            else
            {
                topSize.ItemsSource = null;
            }
        }

       
        //bottom
        private void botType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedBottomElement = (BottomElement) botType.SelectedItem;
            botMaterial.ItemsSource = SelectedBottomElement.Materials;
            botMaterial.DisplayMemberPath = "NameOfMaterial";
        }

        private void botMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedBottomMaterial = (Material)botMaterial.SelectedItem;
            if (SelectedBottomMaterial != null)
            {
                botSize.ItemsSource = SelectedBottomMaterial.SizeValues;
                botSize.DisplayMemberPath = "SizeValue";
            }
            else
            {
                botSize.ItemsSource = null;
            }
        }

        //penal
        private void penalType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedPenal = (Penal)penalType.SelectedItem;
            penalMaterial.ItemsSource = SelectedPenal.Materials;
            penalMaterial.DisplayMemberPath = "NameOfMaterial";
        }

        private void penalMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedPenalMaterial = (Material)penalMaterial.SelectedItem;
            if (SelectedPenalMaterial != null)
            {
                penalSize.ItemsSource = SelectedPenalMaterial.SizeValues;
                penalSize.DisplayMemberPath = "SizeValue";
            }
            else
            {
                penalSize.ItemsSource = null;
            }
        }
    }
}
