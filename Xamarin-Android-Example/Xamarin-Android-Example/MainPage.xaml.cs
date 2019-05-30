using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin_Android_Example
{
    public partial class MainPage : ContentPage
    {
        private IList<Status> _statuslist;

        public MainPage()
        {
            InitializeComponent();

            _statuslist = GetStatus();
            foreach (var status in _statuslist)
            {
                statusPicker.Items.Add(status.Val);
            }
        }

        protected override void OnAppearing()
        {
            statusPicker.SelectedIndex = 1;
        }

        private IList<Status> GetStatus()
        {
            return new List<Status>
            {
                new Status {Id = 0, Val = "INACTIVE"},
                new Status {Id = 1, Val = "ACTIVE"}
            };
        }

        private void StatusPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var statusval = statusPicker.Items[statusPicker.SelectedIndex];
            var status = _statuslist.Single(st => st.Val == statusval);
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("First Name: " + FirstName.Text);
            System.Diagnostics.Debug.WriteLine("Last Name: " + LastName.Text);
            System.Diagnostics.Debug.WriteLine("Email: " + Email.Text);
            System.Diagnostics.Debug.WriteLine("Phone: " + Phone.Text);
            FirstName.Text = "";
            LastName.Text = "";
            Email.Text = "";
            Phone.Text = "";
            SuccessOrErrorMsg.Text = "User Details Printed / Saved Successfully.";
        }

        private async void ClearButton_Clicked(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            Email.Text = "";
            Phone.Text = "";
            SuccessOrErrorMsg.Text = "";
            statusPicker.SelectedIndex = 1;
        }
    }

    public class Status
    {
        public int Id { get; set; }
        public string Val { get; set; }
    }
}
