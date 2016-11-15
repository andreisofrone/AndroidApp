using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android.Graphics.Drawables;
using com.refractored;
using Android.Support.V4.View;
using Android.Util;
using Android.Graphics;

namespace Sample
{
	[Activity (Label = "Sample", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : BaseActivity, IOnTabReselectedListener
	{
		int count = 1;

		protected override int LayoutResource {
			get {
				return Resource.Layout.activity_main;
			}
		}

		private MyPagerAdapter adapter;
		private Drawable oldBackground = null;
		private int currentColor;
		private ViewPager pager;
		private PagerSlidingTabStrip tabs;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			adapter = new MyPagerAdapter(SupportFragmentManager);
			pager = FindViewById<ViewPager> (Resource.Id.pager);
			tabs = FindViewById<PagerSlidingTabStrip> (Resource.Id.tabs);
			pager.Adapter = adapter;
			tabs.SetViewPager (pager);

			var pageMargin = (int)TypedValue.ApplyDimension (ComplexUnitType.Dip, 4, Resources.DisplayMetrics);
			pager.PageMargin = pageMargin;
			tabs.OnTabReselectedListener = this;

			//ChangeColor (Resources.GetColor (Resource.Color.green));


      SupportActionBar.SetDisplayHomeAsUpEnabled(false);
      SupportActionBar.SetHomeButtonEnabled(false);
		}
	


		#region IOnTabReselectedListener implementation
		public void OnTabReselected (int position)
		{
			Toast.MakeText(this, "Tab reselected: " + position, ToastLength.Short).Show();
		}
		#endregion



	public class MyPagerAdapter : FragmentPagerAdapter{
		private  string[] Titles = {"Categories", "Home"};

		public MyPagerAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm)
		{
		}

		public override Java.Lang.ICharSequence GetPageTitleFormatted (int position)
		{
			return new Java.Lang.String (Titles [position]);
		}
		#region implemented abstract members of PagerAdapter
		public override int Count {
			get {
				return Titles.Length;
			}
		}
		#endregion
		#region implemented abstract members of FragmentPagerAdapter
		public override Android.Support.V4.App.Fragment GetItem (int position)
		{
			return SuperAwesomeCardFragment.NewInstance (position);
		}
		#endregion
	}
}

}
