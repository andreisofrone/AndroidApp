TeeChart is a charting component library designed to provide you a wide range
of preprepared and configurable charts and charting options for inclusion in 
your project.

TeeChart for Xamarin.Forms provides the means to largely write cross-platform 
code once-only to support an application covering WP8, iOS and Android platforms. 
Most code can be written in the common PCL file. An example of use below:

	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Xamarin.Forms;

	namespace SampleProject
	{
	  public class ChartView: View
	  {
		public ChartView()
		{
		}

		public EventHandler OnInvalidateDisplay;

		public static readonly BindableProperty ModelProperty =
		  BindableProperty.Create("ModelProperty", typeof(Steema.TeeChart.Chart), typeof(ChartView), null);

		public Steema.TeeChart.Chart Model
		{
		  get { return (Steema.TeeChart.Chart)GetValue(ModelProperty); }
		  set { SetValue(ModelProperty, value); }
		}

		public void InvalidateDisplay()
		{
		  if (OnInvalidateDisplay != null)
			OnInvalidateDisplay(this, null);
		}
	  }

	} 
