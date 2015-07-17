using System;

using Xamarin.Forms;
using System.Diagnostics;

namespace EventTesting
{
    public delegate void AreaChangedEventHandler(object sender, AreaChangedEventArgs e);

    public class AreaChangedEventArgs : EventArgs
    {
        public float NewArea { get; private set; }

        public AreaChangedEventArgs(float newArea)
        {
            NewArea = newArea;
        }
    }

    public class CustomLabel : Label
    {
        public static BindableProperty AreaProperty = 
            BindableProperty.Create<CustomLabel, float> (p => p.Area, 0.0f);

        public float Area
        {
            get { return (float)GetValue(AreaProperty); }
            set { 
                SetValue(AreaProperty, value);
//                OnAreaChanged((float)value);
            }
        }
             
        public event AreaChangedEventHandler AreaChanged;

        public void OnAreaChanged (float newArea)
        {
            var handler = AreaChanged;
            if (handler != null)
            {
                handler (this, new AreaChangedEventArgs(newArea));
            }
        }

        public CustomLabel()
        {
            AreaChanged += (sender, e) => {
                Debug.WriteLine("Label: {0}", e.NewArea);
            };
        }
    }
}


