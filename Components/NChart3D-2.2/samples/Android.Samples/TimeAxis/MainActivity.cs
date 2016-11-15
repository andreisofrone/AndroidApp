﻿using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Java.Lang;

using NChart3D_Android;

namespace TimeAxis
{
	[Activity (Label = "TimeAxis", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity, INChartSeriesDataSource, INChartTimeAxisDataSource, INChartSizeAxisDataSource
	{
		NChartView mNChartView;
		Random random = new Random ();
		NChartBrush[] brushes;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			mNChartView = FindViewById <NChartView> (Resource.Id.surface);

			LoadView ();
		}

		private void LoadView ()
		{
			// Paste your license key here.
			mNChartView.Chart.LicenseKey = "";

			// Margin
			mNChartView.Chart.PolarSystem.Margin = new NChartMargin (10.0f, 10.0f, 10.0f, 40.0f);

			// Create brushes.
			brushes = new NChartBrush[3];
			brushes [0] = new NChartSolidColorBrush (Color.Argb (255, (int)(255 * 0.38), (int)(255 * 0.8), (int)(255 * 0.92)));
			brushes [1] = new NChartSolidColorBrush (Color.Argb (255, (int)(255 * 0.8), (int)(255 * 0.86), (int)(255 * 0.22)));
			brushes [2] = new NChartSolidColorBrush (Color.Argb (255, (int)(255 * 0.9), (int)(255 * 0.29), (int)(255 * 0.51)));

			// Set up the time axis.
			mNChartView.Chart.TimeAxis.TickShape = NChartTimeAxisTickShape.Line;
			mNChartView.Chart.TimeAxis.TickTitlesFont = new NChartFont (NChartFont.FontDefaultBold, NChartFont.StyleNormal, 11);
			mNChartView.Chart.TimeAxis.TickTitlesLayout = NChartTimeAxisLabelsLayout.ShowFirstLastLabelsOnly;
			mNChartView.Chart.TimeAxis.TickTitlesPosition = NChartTimeAxisLabelsPosition.Beneath;
			mNChartView.Chart.TimeAxis.TickTitlesColor = Color.Argb (255, 135, 135, 135);
			mNChartView.Chart.TimeAxis.TickColor = Color.Argb (255, 110, 110, 110);
			mNChartView.Chart.TimeAxis.Margin = new NChartMargin (20.0f, 20.0f, 10.0f, 0.0f);
			mNChartView.Chart.TimeAxis.AutohideTooltip = false;

			// Create the time axis tooltip.
			mNChartView.Chart.TimeAxis.Tooltip = new NChartTimeAxisTooltip ();
			mNChartView.Chart.TimeAxis.Tooltip.TextColor = Color.Argb (255, 140, 140, 140);
			mNChartView.Chart.TimeAxis.Tooltip.Font = new NChartFont (11);

			// Set images for the time axis.
			SetImagesForTimeAxis (Resource.Drawable.slider_light, Resource.Drawable.handler_light, Resource.Drawable.play_light,
				Resource.Drawable.play_pushed_light, Resource.Drawable.pause_light, Resource.Drawable.pause_pushed_light);

				
			// Visible time axis.
			mNChartView.Chart.TimeAxis.Visible = true;

			// Set animation time in seconds.
			mNChartView.Chart.TimeAxis.AnimationTime = 3.0f;

			// Switch 3D on.
			mNChartView.Chart.DrawIn3D = true;

			// Switch on antialiasing.
			mNChartView.Chart.ShouldAntialias = true;

			// Create series.
			for (int i = 0; i < 3; ++i) {
				NChartBubbleSeries series = new NChartBubbleSeries ();
				series.DataSource = this;
				series.Tag = i;
				// Add series to the chart.
				mNChartView.Chart.AddSeries (series);
			}
			mNChartView.Chart.CartesianSystem.XAxis.HasOffset = false;
			mNChartView.Chart.CartesianSystem.YAxis.HasOffset = false;
			mNChartView.Chart.CartesianSystem.ZAxis.HasOffset = false;

			// Set data source for the size axis to provide ticks.
			mNChartView.Chart.TimeAxis.DataSource = this;

			// Set data source for the size axis to provide sizes for bubbles.
			mNChartView.Chart.SizeAxis.DataSource = this;

			// Reset animation.
			mNChartView.Chart.TimeAxis.Stop ();
			mNChartView.Chart.TimeAxis.GoToFirstTick ();

			// Update data in the chart.
			mNChartView.Chart.UpdateData ();
		}

		void SetImagesForTimeAxis (int sliderId, int handlerId, int playNormalId,
		                           int playPushedId, int pauseNormalId, int pausePushedId)
		{
			mNChartView.Chart.TimeAxis.SetImages (null, null, null, null, 
				BitmapFactory.DecodeResource (this.Resources, playNormalId),
				BitmapFactory.DecodeResource (this.Resources, playPushedId),
				BitmapFactory.DecodeResource (this.Resources, pauseNormalId),
				BitmapFactory.DecodeResource (this.Resources, pausePushedId),
				BitmapFactory.DecodeResource (this.Resources, sliderId),
				BitmapFactory.DecodeResource (this.Resources, handlerId));
		}

		protected override void OnResume ()
		{
			base.OnResume ();
			mNChartView.OnResume ();
		}

		protected override void OnPause ()
		{
			base.OnPause ();
			mNChartView.OnPause ();
		}

		#region INChartSeriesDataSource

		public NChartPoint[] Points (NChartSeries series)
		{
			// Create points with some data for the series.
			NChartPoint[] result = new NChartPoint[3];
			for (int i = 0; i < 3; ++i) {
				NChartPointState[] states = new NChartPointState[3];
				for (int j = 0; j < 3; ++j) {
					NChartPointState state = NChartPointState.PointStateWithXYZ (
						random.Next (10) + 1, 
						random.Next (10) + 1, 
						random.Next (10) + 1);
					state.Marker = new NChartMarker ();
					state.Marker.Size = (float)random.NextDouble ();
					state.Marker.Brush = brushes [series.Tag];
					state.Marker.Shape = NChartMarkerShape.Sphere;
					state.Marker.Brush.ShadingModel = NChartShadingModel.Phong;

					states [j] = state;
				}
				result [i] = new NChartPoint (states, series);
			}
			return result;
		}

		public string Name (NChartSeries series)
		{
			return "My series";
		}

		// If you don't want to implement method, return null.
		public Bitmap Image (NChartSeries series) { return null; }
		public NChartPoint [] ExtraPoints (NChartSeries series) { return null; }

		#endregion

		#region INChartSizeAxisDataSource

		public float MinSize (NChartSizeAxis nChartSizeAxis)
		{
			return 30;
		}

		public float MaxSize (NChartSizeAxis nChartSizeAxis)
		{
			return 100;
		}

		// If you don't want to implement method, return null.
		public Number MaxValue (NChartSizeAxis nChartSizeAxis) { return null; }
		public Number MinValue (NChartSizeAxis nChartSizeAxis) { return null; }

		#endregion

		#region INChartTimeAxisDataSource

		public string[] Timestamps (NChartTimeAxis nChartTimeAxis)
		{
			return new string[]{ "1", "2", "3" };
		}

		#endregion
	}
}


