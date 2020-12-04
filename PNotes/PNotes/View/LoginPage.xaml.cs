using PNotes.Models;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void RegisterNewUserCommand1(object s, EventArgs e)
        {
            Console.WriteLine("RegisterNewUserCommand1 ::Here");

            await this.Navigation.PushAsync(new CreateUserPage());
        }

        async void onlogin(object s, EventArgs e)
        {
            try
            {
                //null or blank space check
                if (!string.IsNullOrWhiteSpace(loginName.Text) && !string.IsNullOrWhiteSpace(loginPassword.Text))
                {
                    //create UserInfo instance and call athentiication function
                    UserInfo userDetail = App.Database.GetItemUserAthentication(loginName.Text, loginPassword.Text);

                    if (userDetail != null)
                    {
                        if (loginName.Text != userDetail.Name && loginPassword.Text != userDetail.Password)
                        {
                           
                            await DisplayAlert("Login", "Login failed .. Please try again ", "OK");
                        }
                        else
                        {
                            await DisplayAlert("Registrtion", "Login Success ...", "OK");
                            App._CurrentUser = userDetail;
                            App._UserID = userDetail.UserID;
                            App.Current.MainPage = new NavigationPage(new MainComplaintPage());
                            //await Navigation.PushModalAsync(new MainViewPage());
                        }
                    }
                    else
                    {
                        await DisplayAlert("Login", "Login failed .. Please try again ", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Alert", "Please Enter Email and Password.", "OK");
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.ToString());
            }           

        }


    }
}