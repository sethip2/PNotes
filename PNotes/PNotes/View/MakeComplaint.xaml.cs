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
    public partial class MakeComplaint : ContentPage
    {
        public MakeComplaint()
        {
            InitializeComponent();

            //set the initial value of date
            entryDate.SetValue(DatePicker.MinimumDateProperty, DateTime.Now);
            entryDate.SetValue(DatePicker.MaximumDateProperty, DateTime.Now.AddDays(180));
        }


        async void OnCreateComplaintClicked(object sender, EventArgs args)
        {
            //fields validation
            if (await ValidateEntriesAsync())
            {
                //Creating new ComplaintInfo and calling save method
                App.Database.SaveNewUserComplaint(new Models.ComplaintInfo
                {
                    Title = entryTitle.Text,
                    Type = entryType.SelectedItem.ToString(),
                    ComplaintDate = entryDate.Date,
                    Discription = entryDiscription.Text,
                    PropsedSolution = entrySolution.Text,
                    Status = "Pending",
                    UserID = App._UserID
                });


                //make fields empty
                entryDate.SetValue(DatePicker.MinimumDateProperty, DateTime.Now);
                entryDate.SetValue(DatePicker.MaximumDateProperty, DateTime.Now.AddDays(180));
                entryDiscription.Text = entrySolution.Text = string.Empty;
                

                //save message
                await DisplayAlert("Info", "Complaint Submited..", "OK");

                //Return to Main Page
                await Application.Current.MainPage.Navigation.PopAsync();
            }

        }

        //fields validation 
        private async Task<bool> ValidateEntriesAsync()
        {
            bool fieldsStatus = true;
            if (string.IsNullOrWhiteSpace(entryTitle.Text))
            {
                fieldsStatus = false;
            }

            if (string.IsNullOrWhiteSpace(entryType.SelectedItem.ToString()))
            {
                fieldsStatus = false;
            }

            if (string.IsNullOrWhiteSpace(entryDiscription.Text))
            {
                fieldsStatus = false;
            }
            if (string.IsNullOrWhiteSpace(entrySolution.Text))
            {
                fieldsStatus = false;
            }


            if (!fieldsStatus)
            {
                await DisplayAlert("Error", "Please fill empty fields.", "OK");
            }

            return fieldsStatus;
        }


    }
}