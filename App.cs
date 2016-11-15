using Android.App;
using Android.Content;
using System;

namespace Project
{
    public class App
    {
        private static App app = new App();
        public string Domain;

        public static App Instance
        {
            get
            {
                return app;
            }
        }

        private App()
        {
            Init();
        }

        private void Init()
        {
            ISharedPreferences pref = Application.Context.GetSharedPreferences("Project", FileCreationMode.Private);
            Domain = pref.GetString("domain", String.Empty);
        }

        public void SavePrefs()
        {
            ISharedPreferences pref = Application.Context.GetSharedPreferences("Project", FileCreationMode.Private);
            var prefEditor = pref.Edit();
            prefEditor.PutString("domain", Domain);
            prefEditor.Commit();
        }

        public string GetUrl(string type)
        {
            switch (type)
            {
                case "loadfactorday":
                    return string.Format("http://{0}:56309/api/LoadFactor/LoadFactorDay", Domain);
                case "waityear":
                    return string.Format("http://{0}:56309/api/wait/waitYear", Domain);
                case "waitday":
                    return string.Format("http://{0}:56309/api//wait/waitDay", Domain);
                case "waitmonth":
                    return string.Format("http://{0}:56309/api/wait/waitMonth", Domain);
                case "caputday":
                    return string.Format("http://{0}:56309/api/capOverDistance/capOverDistanceDay", Domain);
                case "caputyear":
                    return string.Format("http://{0}:56309/api/capOverDistance/capOverDistanceYear", Domain);
                case "caputMonth":
                    return string.Format("http://{0}:56309/api/capOverDistance/capOverDistanceMonth", Domain);
                case "loadfactormonth":
                    return string.Format("http://{0}:56309/api/LoadFactor/LoadFactorMonth", Domain);
                case "loadfactoryear":
                    return string.Format("http://{0}:56309/api/LoadFactor/LoadFactorYear", Domain);
                case "allOrderToday":
                    return string.Format("http://{0}:56309/api/Order/allOrderToday", Domain);
                case "lateOrderToday":
                    return string.Format("http://{0}:56309/api/Order/lateOrderToday", Domain);
                case "lateOrderMonth":
                    return string.Format("http://{0}:56309/api/Order/lateOrderMonth", Domain);
                case "lateOrderYear":
                    return string.Format("http://{0}:56309/api/Order/lateOrderYear", Domain);
                case "allKmToday":
                    return string.Format("http://{0}:56309/api/KM/allKMToday", Domain);
                case "emptyKmToday":
                    return string.Format("http://{0}:56309/api/KM/emptyKMToday", Domain);
                case "emptyKmMonth":
                    return string.Format("http://{0}:56309/api/KM/emptyKMMonth", Domain);
                case "emptyKmYear":
                    return string.Format("http://{0}:56309/api/KM/emptyKMYear", Domain);
                default:
                    return "";
            }
        }

    }
}