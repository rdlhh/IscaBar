using IscaBar.Models;
using IscaBar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IscaBar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Product_View : ContentPage
    {
        private ProductVM productVM;
        public ProductVM ProductVM { get { return productVM; } set { productVM = value; OnPropertyChanged(); } }

        public Product_View(Categoria CatFather)
        {
            InitializeComponent();
            ProductVM = new ProductVM(CatFather);
            this.BindingContext = ProductVM;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;


            //Deselect Item
            ((ListView)sender).SelectedItem = null;

        }
    }
}