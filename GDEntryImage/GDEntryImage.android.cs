using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using Android.Text;
using Plugin.GDEntryImage;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms; 
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(GDEntryImage), typeof(GDEntryImageImplementation))]
namespace Plugin.GDEntryImage
{
    /// <summary>
    /// Interface for GDEntryImage
    /// </summary>
    public class GDEntryImageImplementation : EntryRenderer
    {
        public static Context AppContext { get; set; }
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public async static void Init(Context context)
        {
            var temp = DateTime.Now;
            AppContext = context;
        }

        GDEntryImage element;

        public GDEntryImageImplementation(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            element = (GDEntryImage)this.Element;

            GradientDrawable gd = new GradientDrawable();
            gd.SetColor(global::Android.Graphics.Color.Transparent);
            this.Control.SetBackgroundDrawable(gd);
            this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
            Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Black));

            Entry model = Element;
            var keyboard = model.Keyboard;
            var result = new InputTypes();

            if (keyboard == Keyboard.Numeric)
                result = InputTypes.ClassNumber;
            else if (keyboard == Keyboard.Telephone)
                result = InputTypes.ClassPhone;
            else if (keyboard == Keyboard.Email)
                result = InputTypes.TextVariationEmailAddress;

            Control.KeyListener = GetDigitsKeyListener(result);
            Control.InputType = keyboard.ToInputType();

            var editText = this.Control;
            if (!string.IsNullOrEmpty(element.Image))
            {
                switch (element.ImageAlignment)
                {
                    case ImageAlignment.Left:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.Image), null, null, null);
                        break;
                    case ImageAlignment.Right:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(element.Image), null);
                        break;
                }
            }
            editText.CompoundDrawablePadding = 25;
            Control.Background.SetColorFilter(element.LineColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
        }

        private BitmapDrawable GetDrawable(string imageEntryImage)
        {
            int resID = Resources.GetIdentifier(imageEntryImage, "drawable", AppContext.PackageName); // this.Context.PackageName
            var drawable = ContextCompat.GetDrawable(AppContext, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;

            return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, element.ImageWidth * 2, element.ImageHeight * 2, true));
        }

    }
}
