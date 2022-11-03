/*
 * LazerEyes MainPage.xaml.cs
 * Logic associated with MainPage.xaml
 * Course- IST440
 * Author- Cameron Grande
 * Date Developed- 9/26/22
 * Last Changed- 10/02/22
 * Rev: 1
 */

namespace Lazer_Eyes;
using Plugin.Maui.Audio;

public partial class MainPage : ContentPage
{
    //define variables
    public Boolean IsStarted = true;
    public Settings SettingsObj;
    private readonly IAudioManager _audioManager;
    IAudioPlayer player;

    /*
* Constructor- init page
*/
    public MainPage(IAudioManager audioManager)
    {
        SettingsObj = Settings.Get();
        Application.Current.UserAppTheme = AppTheme.Dark;
        InitializeComponent();
        AnimateStatusTextAsync();
        this._audioManager = audioManager;
        InitializeAudioPlayer();

        try
        {
            LidarUtils.GetAlerts();
        } catch (Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
        }

        //TestObstacleDetection();
    }

    private async Task TestObstacleDetection()
    {
        while (IsStarted)
        {
            System.Diagnostics.Debug.WriteLine($"Obstacle Name: {LidarUtils.CurrentObstacle.ObstacleName}, Obstacle Distance: {LidarUtils.CurrentObstacle.Distance}");
        }
    }

    private async Task InitializeAudioPlayer()
    {
        player = _audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("beep1.wav"));
    }



    private async Task AnimateStatusTextAsync() 
    {
        while (IsStarted)
        {
            await Task.Delay(500);
             
            statusText.Text = $"Obstacle Name:\n {LidarUtils.CurrentObstacle.ObstacleName}\nObstacle Distance: \n{String.Format("{0:0.00}", LidarUtils.CurrentObstacle.Distance)} meters";
            lightText.Text = $"Light Estimate:\n {String.Format("{0:0.00}", LidarUtils.CurrentLightEstimate)} Lumens";
        }

    }

    /*
    * Help- loads in the help/setting page
    * @param sender- object that triggered action
    * @param eventArgs- arguments from action
    * @returns none
    */
    private void Help(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SettingsMenu());
    }

}

