using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinAndroidModule.Holders;
using XamarinAndroidModule.Models;

namespace XamarinAndroidModule.Adapters
{
    public class ProgrammerAdapter : BaseAdapter<Programmer>
    {

        #region FIELDS
        private Activity _context;
        private List<Programmer> _programmerLst;
        private int _counter;
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

            View view = convertView;

            if(view==null)
            {
                view = _context.LayoutInflater.Inflate(Resource.Layout.ProgrammerRow, parent, false);

                var progImg = view.FindViewById<ImageView>(Resource.Id.progImg);
                var progNameTxt = view.FindViewById<TextView>(Resource.Id.progNameTxt);
                var progSpecialtyTxt = view.FindViewById<TextView>(Resource.Id.progSpecialtyTxt);

                //This holder contains the instances of the Controls
                //used by the row
                var holder = new ProgrammerHolder
                {
                    ProgrammerImg = progImg,
                    ProgrammerNameTxt = progNameTxt,
                    ProgrammerSpecialtyTxt = progSpecialtyTxt
                };

                view.Tag = holder;

                //To check how may times the row objects are created
                _counter++;
                System.Diagnostics.Debug.WriteLine($"{_counter}");
            }

            //When exists a Row to re-use.
            var viewHolder = (ProgrammerHolder)view.Tag;
            viewHolder.ProgrammerNameTxt.Text = programmer.Name;
            viewHolder.ProgrammerSpecialtyTxt.Text = programmer.Specialty;

            try
            {
                using (Drawable drawable = 
                    GetDrawableFromString(programmer.ImageUrl)) 
                {
                    viewHolder.ProgrammerImg.SetImageDrawable(drawable);
                }
            }
            catch (Java.Lang.Exception ex)
            {           
                return null;
            }

            return view;
        }
        public override Programmer this[int position] => _programmerLst[position];

        public override int Count => _programmerLst.Count;

        public override long GetItemId(int position)
        {
            return position;
        }
        #endregion
        #region METHODS
        /// <summary>
        /// Gets the drawable from the image url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private Drawable GetDrawableFromString(string url)
        {
            if (string.IsNullOrEmpty(url)) return null;

            using (Stream str = _context.Assets.Open(url))
            {
                var drawable = Drawable.CreateFromStream(str,null);
                return drawable;
            }           
        }
        #endregion
    }
}