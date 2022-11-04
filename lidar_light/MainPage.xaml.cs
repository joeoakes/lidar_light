namespace lidar_light;

public partial class MainPage : ContentPage
{
	public bool running = true;
	public Settings SettingsObject;

	public MainPage()
	{
		SettingsObject = Settings.Get();
		InitializeComponent();

		try
		{
			LidarUtility.GetAlerts();
		} catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}


