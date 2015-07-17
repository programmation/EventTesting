using System;
using System.ComponentModel;
using PropertyChanged;
using System.Runtime.CompilerServices;

namespace EventTesting
{
    [ImplementPropertyChanged]
    public class StartPageModel
    {
        public float LabelArea { get; set; }

        public StartPageModel()
        {
        }

    }
}

