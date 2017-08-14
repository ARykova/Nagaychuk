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

        public Model.Size SelectedSizeTop { get; set; }
        public Model.Size SelectedSizeBottom { get; set; }
        public Model.Size SelectedSizePenal { get; set; }

        public List<OrderItem> Order { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            //DataContext = this;
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

            Order = new List<OrderItem>();
        }

        //top
        private void topType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            SelectedTopElement = (TopElement)topType.SelectedItem;
            topMaterial.ItemsSource = SelectedTopElement.Materials;
            topMaterial.DisplayMemberPath = "NameOfMaterial";

            topPrice.Text = "Цена:";

            //BitmapImage img = new BitmapImage("D:\\KursKuh\\" + "image.bmp");

            TopImage.Source = new BitmapImage(new Uri("D:\\KursKuh\\Pictures\\Top\\" + $"{SelectedTopElement.Name}" + ".png"));
        }

        private void topMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            SelectedTopMaterial = (Material)topMaterial.SelectedItem;
            topPrice.Text = "Цена:";
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
            botPrice.Text = "Цена:";
            BotImage.Source = new BitmapImage(new Uri("D:\\KursKuh\\Pictures\\Bottom\\" + $"{SelectedBottomElement.Name}" + ".png"));
        }

        private void botMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedBottomMaterial = (Material)botMaterial.SelectedItem;
            botPrice.Text = "Цена:";
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
            penalPrice.Text = "Цена:";
            SelectedPenal = (Penal)penalType.SelectedItem;
            penalMaterial.ItemsSource = SelectedPenal.Materials;
            penalMaterial.DisplayMemberPath = "NameOfMaterial";

            PenalImage.Source = new BitmapImage(new Uri("D:\\KursKuh\\Pictures\\Penal\\" + $"{SelectedPenal.Name}" + ".png"));
        }

        private void penalMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedPenalMaterial = (Material)penalMaterial.SelectedItem;
            penalPrice.Text = "Цена:";
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

        private void topSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedSizeTop = (Model.Size)topSize.SelectedItem;
            if (SelectedSizeTop != null)
            {
                topPrice.Text = "Цена: " + SelectedSizeTop.Price * Convert.ToInt32(topCount.Text);
            }
        }

        private void botSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedSizeBottom = (Model.Size)botSize.SelectedItem;
            if (SelectedSizeBottom != null)
            {
                botPrice.Text = "Цена: " + SelectedSizeBottom.Price * Convert.ToInt32(botCount.Text);
            }
        }

        private void penalSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedSizePenal = (Model.Size)penalSize.SelectedItem;
            if (SelectedSizePenal != null)
            {
                penalPrice.Text = "Цена: " + SelectedSizePenal.Price * Convert.ToInt32(penalCount.Text);
            }
        }

        double sum = 0;

        private void Order_Button_Click(object sender, RoutedEventArgs e)
        {
            Repository rep = new Repository();
            rep.SaveOrders(Order, sum);
            MessageBox.Show("Заказ успешно выполнен");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OrderItem orderItem = new OrderItem()
            {
                Count = Convert.ToInt32(topCount.Text),
                ItemName = SelectedTopElement.Name,
                Material = SelectedTopMaterial.NameOfMaterial,
                Size = SelectedSizeTop.SizeValue,
                Type = "Верхний элемент",
                Price = SelectedSizeTop.Price
            };
            Order.Add(orderItem);
            gridOrder.ItemsSource = null;
            gridOrder.ItemsSource = Order;
            sum += orderItem.Cost;
            PriceLabel.Content = sum;
            Order_Button.IsEnabled = sum > 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OrderItem orderItem = new OrderItem()
            {
                Count = Convert.ToInt32(penalCount.Text),
                ItemName = SelectedPenal.Name,
                Material = SelectedPenalMaterial.NameOfMaterial,
                Size = SelectedSizePenal.SizeValue,
                Type = "Пенал",
                Price = SelectedSizePenal.Price
            };
            Order.Add(orderItem);
            gridOrder.ItemsSource = null;
            gridOrder.ItemsSource = Order;
            sum += orderItem.Cost;
            PriceLabel.Content = sum;
            Order_Button.IsEnabled = sum > 0;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OrderItem orderItem = new OrderItem()
            {
                Count = Convert.ToInt32(botCount.Text),
                ItemName = SelectedBottomElement.Name,
                Material = SelectedBottomMaterial.NameOfMaterial,
                Size = SelectedSizeBottom.SizeValue,
                Type = "Верхний элемент",
                Price = SelectedSizeBottom.Price
            };
            Order.Add(orderItem);
            gridOrder.ItemsSource = null;
            gridOrder.ItemsSource = Order;
            sum += orderItem.Cost;
            PriceLabel.Content = sum;
            Order_Button.IsEnabled = sum > 0;
        }

        private void topCount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (SelectedSizeTop != null)
            {
                topPrice.Text = "Цена: " + SelectedSizeTop.Price * Convert.ToInt32(topCount.Text);
            }
        }

        private void botCount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (SelectedSizeBottom != null)
            {
                botPrice.Text = "Цена: " + SelectedSizeBottom.Price * Convert.ToInt32(botCount.Text);
            }
        }

        private void penalCount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (SelectedSizePenal != null)
            {
                penalPrice.Text = "Цена: " + SelectedSizePenal.Price * Convert.ToInt32(penalCount.Text);
            }
        }
    }

}
