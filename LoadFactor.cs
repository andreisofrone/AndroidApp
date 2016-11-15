using BarChart;
using System;
using Android.Views;
using Android.App;
using Android.OS;

namespace Project
{
    [Activity(Theme = "@style/DetailsTheme", Label = "Load Factor", Icon = "@drawable/launcher")]
    public class LoadFactor : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Graph);
            string lip = Intent.GetStringExtra("Datafromtabs") ?? "Data not available";

            //TEST

            int LoadFactorD = Convert.ToInt16(NetHttp.FetchWaitAsync(App.Instance.GetUrl("loadfactorday")).Result);
            int LoadFactorM = Convert.ToInt16(NetHttp.FetchWaitAsync(App.Instance.GetUrl("loadfactormonth")).Result);
            int LoadFactorY = Convert.ToInt16(NetHttp.FetchWaitAsync(App.Instance.GetUrl("loadfactoryear")).Result);

            var data = new[] { LoadFactorD, LoadFactorM, LoadFactorY };
            var color = new Android.Graphics.Color[3] { Android.Graphics.Color.DarkGoldenrod, Android.Graphics.Color.Chocolate, Android.Graphics.Color.ForestGreen};
            var leg = new[] { "Today", "Current Month", "Current Year" };
            BarModel[] datab = new BarModel[3];
            for (int i = 0; i < 3; i++)
            {
                datab[i] = new BarModel() { Value = data[i], Legend = leg[i],Color=color[i] };
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

