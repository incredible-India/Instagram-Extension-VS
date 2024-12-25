using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Instagram
{
    public partial class MyToolWindowControl : UserControl
    {
        public MyToolWindowControl()
        {
            InitializeComponent();
            InitializeAsync();
        }
        private async void InitializeAsync()
        {
            Random rnd = new Random();
            string subFolder = rnd.Next().ToString();
            var env = await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(userDataFolder: Path.Combine(Path.GetTempPath(), $"{Environment.UserName}", subFolder));
            await instagram.EnsureCoreWebView2Async(env);
            var request = instagram.CoreWebView2.Environment.CreateWebResourceRequest("https://www.instagram.com/", "GET", null, null);
            instagram.CoreWebView2.NavigateWithWebResourceRequest(request);
        }
    }
}