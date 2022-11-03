/*
 * LazerEyes Settings.xaml.cs
 * Settings overview page, loads specific settings pages
 * Course- IST440
 * Author- Cameron Grande
 * Date Developed- 9/26/22
 * Last Changed- 9/26/22
 * Rev: 1
 */

namespace Lazer_Eyes;

public partial class SettingsMenu : ContentPage
{
	public SettingsMenu()
	{
		InitializeComponent();
	}

    private void AlertNotifications(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AlertNotifications());
    }

    private void AlertSettings(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AlertSettings());
    }

    private void ReturnHome(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}