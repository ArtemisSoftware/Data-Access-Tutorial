using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataAccess.Restful
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestfulMainPage : ContentPage
    {

        private const string Url = "https://jsonplaceholder.typicode.com/posts";

        private HttpClient _client = new HttpClient();

        private ObservableCollection<Post> _posts;

        public RestfulMainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            var posts = JsonConvert.DeserializeObject<List<Post>>(content);

            _posts = new ObservableCollection<Post>(posts);
            postsListView.ItemsSource = _posts;
            
            base.OnAppearing();
        }

        async void OnAdd(object sender, System.EventArgs e)
        {
            var post = new Post { Title = "Title " + DateTime.Now.Ticks };

            _posts.Insert(0, post);

            var content = JsonConvert.SerializeObject(post);
            await _client.PostAsync(Url, new StringContent(content));

            
        }

        async void OnUpdate(object sender, System.EventArgs e)
        {
            if(_posts.Count > 0) { 
            var post = _posts[0];
            post.Title += " UPDATED";

            var content = JsonConvert.SerializeObject(post);
            await _client.PutAsync(Url + "/" + post.Id, new StringContent(content));
            }
        }

        async void OnDelete(object sender, System.EventArgs e)
        {
            if (_posts.Count > 0)
            {
                var post = _posts[0];
                await _client.DeleteAsync(Url + "/" + post.Id);

                _posts.Remove(post);
            }
        }
    }
}