using SQLite.Persistencia;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Nota> _dataActualizada;

        protected async override void OnAppearing()
        {
            await _connection.CreateTableAsync<Nota>();
            var tablaOInfo = await _connection.Table<Nota>().ToListAsync();
            _dataActualizada = new ObservableCollection<Nota>(tablaOInfo);
            mylistview.ItemsSource = _dataActualizada;

            base.OnAppearing();
        }

        void OnAdd(object sender, System.EventArgs e)
        {
            var test = new Nota { Title = Title.Text, Desc = Description.Text };
            _connection.InsertAsync(test);
            _dataActualizada.Add(test);

        }
        void OnDelete(object sender, System.EventArgs e)
        {
            var item = (Xamarin.Forms.MenuItem)sender;
            var nota = item.CommandParameter as Nota;

            _connection.DeleteAsync(nota);
            _dataActualizada.Remove(nota);

        }

        void OnUpdate(object sender, System.EventArgs e)
        {
            var item = (Xamarin.Forms.MenuItem)sender;
            var nota = item.CommandParameter as Nota;

            nota.Title += "Actualizado";
            _connection.UpdateAsync(nota);
            OnAppearing();

        }
    }
}
