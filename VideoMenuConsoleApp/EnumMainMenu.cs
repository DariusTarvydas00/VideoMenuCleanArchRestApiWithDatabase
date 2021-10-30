using System.ComponentModel;

namespace VideoMenuConsoleApp
{
    public enum MainMenu
    {
        [Description("Videos menu")] VideoMenu = 1,
        [Description("Customers menu")] CustomerMenu = 2,
        [Description("Genres menu")] GenreMenu = 3,
        [Description("Find/Search")] SearchMenu = 4,
        [Description("Exit")] Exit = 5
    }
    
    public enum VideoMenu
    {
        [Description("Add Video")] AddVideo = 1,
        [Description("Remove Video")] RemoveVideo = 2,
        [Description("List all videos")] ListAllVideos = 3,
        [Description("Update video")] UpdateVideo = 4,
        [Description("Exit")] Exit = 5
    }

    public enum CustomerMenu
    {
        [Description("Add Customer")] AddCustomer = 1,
        [Description("Remove Customer")] RemoveCustomer = 2,
        [Description("List all Customers")] ListAllCustomers = 3,
        [Description("Update Customer")] UpdateCustomer = 4,
        [Description("Exit")] Exit = 5
    }

    public enum GenreMenu
    {
        [Description("Add Genre")] AddGenre = 1,
        [Description("Remove Genre")] RemoveGenre = 2,
        [Description("List all Genres")] ListAllGenres = 3,
        [Description("Update Genre")] UpdateGenre = 4,
        [Description("Exit")] Exit = 5
    }

    public enum SearchMenu
    {
        [Description("Find a video")] FindVideo = 1,
        [Description("Find a Customer")] FindCustomer = 2,
        [Description("Find Genre")] FindGenre = 3,
        [Description("Find Anything")] FindAnything = 4,
        [Description("Exit")] Exit = 5
    }
}