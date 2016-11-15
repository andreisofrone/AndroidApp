using System;
using Android.App;
using Android.Widget;
using Android.OS;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Xamarin.Android;
using Android.Content;
using System.Globalization;


namespace Project
{
    [Activity(Theme= "@style/MainTheme", Label = "Overview",Icon ="@drawable/launcher")]
	public class MainActivity : Activity
	{
        private double CapOverDist;
        private double SetWaitValue;

        private LinearLayout LayoutModelKm;
        private LinearLayout LayoutModelOrders;

        private PlotView plotViewModelOrders;
        private PlotView plotViewModelKm;

        public PlotModel MyModelOrders { get; set; }
        public PlotModel MyModelKm { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            CheckDomain();
            SetContentView(Resource.Layout.Main);           
            try
            {     
                    SetButtons();
                    SetCapOverDist();
                    SetLoadFactorIm();
                    SetWait();
                    SetKM();
                    SetOrders();
        }
                catch (AggregateException e)
                {             
                   
                    StartActivity(typeof(IPInsert));
                
                  }           
        }
         
                     
        private void SetLoadFactorIm()
        {
            int loadfa = Convert.ToInt16(NetHttp.FetchWaitAsync(App.Instance.GetUrl("loadfactorday")).Result);
            string loadf = Convert.ToString(loadfa);

          
            var loadfactord = FindViewById<TextView>(Resource.Id.loadfactor);
            loadfactord.Text = loadf+"%";
           
            if (loadfa == 0)
            {
                var imgtrailer = FindViewById<ImageView>(Resource.Id.imageView1);
                imgtrailer.SetBackgroundResource(Resource.Drawable.trailer0);
            }

            else
        if (loadfa >= 1 && loadfa < 15)
            {
                var imgtrailer = FindViewById<ImageView>(Resource.Id.imageView1);
                imgtrailer.SetBackgroundResource(Resource.Drawable.trailer1);
            }
            else
         if (loadfa >= 15 && loadfa < 25)
            {
                var imgtrailer = FindViewById<ImageView>(Resource.Id.imageView1);
                imgtrailer.SetBackgroundResource(Resource.Drawable.trailer3);
            }
            else
         if (loadfa >= 25 && loadfa < 35)
            {
                var imgtrailer = FindViewById<ImageView>(Resource.Id.imageView1);
                imgtrailer.SetBackgroundResource(Resource.Drawable.trailer5);
            }

            else
         if (loadfa >= 35 && loadfa < 45)
            {
                var imgtrailer = FindViewById<ImageView>(Resource.Id.imageView1);
                imgtrailer.SetBackgroundResource(Resource.Drawable.trailer6);
            }

            else
         if (loadfa >= 45 && loadfa < 55)
            {
                var imgtrailer = FindViewById<ImageView>(Resource.Id.imageView1);
                imgtrailer.SetBackgroundResource(Resource.Drawable.trailer7);
            }

            else
         if (loadfa >= 55 && loadfa < 65)
            {
                var imgtrailer = FindViewById<ImageView>(Resource.Id.imageView1);
                imgtrailer.SetBackgroundResource(Resource.Drawable.trailer8);
            }
            else
         if (loadfa >= 65 && loadfa < 75)
            {
                var imgtrailer = FindViewById<ImageView>(Resource.Id.imageView1);
                imgtrailer.SetBackgroundResource(Resource.Drawable.trailer10);
            }
            else
         if (loadfa >= 75 && loadfa < 85)
            {
                var imgtrailer = FindViewById<ImageView>(Resource.Id.imageView1);
                imgtrailer.SetBackgroundResource(Resource.Drawable.trailer12);
            }

            else
         if (loadfa >= 85 && loadfa < 95)
            {
                var imgtrailer = FindViewById<ImageView>(Resource.Id.imageView1);
                imgtrailer.SetBackgroundResource(Resource.Drawable.trailer13);
            }

            else
         if (loadfa >= 95 && loadfa <= 100)
            {
                var imgtrailer = FindViewById<ImageView>(Resource.Id.imageView1);
                imgtrailer.SetBackgroundResource(Resource.Drawable.trailer14);
            }
        }    
        
        public void CheckDomain()
        {
            if (string.IsNullOrEmpty(App.Instance.Domain))
            {
                Intent intent = new Intent(this, typeof(IPInsert));
                this.StartActivity(intent);
            }
         
            


        }
           
        private void SetCapOverDist()
        {
            CapOverDist = NetHttp.FetchWaitAsync(App.Instance.GetUrl("caputday")).Result;

            var progressbar = FindViewById<ProgressBar>(Resource.Id.progressBar2);
            progressbar.Progress = (int)CapOverDist;

          int  CapOverDistint = Convert.ToInt16(CapOverDist);
            var caputti = FindViewById<TextView>(Resource.Id.var5);
            caputti.Text = Convert.ToString(CapOverDistint)+"%";
        }
              
        private void SetWait()
        {
            SetWaitValue=NetHttp.FetchWaitAsync(App.Instance.GetUrl("waitday")).Result;
            var wait = FindViewById<TextView>(Resource.Id.waitvalue);
            wait.Text = SetWaitValue.ToString(CultureInfo.InvariantCulture)+" min";
            var imgtime = FindViewById<ImageView>(Resource.Id.imageView2);
            imgtime.SetBackgroundResource(Resource.Drawable.icon_10);


        }
               
        private void SetButtons()
        {
            Button stoptime = FindViewById<Button>(Resource.Id.button3);
            stoptime.Click += delegate {
                var tabs = new Intent(this, typeof(StopTime));
                //tabs.PutExtra("Dataforstop", ip);
                StartActivity(tabs);

            };
            Button loadfact = FindViewById<Button>(Resource.Id.button4);
            loadfact.Click += delegate {
                var tabs = new Intent(this, typeof(LoadFactor));
                StartActivity(tabs);
            };

            Button caputd = FindViewById<Button>(Resource.Id.button5);
            caputd.Click += delegate {
                var tabs = new Intent(this, typeof(CapacityUtilisation));
                StartActivity(tabs);
            };


            Button orders = FindViewById<Button>(Resource.Id.button1);
            orders.Click += delegate
            {
                var tabs = new Intent(this, typeof(LateOrders));
                StartActivity(tabs);
            };



            Button km = FindViewById<Button>(Resource.Id.button2);

            km.Click += delegate
            {
                var tabs = new Intent(this, typeof(EmptyKM));
                StartActivity(tabs);
            };

        }
               
        private void SetOrders()
        {

            double allOrder = Convert.ToDouble(NetHttp.FetchWaitAsync(App.Instance.GetUrl("allOrderToday")).Result);
            double lateOrder = Convert.ToDouble(NetHttp.FetchWaitAsync(App.Instance.GetUrl("lateOrderToday")).Result);

            double ontimeOrder = allOrder - lateOrder;
            double percentageLateOrder = (lateOrder / allOrder) * 100;
            double percentageOnTimeOrder = 100 - percentageLateOrder;

            double[] modelAllocValuesOrders = new double[] { percentageOnTimeOrder, percentageLateOrder };
            string[] modelAllocationsOrders = new string[] { string.Format(@"{0}", ontimeOrder), string.Format(@"{0}", lateOrder), };
            string[] colors = new string[] { "#33CC00", "#FF3300" };
            int total = 0;

            plotViewModelOrders = FindViewById<PlotView>(Resource.Id.plotViewModel1);
            LayoutModelOrders = FindViewById<LinearLayout>(Resource.Id.linearLayoutModel);

            var plotModel2 = new PlotModel();
            var pieSeries2 = new PieSeries();

            for (int i = 0; i < modelAllocationsOrders.Length && i < modelAllocValuesOrders.Length && i < colors.Length; i++)
            {

                pieSeries2.Slices.Add(new PieSlice(modelAllocationsOrders[i], modelAllocValuesOrders[i]) { Fill = OxyColor.Parse(colors[i]) });
                pieSeries2.OutsideLabelFormat = null;

                double mValue = modelAllocValuesOrders[i];
                double percentValue = (mValue / total) * 100;
                string percent = percentValue.ToString("#.##");

                //Add horizontal layout for titles and colors of slices
                LinearLayout hLayot = new LinearLayout(this);
                hLayot.Orientation = Android.Widget.Orientation.Horizontal;
                LinearLayout.LayoutParams param = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
                hLayot.LayoutParameters = param;

                //Add titles
                TextView label = new TextView(this);
                label.TextSize = 10;
                label.SetTextColor(Android.Graphics.Color.Black);
                label.Text = string.Join(" ", modelAllocationsOrders[i]);
                param.LeftMargin = 8;
                label.LayoutParameters = param;

              
                LayoutModelOrders.AddView(hLayot);

            }

            plotModel2.Series.Add(pieSeries2);
            MyModelOrders = plotModel2;
            plotViewModelOrders.Model = MyModelOrders;
        }
              
        private void SetKM()
        {
            double allKmToday = Convert.ToDouble(NetHttp.FetchWaitAsync(App.Instance.GetUrl("allKmToday")).Result);
            double emptyKmToday = Convert.ToDouble(NetHttp.FetchWaitAsync(App.Instance.GetUrl("emptyKmToday")).Result);

            double fullKmToday = allKmToday - emptyKmToday;
            double percentageEmptyKmToday = (emptyKmToday / allKmToday) * 100;
            double percentageFullKmToday = 100 - percentageEmptyKmToday;

            double[] modelAllocValuesKm = new double[] { percentageFullKmToday, percentageEmptyKmToday };
            string[] modelAllocationsKm = new string[] { string.Format(@"{0}", fullKmToday), string.Format(@"{0}", emptyKmToday) };
            string[] colorss = new string[] { "#33CC00", "#FF3300" };
            int totall = 0;

            plotViewModelKm = FindViewById<PlotView>(Resource.Id.plotViewModel2);
            LayoutModelKm = FindViewById<LinearLayout>(Resource.Id.linearLayoutModel);

            //Model Allocation Pie char
            var plotModel22 = new PlotModel();
            var pieSeries22 = new PieSeries();

            for (int i = 0; i < modelAllocationsKm.Length && i < modelAllocValuesKm.Length && i < colorss.Length; i++)
            {

                pieSeries22.Slices.Add(new PieSlice(modelAllocationsKm[i], modelAllocValuesKm[i]) { Fill = OxyColor.Parse(colorss[i]) });
                pieSeries22.OutsideLabelFormat = null;

                double mValue = modelAllocValuesKm[i];
                double percentValue = (mValue / totall) * 100;
                string percent = percentValue.ToString("#.##");

                //Add horizontal layout for titles and colors of slices
                LinearLayout hLayott = new LinearLayout(this);
                hLayott.Orientation = Android.Widget.Orientation.Horizontal;
                LinearLayout.LayoutParams param = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
                hLayott.LayoutParameters = param;

                //Add titles
                TextView labell = new TextView(this);
                labell.TextSize = 10;
                labell.SetTextColor(Android.Graphics.Color.Black);
                labell.Text = string.Join(" ", modelAllocationsKm[i]);
                param.LeftMargin = 8;
                labell.LayoutParameters = param;

              
                LayoutModelKm.AddView(hLayott);

            }

            plotModel22.Series.Add(pieSeries22);
            MyModelKm = plotModel22;
            plotViewModelKm.Model = MyModelKm;

        }
        
    }
}
