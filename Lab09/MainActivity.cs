using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab09
{
    [Activity(Label = "Lab09", Theme = "@android:style/Theme.Holo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            Validate();
        }

        private async void Validate()
        {
            var ServiceClient = new SALLab09.ServiceClient();

            string StudentEmail = "jarc_software@hotmail.com";
            string Password = "Jrosales23";

            string myDevice = Android.Provider.Settings.Secure.GetString(
                ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var Result = await ServiceClient.ValidateAsync(
                StudentEmail, Password, myDevice);

            var UserNameValue = FindViewById<TextView>(Resource.Id.UserNameValue);
            var StatusValue = FindViewById<TextView>(Resource.Id.StatusValue);
            var TokenValue = FindViewById<TextView>(Resource.Id.TokenValue);

            UserNameValue.Text = $"{Result.Fullname}";
            StatusValue.Text = $"{Result.Status}";
            TokenValue.Text = $"{Result.Token}";
        }
    }
}

