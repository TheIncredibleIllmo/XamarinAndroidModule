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
using Newtonsoft.Json;
using XamarinAndroidModule.Models;

namespace XamarinAndroidModule.Activies
{
    [Activity(Label = "Programmer Details", Theme = "@style/Theme.AlsetAndroidTheme")]
    public class ProgrammerDetailsActivity : Activity
    {
        #region FIELDS
        private TextView _detailsTxt;
        private Button _photoBtn;
        #endregion

        #region CONTROLS

        #endregion

        #region PROPERTIES
        public Programmer Programmer { get; set; }
        #endregion

        #region ACTIVITY_LIFECYCLE
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.ProgrammerDetails);

            var receivedIntent = Intent.GetStringExtra(Helpers.Constants.ProgrammerId);
            var programmer = JsonConvert.DeserializeObject<Programmer>(receivedIntent);
            Programmer = programmer;

            _detailsTxt = FindViewById<TextView>(Resource.Id.DetailsTxt);
            _photoBtn = FindViewById<Button>(Resource.Id.PhotoBtn);

            _detailsTxt.Text = Programmer?.ToString() ?? string.Empty;
        }
        #endregion

        #region METHODS

        #endregion

        #region EVENT_HANDLERS
        #endregion
    }
}