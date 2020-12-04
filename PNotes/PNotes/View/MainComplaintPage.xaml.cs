using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PNotes.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainComplaintPage : ContentPage
    {
        public MainComplaintPage()
        {
            InitializeComponent();

            listComplaintData.ItemsSource = App.Database.GetComplaintAsync();
            if(App._CurrentUser != null)
            {
                entryCurrentLogin.IsVisible = true;
                logoutLink.IsVisible = true;
                boxLine.IsVisible = true;
                entryCurrentLogin.Text = "User : " + App._CurrentUser.Name;
            }
            else
            {
                boxLine.IsVisible = false;
                entryCurrentLogin.IsVisible = false;
                logoutLink.IsVisible = false;
            }
            
        }

        async void ONLoginButtonClicked(object sender, EventArgs args)
        {
            try { 


                if (App._CurrentUser != null && App._CurrentUser.UserID > -1)
                {
                    await DisplayAlert("Message", "Alrready Logedin. ", "OK");
                }
                else
                {
                    await this.Navigation.PushAsync(new LoginPage());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async void ONSearchButtonClicked(object sender, EventArgs args)
        {
            if(App._CurrentUser != null && App._CurrentUser.UserID > -1)
            {
                await this.Navigation.PushAsync(new MakeComplaint());
            }
            else
            {
                await DisplayAlert("Error", "Login Required .. Please login. ", "OK");
            }     
        }

        private async void LogoutUserCommand1(object s, EventArgs e)
        {
            Console.WriteLine("LogoutUserCommand1 ::Here");

            App._CurrentUser = null;
            App._UserID = -1;

            App.Current.MainPage = new NavigationPage(new MainComplaintPage());

            //await this.Navigation.PushAsync(new MainComplaintPage());
        }


    }
}