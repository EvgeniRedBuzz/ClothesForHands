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
using static ClothesForHands.EF.AppData;
using ClothesForHands.EF;

namespace ClothesForHands.Windows
{
    /// <summary>
    /// Логика взаимодействия для ListMaterialWindow.xaml
    /// </summary>
    public partial class ListMaterialWindow : Window
    {
        List<Material> materialslist = new List<Material>();
        int NumPage = 1;
        int LastPage;

        public ListMaterialWindow()
        {
            InitializeComponent();
            Filter();
        }


        private void Filter()
        {
            materialslist = Context.Material.ToList();

            materialslist = materialslist.OrderBy(i => i.IdMaterial)
                .Skip((NumPage - 1) * 15).Take(15).ToList();

            if (materialslist.Count % 15 == 0)
            {
                LastPage = materialslist.Count / 15;
            }
            else
            {
                LastPage = (materialslist.Count / 15) + 1;
            }

            if (TxtMaterialName.Text != null)
            {
                materialslist = materialslist
                .Where(i => i.NameMaterial.Contains(TxtMaterialName.Text))
                .ToList();
            }

            LVMaterial.ItemsSource = materialslist;
        }

        private void TBMaterialName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CBFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (NumPage == 1)
            {
                return;
            }
            else
            {
                NumPage--;
                Filter();
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            NumPage++;
            Filter();
        }
    }
}