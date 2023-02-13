using iscaBar.Models;
using IscaBar.Model;
using IscaBar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IscaBar.ViewModels
{
    public class ProductVM : ModelBase
    {
        private Categoria categoria;
        public Categoria Categoria { get { return categoria; } set { categoria = value; OnPropertyChanged(); } }

        private ObservableCollection<Product> listProducts;
        public ObservableCollection<Product> ListProducts { get { return listProducts; } set { listProducts = value; OnPropertyChanged(); } }

        public ProductVM(Categoria CatFather)
        {
            Categoria = CatFather;
            listProducts = new ObservableCollection<Product>(Categoria.Products);
        }
    }
}
