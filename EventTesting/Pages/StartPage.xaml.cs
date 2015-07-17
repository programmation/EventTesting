using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EventTesting
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();

            BindingContext = new StartPageModel();

            areaLabel.AreaChanged += (sender, e) => {
                ((StartPageModel)BindingContext).LabelArea = e.NewArea;
            };
        }
    }
}

