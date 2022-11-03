/*
 * LazerEyes AlertSettings.xaml.cs
 * Code responsible for handling _SettingsObj related to alerts
 * Course- IST440
 * Author- Cameron Grande
 * Date Developed- 9/26/22
 * Last Changed- 9/26/22
 * Rev: 1
 */

namespace Lazer_Eyes;

public partial class AlertSettings : ContentPage
{
    public Settings SettingsObj;
    public AlertSettings()
	{
		InitializeComponent();
        SettingsObj = Settings.Get();
        DefaultSwitch.IsToggled = SettingsObj.GetAlertSettingsDefault();
        ThresholdSlider.Value = SettingsObj.GetDistanceThreshold();
        StrideSlider.Value = SettingsObj.GetStrideLength();
        UnitsPicker.SelectedIndex = SettingsObj.GetDistanceUnit();
    }

    void DefaultAlertSettingsToggled(object sender, ToggledEventArgs e)
    {
        DefaultSwitch.IsToggled = e.Value;
        SettingsObj.SetAlertSettingsDefault(e.Value);
    }

    void UnitsPickerIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            UnitsPicker.SelectedIndex = selectedIndex;
            SettingsObj.SetDistanceUnit(selectedIndex);
        }
    }

    void DistanceThresholdSliderChanged(object sender, ValueChangedEventArgs args)
    {
        SettingsObj.SetDistanceThreshold(args.NewValue);
    }

    void StrideSliderChanged(object sender, ValueChangedEventArgs args)
    {
        SettingsObj.SetStrideLength(args.NewValue);
    }

    private void ReturnHome(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

}