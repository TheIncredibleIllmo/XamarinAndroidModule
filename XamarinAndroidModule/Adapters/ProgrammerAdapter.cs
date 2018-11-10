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
using XamarinAndroidModule.Models;

namespace XamarinAndroidModule.Adapters
{
    public class ProgrammerAdapter : BaseAdapter<Programmer>
    {

        #region FIELDS
        private Activity _context;
        private List<Programmer> _programmerLst;
        #endregion

        public ProgrammerAdapter(Activity context, List<Programmer> programmerLst)
        {
            _context = context;
            _programmerLst = programmerLst;
        }

        #region ADAPTER_MEMBERS
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Programmer programmer = _programmerLst[position];

            var view = _context.LayoutInflater.Inflate(Resource.Layout.ProgrammerRow,parent,false);

            var progImg = view.FindViewById<ImageView>(Resource.Id.progImg);
            var progNameTxt = view.FindViewById<TextView>(Resource.Id.progNameTxt);
            var progSpecialtyTxt = view.FindViewById<TextView>(Resource.Id.progSpecialtyTxt);

            progNameTxt.Text = programmer.Name;
            progSpecialtyTxt.Text = programmer.Specialty;

            return view;
        }
        public override Programmer this[int position] => _programmerLst[position];

        public override int Count => _programmerLst.Count;

        public override long GetItemId(int position)
        {
            return position;
        }
        #endregion
       
    }
}