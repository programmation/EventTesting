using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using EventTesting;
using EventTesting.Droid;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]

namespace EventTesting.Droid
{
    public class CustomLabelRenderer : LabelRenderer
    {
        public CustomLabelRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                return;
            }

            if (Control != null)
            {
                var element = Element as CustomLabel;

                element.Area = 0.0f;
                element.AreaChanged += (sender, e2) => {
//                    Debug.WriteLine("Renderer: {0}", e2.NewArea);
                };
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var element = Element as CustomLabel;

            if (e.PropertyName == Label.WidthProperty.PropertyName
                || e.PropertyName == Label.HeightProperty.PropertyName)
            {
                var area = (float)element.Width * (float)element.Height;
                element.Area = area;
                element.OnAreaChanged(area);
                // Compiler says can't do following:
//                element.AreaChanged(this, new AreaChangedEventArgs(area));
            }
        }
    }
}

