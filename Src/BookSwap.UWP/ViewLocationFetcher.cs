using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using BookSwap.UWP;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Platform.UWP;

[assembly:Dependency(typeof(ViewLocationFetcher))]
namespace BookSwap.UWP
{
    public class ViewLocationFetcher : IViewLocationFetcher
    {
        public PointF GetCoordinates(VisualElement view)
        {
            //var renderer = Xamarin.Forms.Platform.UWP.Platform.GetRenderer(view);
            //var nativeView = renderer.GetNativeElement();//.NativeView;
            
            //var rect = nativeView.Superview.ConvertPointToView(nativeView.Frame.Location, null);
            //return rect.ToSystemPointF();


            var renderer = Xamarin.Forms.Platform.UWP.Platform.GetRenderer(view);
            
            if (renderer == null)
                return new PointF();

            var nativeView = renderer.GetNativeElement();
            var location = new int[2];

            var density = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density;

            //RnD
            //nativeView.GetLocationOnScreen(location);
            return new PointF(location[0] / (float)density, location[1] / (float)density);
        }
    }
}