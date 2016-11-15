
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace com.xamarin.example.tabhostwalkthrough
{
	[Activity(Theme = "@style/MyCustomTheme",Label = "Overview", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class HomeScreen : ListActivity {
		string[] items;
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			items = new string[] { "KPI1","KPI2","KPI3","KPI4","KPI5","KPI6" };
			ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
		}
		protected override void OnListItemClick(ListView l, View v, int position, long id)
		{}
	}}

