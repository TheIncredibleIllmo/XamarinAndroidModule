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

        #endregion

        #region CONTROLS
        private TextView _detailsTxt;
        private Button _photoBtn;
        private ImageView _detailsImg;

        private AlertDialog.Builder _alert;
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
            _detailsImg = FindViewById<ImageView>(Resource.Id.DetailsImg);

            _detailsTxt.Text = Programmer?.ToString() ?? string.Empty;
        }

        protected override void OnResume()
        {
            base.OnResume();
            _photoBtn.Click += OnPhotoButtonClicked;
        }
        protected override void OnPause()
        {
            base.OnPause();
            _photoBtn.Click -= OnPhotoButtonClicked;
        }
        #endregion

        #region METHODS
        private void CallGallery()
        {
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(intent,Helpers.Constants.GalleryCode);
        }

        #endregion

        #region EVENT_HANDLERS
        private void OnPhotoButtonClicked(object sender, EventArgs e)
        {
            var optionsArray = new string[] { "Camera", "Gallery" };

            _alert = new AlertDialog.Builder(this);
            _alert.SetTitle(GetString(Resource.String.DetailsDefaultTitle));
            _alert.SetItems(optionsArray, UploadFrom);
            _alert.SetNegativeButton(GetString(Resource.String.PhotoAlertButton),CloseUpload);
            _alert.Show();
        }

        private void UploadFrom(object sender, DialogClickEventArgs e)
        {
            var option = e.Which;

            if(option==0)
            {
                //Camera
            }
            else if(option==1)
            {
                //Gallery
                CallGallery();
            }
        }
        
        private void CloseUpload(object sender, DialogClickEventArgs e)
        {
            _alert?.Show()?.Dismiss();
        }
        #endregion

        #region ACTIVITY_METHODS
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            switch (requestCode)
            {
                case Helpers.Constants.CameraCode:
                    break;
                case Helpers.Constants.GalleryCode:
                    if(resultCode==Result.Ok && data!=null)
                    {
                        var uri = data.Data;
                        if (uri == null) return;
                        _detailsImg.SetImageURI(uri);
                    }
                    break;
            }

        }
        #endregion
    }
}