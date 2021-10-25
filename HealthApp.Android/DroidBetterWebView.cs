using Android.Content;
using HealthApp.Droid;
using HealthApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BetterWebView), typeof(DroidBetterWebView))]
namespace HealthApp.Droid
{
	public class DroidBetterWebView : WebViewRenderer
	{
		public DroidBetterWebView(Context context) : base(context) { }
		protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.Settings.AllowUniversalAccessFromFileURLs = true;
				Control.Settings.SetSupportZoom(true);

				Control.Settings.BuiltInZoomControls = true;
				Control.Settings.DisplayZoomControls = false;

				Control.Settings.LoadWithOverviewMode = true;
				Control.Settings.UseWideViewPort = true;
			}
		}
	}
}