using BarChart;
using System;
using Android.Views;
using Android.App;
using Android.OS;

namespace Project
{
	[Activity (Theme= "@style/DetailsTheme", Label = "Wait Time ", Icon = "@drawable/launcher")]			
	public class StopTime : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.Graph);
            string sip = Intent.GetStringExtra("Dataforstop") ?? "Data not available";

            int waitD = Convert.ToInt16(NetHttp.FetchWaitAsync(App.Instance.GetUrl("waitday")).Result);
            int waitM = Convert.ToInt16(NetHttp.FetchWaitAsync(App.Instance.GetUrl("waitmonth")).Result);
            int waitY = Convert.ToInt16(NetHttp.FetchWaitAsync(App.Instance.GetUrl("waityear")).Result);

            var data = new[] { waitD, waitM, waitY };
            var color = new Android.Graphics.Color[3] { Android.Graphics.Color.DarkGoldenrod, Android.Graphics.Color.Chocolate, Android.Graphics.Color.ForestGreen };
            var leg = new[] { "Today", "Current Month", "Current Year" };
            BarModel[] datab = new BarModel[3];
            for (int i = 0; i < 3; i++)
            {
                datab[i] = new BarModel() { Value = data[i], Legend = leg[i], Color = color[i] };
            }
            var chart = new BarChartView(this);
            chart = FindViewById<BarChart.BarChartView>(Resource.Id.barChart);
            chart.ItemsSource = datab;
            chart.Invalidate();
            chart.BarCaptionInnerColor = Android.Graphics.Color.Black;
            chart.BarCaptionOuterColor = Android.Graphics.Color.Black;
            chart.BarWidth = 150;
            chart.LegendColor = Android.Graphics.Color.Black;
            chart.LegendFontSize = 24;
            
        }

	}
}

