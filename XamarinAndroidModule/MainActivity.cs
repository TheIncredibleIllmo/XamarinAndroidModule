using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;

using XamarinAndroidModule.Models;
using System.Linq;
using System.Collections.Generic;
using Android.Content;
using System;

namespace XamarinAndroidModule
{
    [Activity(Label = "XamarinAndroidModule", MainLauncher = true, Theme = "@style/Theme.AlsetAndroidTheme")]
    public class MainActivity : Activity
    {
        #region FIELDS
        List<string> _programmerLst = new List<string>();
        #endregion

        #region VIEWS
        private EditText _nameEdt;
        private EditText _specialtyEdt;
        private Button _createBtn;
        private LinearLayout _mainLyt;
        private ListView _progListView;
        private ArrayAdapter _arrayAdapter;
        private Android.App.AlertDialog _alert;
        #endregion

        #region LIFECYCLE
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _nameEdt = FindViewById<EditText>(Resource.Id.NameEdt);
            _specialtyEdt = FindViewById<EditText>(Resource.Id.SpecialtyEdt);
            _createBtn = FindViewById<Button>(Resource.Id.CreateBtn);
            _mainLyt = FindViewById<LinearLayout>(Resource.Id.MainLayout);
            _progListView = FindViewById<ListView>(Resource.Id.ProgListView);

            //1.LISTS ELEMENTS
            //Data
            //ListView (VIEWGROUP)
            //Adapter (Intermediary between Data and ListView)

            //Gets names only.

            _arrayAdapter = new ArrayAdapter<string>(this,Android.Resource.Layout.SimpleListItem1,_programmerLst);
            _progListView.Adapter = _arrayAdapter;
        }

        protected override void OnStart()
        {
            base.OnStart();
            _createBtn.Click += OnCreateClicked;
            _progListView.ItemLongClick += OnItemLongClick;
        }

        protected override void OnPause()
        {
            base.OnPause();
            _createBtn.Click -= OnCreateClicked;
        }

        #endregion

        #region EVENT_HANDLERS
        private void OnItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            var programmer = _programmerLst[e.Position];

            if (programmer == null) return;

            CreateDialog(Resource.Drawable.rocket, "PROGRAMMER", programmer);
        }

        private void OnCreateClicked(object sender, System.EventArgs e)
        {
            string name = _nameEdt.Text;
            string specialty = _specialtyEdt.Text;

            if (string.IsNullOrEmpty(name))
            {
                _nameEdt.Error = GetString(Resource.String.InvalidName);
                return;
            }

            if (string.IsNullOrEmpty(specialty))
            {
                _specialtyEdt.Error = GetString(Resource.String.InvalidSpecialty);
                return;
            }

            //CREATES THE CONTROL PROGRAMATICALLY
            /*TextView programmerTxt = new TextView(this)
            {
                Text = $"{name} {specialty}",
                TextSize = 25f,
                Gravity = GravityFlags.CenterHorizontal
            };*/

            var programmer = $"{name} - {specialty}";

            _programmerLst.Add(programmer);
            _arrayAdapter.Add(programmer);
            _arrayAdapter.NotifyDataSetChanged();

            HideKeyboard();
           // _mainLyt.AddView(programmerTxt);

        }
        #endregion

        #region METHODS
        private void CreateDialog(int iconId, string title="", string message="")
        {          
             Android.App.AlertDialog.Builder builder = new AlertDialog.Builder(this);
            _alert = builder.Create();
            _alert.SetTitle(title);
            _alert.SetMessage(message);
            _alert.SetIcon(iconId);
            _alert.SetButton("Close", OnCloseDialog);
            _alert.Show();
        }

        private void OnCloseDialog(object sender, DialogClickEventArgs e)
        {
            _alert.Dismiss();
        }

        private void HideKeyboard()
        {
            var viewFocused = CurrentFocus;

            if (viewFocused != null)
            {
                InputMethodManager imm = (InputMethodManager)GetSystemService("input_method");
                imm.HideSoftInputFromWindow(viewFocused.WindowToken,HideSoftInputFlags.None);
            }
        }
        #endregion


    }
}

