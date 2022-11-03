/*
 * LazerEyes AlertNotifications.xaml.cs
 * Logic related to alert notifications.
 * Course- IST440
 * Author- Cameron Grande
 * Date Developed- 9/26/22
 * Last Changed- 9/26/22
 * Rev: 1
 */

namespace Lazer_Eyes;

public partial class AlertNotifications : ContentPage
{
    public Settings SettingsObj;
    public AlertNotifications()
	{
		InitializeComponent();
        SettingsObj = Settings.Get();
        DefaultSwitch.IsToggled = SettingsObj.GetNotificationSettingsDefault();
        AuditoryNotificationsSwitch.IsToggled = SettingsObj.GetAuditoryDefault();
        AuditoryAlertsVolumeSlider.Value = SettingsObj.GetVolume();
        AuditoryNotificationsWarnignsSwitch.IsToggled = SettingsObj.GetAuditoryWarnings();
        AuditoryNotificationsDangerSwitch.IsToggled = SettingsObj.GetAuditoryDanger();
        TactileNotificationsSwitch.IsToggled = SettingsObj.GetTactileSettingsDefault();
        TactileNotificationsWarnignsSwitch.IsToggled = SettingsObj.GetTactileWarnings();
        TactileNotificationsDangerSwitch.IsToggled = SettingsObj.GetTactileDanger();
        TactileWarningIntensitySlider.Value = SettingsObj.GetTactileWarningIntensity();
        TactileDangerIntensitySlider.Value = SettingsObj.GetTactileDangerIntensity();
        LowLightNotificationsSwitch.IsToggled = SettingsObj.GetLowLightToggle();
    }

    void DefaultAlertNotificationsToggled(object sender, ToggledEventArgs e)
    {
        DefaultSwitch.IsToggled = e.Value;
        SettingsObj.SetNotificationSettingsDefault(e.Value);
    }

    void AuditorySwitchToggled(object sender, ToggledEventArgs e)
    {
        AuditoryNotificationsSwitch.IsToggled = e.Value;
        SettingsObj.SetAuditoryDefault(e.Value);
    }

    void AuditoryAlertsVolumeSliderChanged(object sender, ValueChangedEventArgs args)
    {
        SettingsObj.SetVolume(args.NewValue);
    }
    void AuditoryNotificationsWarningsToggled(object sender, ToggledEventArgs e)
    {
        AuditoryNotificationsWarnignsSwitch.IsToggled = e.Value;
        SettingsObj.SetAuditoryWarnings(e.Value);
    }
    void AuditoryNotificationsDangerToggled(object sender, ToggledEventArgs e)
    {
        AuditoryNotificationsDangerSwitch.IsToggled = e.Value;
        SettingsObj.SetAuditoryDanger(e.Value);
    }

    void TactileSwitchToggled(object sender, ToggledEventArgs e)
    {
        TactileNotificationsSwitch.IsToggled = e.Value;
        SettingsObj.SetTactileSettingsDefault(e.Value);
    }
    void TactileWarningsToggled(object sender, ToggledEventArgs e)
    {
        TactileNotificationsWarnignsSwitch.IsToggled = e.Value;
        SettingsObj.SetTactileWarnings(e.Value);
    }
    void TactileDangerToggled(object sender, ToggledEventArgs e)
    {
        TactileNotificationsDangerSwitch.IsToggled = e.Value;
        SettingsObj.SetTactileDanger(e.Value);
    }
    void TactileWarningIntensitySliderChanged(object sender, ValueChangedEventArgs args)
    {
        SettingsObj.SetTactileWarningIntensity(args.NewValue);
    }
    void TactileDangerIntensitySliderChanged(object sender, ValueChangedEventArgs args)
    {
        SettingsObj.SetTactileDangerIntensity(args.NewValue);
    }
    void LowLightNotificationsSwitchToggled(object sender, ToggledEventArgs e)
    {
        LowLightNotificationsSwitch.IsToggled = e.Value;
        SettingsObj.SetLowLightToggle(e.Value);
    }
    private void ReturnHome(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}