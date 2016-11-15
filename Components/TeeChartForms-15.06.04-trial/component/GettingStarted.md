TeeChart components for Xamarin.Forms include five components, `TeeChart.PCL.dll`, `TeeChart.PCL.Android.dll`, `TeeChart.PCL.iOS.dll`,
`TeeChart.PCL.iOS.Unified.dll` and `TeeChart.WP8.dll`.

TChart is a data visualisation control that creates a graphical representation of data. It can handle high amounts of data, 
from a database if required. It supports many different series (display) types; standard types like Line, Area, Bar, Pie, Gantt; 
professional 2D or 3D series types, like Surface, TriSurface, Contour and indicators like Circular Gauges, Horizontal Indicators, 
and more..

This document provides a short guide to getting started.

Requirements
------------

TeeChart for Xamarin.Forms requires that a Xamarin Developer license be installed for the Android and iOS platforms if you wish to deliver your application to these environments, Visual Studio.NET with the Windows Phone SDK needs to be installed to support deployment to the Windows Phone 8 platform. 

Creating a new project 

Follow the conventional steps to creating a Xamarin Portable Class Library  project in Visual Studio.NET. Typically that would take the form of selecting "Xamarin.Forms Portable" project type from the Visual Studio project templates folder, "Mobile Apps". 

The Wizard will automatically create the four PCL solution projects. 
ie. 
YourPCLApp 
YourPCLApp.Android 
YourPCLApp.iOS 
YourPCLApp.WinPhone 

We have already prepared a sample project to help better highlight steps taken to using TeeChart in this environment. To browse the project please open the Sample Project solution under the TeeChart Examples folder. Please note that the other project, TeeChartDemo.PCL, also exists to serve as a reference document. 


Preparing the TeeChart project elements

To use TeeChart in the Xamarin.Forms PCL project you need to add or create/add these elements: 

PCL Common Project 
------------------
Reference: Add a reference to `TeeChart.PCL.dll` 

New units: Create/Add a code unit called ChartView.cs 

The content of ChartView.cs is as follows: 


using System; using System.Collections.Generic; using System.Linq; using System.Text; using System.Threading.Tasks; using Xamarin.Forms;  namespace SampleProject {   public class ChartView: View   {     public ChartView()     {     }      public EventHandler OnInvalidateDisplay;      public static readonly BindableProperty ModelProperty =       BindableProperty.Create("ModelProperty", typeof(Steema.TeeChart.Chart), typeof(ChartView), null);      public Steema.TeeChart.Chart Model     {       get { return (Steema.TeeChart.Chart)GetValue(ModelProperty); }       set { SetValue(ModelProperty, value); }     }      public void InvalidateDisplay()     {       if (OnInvalidateDisplay != null)         OnInvalidateDisplay(this, null);     }   }  } 


PCL Android Project 
-------------------
Reference: Add a reference to `TeeChart.PCL.dll` and `TeeChart.PCL.Android.dll` 

New units: Create/Add a code unit called ChartViewRenderer.cs 

The content of ChartViewRenderer.cs is as follows: 


using System; using System.Collections.Generic; using System.Linq; using System.Text;  using Android.App; using Android.Content; using Android.OS; using Android.Runtime; using Android.Widget; using Xamarin.Forms; using Xamarin.Forms.Platform.Android; using XamarinFormsTest.Droid; using XamarinFormsTest; using Steema.TeeChart; using SampleProject;  [assembly: ExportRenderer(typeof(ChartView), typeof(ChartViewRenderer))] namespace XamarinFormsTest.Droid {   public class ChartViewRenderer: ViewRenderer   {     protected TChart NativeControl     {       get       {         return ((TChart)Control);       }     }      protected ChartView NativeElement     {       get       {         return ((ChartView)Element);       }     }      protected override void OnElementChanged(ElementChangedEventArgs<View> e)     {       base.OnElementChanged(e);        //if (/*Control == null ||*/ e.OldElement != null || this.Element == null)       //  return;        if (Control == null)       {         var chartView = new Steema.TeeChart.TChart(Context);          chartView.Chart = NativeElement.Model;          SetNativeControl(chartView);       }        if (e.OldElement != null)       {         //unhook old events       }        if (e.NewElement != null)       {         //hook old events       }     }      //protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)     //{     //  base.OnElementPropertyChanged(sender, e);     //}   } }


PCL iOS Project 
---------------
Reference: Add a reference to `TeeChart.PCL.dll` and `TeeChart.PCL.iOS.dll` 
or for the unified version:
Add a reference to `TeeChart.PCL.dll` and `TeeChart.PCL.iOS.Unified.dll` 

New units: Create/Add a code unit called ChartViewRenderer.cs 

The content of ChartViewRenderer.cs is as follows: 


using System; using System.Collections.Generic; using System.ComponentModel; using System.Linq; using System.Text; using System.Threading.Tasks; using SampleProject; using Xamarin.Forms; using Xamarin.Forms.Platform.iOS;  [assembly: ExportRenderer(typeof(ChartView), typeof(SampleProject.iOS.ChartViewRenderer))] namespace SampleProject.iOS {      //UIView, IViewRenderer, IDisposable, IRegisterable   public class ChartViewRenderer : ViewRenderer<ChartView, Steema.TeeChart.TChart>   {           protected override void OnElementChanged(ElementChangedEventArgs<ChartView> e)     {       base.OnElementChanged(e);       if (e.OldElement != null || this.Element == null)         return;        var chartView = new Steema.TeeChart.TChart();         chartView.Chart = Element.Model;        SetNativeControl(chartView);     }      protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)     {       base.OnElementPropertyChanged(sender, e);     }   } }


PCL.WinPhone Project 
-------------------- 
Reference: Add a reference to `TeeChart.PCL.dll` and `TeeChart.WP8.dll` 

New units: Create/Add a code unit called ChartViewRenderer.cs 

The content of ChartViewRenderer.cs is as follows: 


using SampleProject; using System; using System.Collections.Generic; using System.ComponentModel; using System.Linq; using System.Text; using System.Threading.Tasks; using Xamarin.Forms; using Xamarin.Forms.Platform.WinPhone;  [assembly: ExportRenderer(typeof(ChartView), typeof(SampleProject.WP8.ChartViewRenderer))] namespace SampleProject.WP8 {   public class ChartViewRenderer : ViewRenderer<ChartView, Steema.TeeChart.TChart>   {     protected override void OnElementChanged(ElementChangedEventArgs<ChartView> e)     {       base.OnElementChanged(e);       if (e.OldElement != null || this.Element == null)         return;        var chartView = new Steema.TeeChart.TChart();        chartView.Chart = Element.Model;       chartView.Aspect.ClipPoints = false;       chartView.Aspect.ExtendAxes = true;        SetNativeControl(chartView);     }      protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)     {       base.OnElementPropertyChanged(sender, e);     }   } } 


Using TeeChart in the project
-----------------------------
Adding a Chart to the project 
TeeChart must be added by code to the project. There is currently no visible designer. 

Go to the Common PCL project, in the sample open the SampleProject project. Open the page upon which you wish to place the Chart, in this case App.cs. You will see from the following example code how the Chart is created and programmed. 

App.cs from the TeeChart for Xamarin.Forms SampleProject. 

	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	using Xamarin.Forms;

	namespace SampleProject
	{
	  public class App : Application
	  {
		public App()
		{
		  var tChart1 = new Steema.TeeChart.Chart();

		  tChart1.Series.Add(new Steema.TeeChart.Styles.Bar()).FillSampleValues();
		  tChart1.Aspect.View3D = false;
		  
		  ChartView chartView = new ChartView
		  {
			VerticalOptions = LayoutOptions.FillAndExpand,
			HorizontalOptions = LayoutOptions.FillAndExpand,

			WidthRequest = 400,
			HeightRequest = 500
		  };

		  chartView.Model = tChart1;

		  MainPage = new ContentPage
		  {
			Content = new StackLayout
			{
			  Children =
			  {
				chartView,
			  }
			},
		  };
		}
	  }
	}

Note that, in this example, the main TeeChart Charting Component, TChart, is created as tChart1 and a Bar style Series is added and populated by sample values. 

Using TeeChart across the different platforms 

Code added to the common PCL project will run and apply rendered charts accordingly to each platform supported by the PCL model. Generally speaking it is not necessary to write any platform specific code unless you have your own reasons to do so. 

## Other Resources

* [Steema Support forums](http://support.steema.com)
* [Product Description Resources](http://www.steema.com/teechart/mobile)
