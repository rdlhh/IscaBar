

using IscaBar.DAO.Servidor;
using IscaBar.Model;
using IscaBar.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace IscaBar.ViewModels
{ 
    class CategoryViewVM : ModelBase
    {
        private ObservableCollection<Categoria> bindingCat;
        private Categoria cat;

        public ObservableCollection<Categoria> BindingCat {
            get { return bindingCat; } 
            set { bindingCat = value; OnPropertyChanged(); } 
        }

        /// <summary>
        /// Metodo para actualizar la lista en caso de cambio
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Metodo que recarga de nuevo la lista en pantalla
        /// </summary>
        /// <returns></returns>
        public async Task LoadCategoryAsync()
        {
            getCategory();
        }
        /// <summary>
        /// Constructor de las lista de ordenes llama directamente a la la lista de categorias
        /// </summary>
        public CategoryViewVM()
        {
            getCategory();
        }

        public CategoryViewVM(Categoria cat)
        {
            this.cat = cat;
        }

        /// <summary>
        /// Metodo que conecta con el daoServidor para recoger todas lar ordenes getAllOrders
        /// </summary>
        /// <returns>lista de ordenes</returns>
        private async Task getCategory()
        {
            List<Categoria> CatList = await CategorySDAO.Instance.GetAllAsync();
            BindingCat = new ObservableCollection<Categoria>(CatList);

        }

    }
}
