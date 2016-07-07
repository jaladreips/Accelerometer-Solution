using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Hardware;

namespace WorkingAccel
{
    [Activity(Label = "WorkingAccel", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, ISensorEventListener
    {
        int count = 1;
        TextView text;
        SensorManager sensor;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            text = FindViewById<TextView>(Resource.Id.text);
            sensor = (SensorManager)GetSystemService(SensorService);
            sensor.RegisterListener(this, sensor.GetDefaultSensor(SensorType.Accelerometer), SensorDelay.Ui);
        }

        public void OnAccuracyChanged(Sensor sensor, SensorStatus accuracy)
        {
            //Do nothing
        }

        public void OnSensorChanged(SensorEvent e)
        {
            text.Text = string.Format("x = {0}; y = {1}; z = {2}", e.Values[0], e.Values[1], e.Values[2]);
        }

    }
}

