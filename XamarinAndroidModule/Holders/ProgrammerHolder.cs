using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinAndroidModule.Holders
{
    class ProgrammerHolder : Java.Lang.Object
    {
        public ImageView ProgrammerImg { get; set; }
        public TextView ProgrammerNameTxt { get; set; }
        public TextView ProgrammerSpecialtyTxt { get; set; }
    }
}