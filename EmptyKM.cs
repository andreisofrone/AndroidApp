using BarChart;
using System;
using Android.App;
using Android.OS;

namespace Project
{
    [Activity(Theme = "@style/DetailsTheme", Label = "Empty KM", Icon = "@drawable/launcher")]
    public class EmptyKM : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Graph);

            string lip = Intent.GetStringExtra("DataFromEmpty") ?? "Data not available";

            int emptyKMY = Convert.ToInt16(NetHttp.FetchWaitAsync(App.Instance.GetUrl("emptyKmYear")).Result);
            int emptyKMM = Convert.ToInt16(NetHttp.FetchWaitAsync(App.Instance.GetUrl("emptyKmMonth")).Result);
            int emptyKMD = Convert.ToInt16(NetHttp.FetchWaitAsync(App.Instance.GetUrl("emptyKmToday")).Result);

            var data = new[] { emptyKMD, emptyKMM, emptyKMY };
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

