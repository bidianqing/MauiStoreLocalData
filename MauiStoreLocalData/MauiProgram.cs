using Microsoft.Extensions.Logging;
using SQLite;

namespace MauiStoreLocalData;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        string databasePath = Path.Combine(FileSystem.AppDataDirectory, "test.db");
        var connection = new SQLiteConnection(databasePath);
        var tableTypes = new[]
        {
            typeof(User),
            typeof(Conversation)
        };
        connection.CreateTables(CreateFlags.None, tableTypes);
        //builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<UserRepository>(s, databasePath));
        builder.Services.AddSingleton(sp => ActivatorUtilities.CreateInstance<Repository>(sp, databasePath));


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
