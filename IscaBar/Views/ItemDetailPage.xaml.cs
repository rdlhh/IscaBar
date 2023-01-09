using IscaBar.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace IscaBar.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}