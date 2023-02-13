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
    public partial class CategoryView : ContentPage
    {
        CategoryViewVM vm;
        public CategoryView()
        {
            vm = new CategoryViewVM();
            InitializeComponent();
            CategoryList.ItemsSource = vm.BindingCat;
        }
        public CategoryView(Categoria cat)
        {
            vm = new CategoryViewVM(cat);
            InitializeComponent();
            CategoryList.ItemsSource = vm.BindingCat;
            
           
        }

        async void ProductList(object sender, EventArgs e)
        {
            Categoria categoria = (Categoria)CategoryList.SelectedItem;
            if (categoria == null) 
                return;

            if (categoria.Subcategories.Count > 0)
            {
                await Navigation.PushAsync(new CategoryView(categoria));
            }
            else
            {
                await Navigation.PushAsync(new Product_View(categoria));
            }
            
            //Deselected item
            ((ListView)sender).SelectedItem = null;
        }

        private void ClickedGuardarPed(object sender, EventArgs e)
        {

        }

        private void ClickedAtras(object sender, EventArgs e)
        {
            
        }

        private void ClickedMenuDia(object sender, EventArgs e)
        {

        }

    }
}