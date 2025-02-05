﻿
namespace Notepads.Controls.Settings
{
    using Microsoft.AppCenter.Analytics;
    using Notepads.Services;
    using System;
    using Windows.ApplicationModel;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Documents;
    using Windows.UI.Xaml.Media.Imaging;

    public sealed partial class AboutPage : Page
    {
        public string AppVersion => $"v{GetAppVersion()} Beta";

        public AboutPage()
        {
            InitializeComponent();
            SetAppIconBasedOnTheme(ThemeSettingsService.ThemeMode);
            ThemeSettingsService.OnThemeChanged += (sender, theme) => SetAppIconBasedOnTheme(theme);
        }

        private void SetAppIconBasedOnTheme(ElementTheme theme)
        {
            if (theme == ElementTheme.Dark || theme == ElementTheme.Default)
            {
                AppIconImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/appicon_bs.png"));
            }
            else
            {
                AppIconImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/appicon_ws.png"));
            }
        }

        private static string GetAppVersion()
        {
            PackageVersion version = Package.Current.Id.Version;
            return $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }

        private void Hyperlink_SourceCode_OnClick(Hyperlink sender, HyperlinkClickEventArgs args)
        {
            Analytics.TrackEvent("Hyperlink_SourceCode_OnClick");
        }

        private void Hyperlink_LandingPage_OnClick(Hyperlink sender, HyperlinkClickEventArgs args)
        {
            Analytics.TrackEvent("Hyperlink_LandingPage_OnClick");
        }

        private void Hyperlink_Issues_OnClick(Hyperlink sender, HyperlinkClickEventArgs args)
        {
            Analytics.TrackEvent("Hyperlink_Issues_OnClick");
        }

        private void Hyperlink_Mail_OnClick(Hyperlink sender, HyperlinkClickEventArgs args)
        {
            Analytics.TrackEvent("Hyperlink_Mail_OnClick");
        }
    }
}
