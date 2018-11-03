using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;

namespace XamarinAndroidModule
{
    [Activity(Label = "XamarinAndroidModule", MainLauncher = true)]
    public class MainActivity : Activity
    {
        #region VIEWS
        private EditText _nameEdt;
        private EditText _specialtyEdt;
        private Button _createBtn;
        private LinearLayout _mainLyt;
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
        }

        protected override void OnStart()
        {
            base.OnStart();
            _createBtn.Click += OnCreateClicked;
        }

        protected override void OnPause()
        {
            base.OnPause();
            _createBtn.Click -= OnCreateClicked;
        }

        #endregion

        #region EVENT_HANDLERS
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


            TextView programmerTxt = new TextView(this)
            {
                Text = $"{name} {specialty}",
                TextSize = 25f,
                Gravity = GravityFlags.CenterHorizontal
            };

            HideKeyboard();
            _mainLyt.AddView(programmerTxt);

        }
        #endregion

        #region METHODS
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

