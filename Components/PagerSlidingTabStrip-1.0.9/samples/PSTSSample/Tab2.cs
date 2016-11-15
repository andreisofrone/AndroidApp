using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Xamarin.Android;

namespace Sample
{
	[Activity(Label = "Tab2", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class Tab2 : Activity
	{
		private PlotView plotViewModel;
		private LinearLayout mLLayoutModel;
		public PlotModel MyModel { get; set; }

		private int[] modelAllocValues = new int[]{40,60 };
		private string[] modelAllocations = new string[] {"Slice1", "Slice2" };
		string[] colors = new string[] { "#7DA137", "#6EA6F3" };
		int total = 0;



		private PlotView plotViewModell;
		private LinearLayout mLLayoutModell;
		public PlotModel MyModell { get; set; }

		private int[] modelAllocValuess = new int[]{40,60 };
		private string[] modelAllocationss = new string[] {"Slice1", "Slice2" };
		string[] colorss = new string[] { "#7DA137", "#6EA6F3" };
		int totall = 0;





		private PlotView plotViewModelll;
		private LinearLayout mLLayoutModelll;
		public PlotModel MyModelll { get; set; }

		private int[] modelAllocValuesss = new int[]{40,60 };
		private string[] modelAllocationsss = new string[] {"Slice1", "Slice2" };
		string[] colorsss = new string[] { "#7DA137", "#6EA6F3" };
		int totalll = 0;



		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Mainn);

			plotViewModel = FindViewById<PlotView>(Resource.Id.plotViewModel1);
			mLLayoutModel = FindViewById<LinearLayout>(Resource.Id.linearLayoutModel);

			//Model Allocation Pie char
			var plotModel2 = new PlotModel();
			var pieSeries2 = new PieSeries();
			pieSeries2.InsideLabelPosition = 0.0;
			pieSeries2.InsideLabelFormat = null;

			for (int i = 0; i < modelAllocations.Length && i < modelAllocValues.Length && i < colors.Length; i++)
			{

				pieSeries2.Slices.Add(new PieSlice(modelAllocations[i], modelAllocValues[i]) { Fill = OxyColor.Parse(colors[i]) });
				pieSeries2.OutsideLabelFormat = null;

				double mValue = modelAllocValues[i];
				double percentValue = (mValue / total) * 100;
				string percent = percentValue.ToString("#.##");

				//Add horizontal layout for titles and colors of slices
				LinearLayout hLayot = new LinearLayout(this);
				hLayot.Orientation = Android.Widget.Orientation.Horizontal;
				LinearLayout.LayoutParams param = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
				hLayot.LayoutParameters = param;

				//Add views with colors
				LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(15, 15);

				View mView = new View(this);
				lp.TopMargin = 5;
				mView.LayoutParameters = lp;
				mView.SetBackgroundColor(Android.Graphics.Color.ParseColor(colors[i]));

				//Add titles
				TextView label = new TextView(this);
				label.TextSize = 10;
				label.SetTextColor(Android.Graphics.Color.Black);
				label.Text = string.Join(" ",modelAllocations[i]);
				param.LeftMargin = 8;
				label.LayoutParameters = param;

				hLayot.AddView(mView);
				hLayot.AddView(label);
				mLLayoutModel.AddView(hLayot);

			}

			plotModel2.Series.Add(pieSeries2);
			MyModel = plotModel2;
			plotViewModel.Model = MyModel;

			///////2222


			plotViewModell = FindViewById<PlotView>(Resource.Id.plotViewModel2);
			mLLayoutModell = FindViewById<LinearLayout>(Resource.Id.linearLayoutModel);

			//Model Allocation Pie char
			var plotModel22 = new PlotModel();
			var pieSeries22 = new PieSeries();
			pieSeries2.InsideLabelPosition = 0.0;
			pieSeries2.InsideLabelFormat = null;

			for (int i = 0; i < modelAllocationss.Length && i < modelAllocValuess.Length && i < colorss.Length; i++)
			{

				pieSeries22.Slices.Add(new PieSlice(modelAllocationss[i], modelAllocValuess[i]) { Fill = OxyColor.Parse(colorss[i]) });
				pieSeries22.OutsideLabelFormat = null;

				double mValue = modelAllocValues[i];
				double percentValue = (mValue / totall) * 100;
				string percent = percentValue.ToString("#.##");

				//Add horizontal layout for titles and colors of slices
				LinearLayout hLayott = new LinearLayout(this);
				hLayott.Orientation = Android.Widget.Orientation.Horizontal;
				LinearLayout.LayoutParams paramm = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
				hLayott.LayoutParameters = paramm;

				//Add views with colors
				LinearLayout.LayoutParams lpp = new LinearLayout.LayoutParams(15, 15);

				View mVieww = new View(this);
				lpp.TopMargin = 5;
				mVieww.LayoutParameters = lpp;
				mVieww.SetBackgroundColor(Android.Graphics.Color.ParseColor(colorss[i]));

				//Add titles
				TextView labell = new TextView(this);
				labell.TextSize = 10;
				labell.SetTextColor(Android.Graphics.Color.Black);
				labell.Text = string.Join(" ",modelAllocationss[i]);
				paramm.LeftMargin = 8;
				labell.LayoutParameters = paramm;

				hLayott.AddView(mVieww);
				hLayott.AddView(labell);
				mLLayoutModell.AddView(hLayott);

			}

			plotModel22.Series.Add(pieSeries22);
			MyModell = plotModel22;
			plotViewModell.Model = MyModell;


			///333333

			plotViewModelll = FindViewById<PlotView>(Resource.Id.plotViewModel3);
			mLLayoutModelll = FindViewById<LinearLayout>(Resource.Id.linearLayoutModel);

			//Model Allocation Pie char
			var plotModel222 = new PlotModel();
			var pieSeries222 = new PieSeries();
			pieSeries222.InsideLabelPosition = 0.0;
			pieSeries222.InsideLabelFormat = null;

			for (int i = 0; i < modelAllocationsss.Length && i < modelAllocValuesss.Length && i < colorsss.Length; i++)
			{

				pieSeries222.Slices.Add(new PieSlice(modelAllocationsss[i], modelAllocValuesss[i]) { Fill = OxyColor.Parse(colorsss[i]) });
				pieSeries222.OutsideLabelFormat = null;

				double mValueee = modelAllocValues[i];
				double percentValueee = (mValueee / totalll) * 100;
				string percent = percentValueee.ToString("#.##");

				//Add horizontal layout for titles and colors of slices
				LinearLayout hLayot = new LinearLayout(this);
				hLayot.Orientation = Android.Widget.Orientation.Horizontal;
				LinearLayout.LayoutParams paramm = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
				hLayot.LayoutParameters = paramm;

				//Add views with colors
				LinearLayout.LayoutParams lppp = new LinearLayout.LayoutParams(15, 15);

				View mVieww = new View(this);
				lppp.TopMargin = 5;
				mVieww.LayoutParameters = lppp;
				mVieww.SetBackgroundColor(Android.Graphics.Color.ParseColor(colorsss[i]));

				//Add titles
				TextView labell = new TextView(this);
				labell.TextSize = 10;
				labell.SetTextColor(Android.Graphics.Color.Black);
				labell.Text = string.Join(" ",modelAllocations[i]);
				paramm.LeftMargin = 8;
				labell.LayoutParameters = paramm;

				hLayot.AddView(mVieww);
				hLayot.AddView(labell);
				mLLayoutModelll.AddView(hLayot);

			}

			plotModel222.Series.Add(pieSeries222);
			MyModelll = plotModel222;
			plotViewModelll.Model = MyModelll;





				
		}
	}
}