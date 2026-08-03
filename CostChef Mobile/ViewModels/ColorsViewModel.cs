using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CostChef_Mobile.ViewModels
{
    internal partial class ColorsViewModel : ObservableObject
    {
        public ColorsViewModel() { }

        public Color bcgColor = Color.FromArgb("#E1DDD0");

        public Color inputColor = Color.FromArgb("#F1EDDC");

        public Color buttonColor = Color.FromArgb("#936B61");

        public Color listColor = Color.FromArgb("#EBEBEB");


    }
}
