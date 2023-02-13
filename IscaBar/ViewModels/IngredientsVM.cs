using iscaBar.DAO.Servidor;
using IscaBar.Model;
using IscaBar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace IscaBar.ViewModels
{
    public class IngredientsVM : ModelBase
    {
        private ObservableCollection<Ingredient> ingredients;
        public ObservableCollection<Ingredient> Ingredients { get { return ingredients; } set { ingredients = value; OnPropertyChanged(); } }

        public IngredientsVM() 
        {
            cargarDatos();
        }

        private async Task cargarDatos()
        {
            Ingredients = new ObservableCollection<Ingredient>();
            List<Ingredient> lingredients = await IngredientSDAO.GetAllAsync();
            Ingredients = new ObservableCollection<Ingredient>(lingredients);
        }
    }
}
