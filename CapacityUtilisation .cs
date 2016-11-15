using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BarChart;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Drawing;

namespace Project
{
    [Activity(Theme = "@style/DetailsTheme", Label = "Capacity Utilisation Over Distance", Icon = "@drawable/launcher")]
    public class CapacityUtilisation : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Graph);
            string ipp = Intent.GetStringExtra("Datafromm") ?? "Data not available";

            int capD = Convert.ToInt16(NetHttp.FetchWaitAsync(App.Instance.GetUrl("caputday")).Result);
            int capM = Convert.ToInt16(NetHttp.FetchWaitAsync(App.Instance.GetUrl("caputMonth")).Result);
            int capY = Convert.ToInt16(NetHttp.FetchWaitAsync(App.Instance.GetUrl("caputyear")).Result);

            var data = new[] { capD, capM, capY };
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