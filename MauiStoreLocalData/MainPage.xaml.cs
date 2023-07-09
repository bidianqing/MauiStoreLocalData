namespace MauiStoreLocalData;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
    }

	private async void OnCounterClicked(object sender, EventArgs e)
	{
        var user = new User
        {
            Username = "tom"
        };
        await App.Repository.InsertAsync(user);

        string sql = "select count(*) from user";
		int count = await App.Repository.ExecuteScalaAsync(sql);

        CounterBtn.Text = $"Users count: {count}";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

