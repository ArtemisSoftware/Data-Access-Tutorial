using DataAccess.Persistence;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataAccess.Sql
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SqlMainPage : ContentPage
    {

        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Recipe> _recipes;

        public SqlMainPage()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Recipe>();

            var recipes = await _connection.Table<Recipe>().ToListAsync();
            _recipes = new ObservableCollection<Recipe>(recipes);
            recipesListView.ItemsSource = _recipes;

            base.OnAppearing();
        }


        async void OnAdd(object sender, System.EventArgs e)
        {
            var recipe = new Recipe { Name = "Recipe " + DateTime.Now.Ticks };
            await _connection.InsertAsync(recipe);

            _recipes.Add(recipe);
        }

        async void OnUpdate(object sender, System.EventArgs e)
        {
            if (_recipes.Count > 0)
            {
                var recipe = _recipes[0];
                recipe.Name += " UPDATED";
                await _connection.UpdateAsync(recipe);
            }
        }

        async void OnDelete(object sender, System.EventArgs e)
        {

            if(_recipes.Count > 0) { 
                await _connection.DeleteAsync(_recipes[0]);
                _recipes.Remove(_recipes[0]);
            }
        }
    }
}