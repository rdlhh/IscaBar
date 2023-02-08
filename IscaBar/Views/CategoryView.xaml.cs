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
        CategoryViewVM vm = new CategoryViewVM();
        public CategoryView()
        {
            InitializeComponent();
            BindingContext = vm;
        }
        public CategoryView(Categoria cat)
        {
            vm = new CategoryViewVM(cat);
            InitializeComponent();
            CategoryList.ItemsSource = vm.Items;
            
           
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await vm.LoadCategoryAsync();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Categoria cat = (Categoria)e.Item;
            if (cat == null)
                return;

            await Navigation.PushAsync();

            ((ListView)sender).SelectedItem = null;
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
                await Navigation.PushAsync(new ProductView(categoria));
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