using Android.App;
using Android.Widget;
using Android.OS;

namespace Project
{
    [Activity(Theme = "@style/IPInsertTheme", Label = "My IP", Icon = "@drawable/launcher")]
    public class IPInsert : Activity
    {    
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.IP);
           Button IPInstert = FindViewById<Button>(Resource.Id.ok);
            var editText = FindViewById<EditText>(Resource.Id.entry);
            editText.Hint = "10.22.31.122";
            new AlertDialog.Builder(this)
            .SetPositiveButton("OK", (sender, args) =>
        
            {
       
            })
    
            .SetMessage("Wrong IP.Please re-enter!")
            .SetTitle("Error")
            .Show();

            IPInstert.Click += delegate
            {
                
                App.Instance.Domain = editText.Text;
                App.Instance.SavePrefs();
                Finish();
                StartActivity(typeof(MainActivity));
            };

        }
    }
}

