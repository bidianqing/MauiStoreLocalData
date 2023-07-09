namespace MauiStoreLocalData;

public partial class App : Application
{
    public static Repository Repository { get; private set; }

    public App(Repository repository)
	{
		InitializeComponent();

		MainPage = new AppShell();

        // https://learn.microsoft.com/zh-cn/dotnet/maui/platform-integration/storage/preferences
        Preferences.Default.Set("name", "tom");
		var name = Preferences.Default.Get("name", "Unknown");

        Repository = repository;
    }
}
