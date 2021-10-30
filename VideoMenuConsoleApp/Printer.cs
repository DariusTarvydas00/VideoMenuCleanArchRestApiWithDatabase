using System;
using System.Collections.Generic;
using VideoMenuConsoleApp.Core.ApplicationService;
using VideoMenuConsoleApp.Core.Entity;

namespace VideoMenuConsoleApp
{
    public class Printer:IPrinter
    {

        private ICustomerService _customerService;
        private IVideoService _videoService;
        private IGenreService _genreService;
        
        private static int _currentMenu = 0;

        public Printer(ICustomerService customerService, IVideoService videoService, IGenreService genreService)
        {
            _videoService = videoService;
            _customerService = customerService;
            _genreService = genreService;
            InitData();
            ShowMainMenu();
        }

        public void ShowMainMenu()
        {
            var selectedOption = 0;
            var selectedSubOption = 0;
            MainMenu:
            while (_currentMenu == 0 & selectedOption != 5)
            {
                selectedOption = OptionChooser();
                if (selectedOption == 5)
                {
                    break;
                }

                if (selectedOption is > 0 and < 5)
                {
                    _currentMenu = selectedOption;
                }

                SubMenu:
                PrintMenu(_currentMenu);
                while (_currentMenu > 0 && selectedSubOption != 5)
                {
                    selectedSubOption = OptionChooser();
                    if (selectedSubOption == 5)
                    {
                        _currentMenu = 0;
                        PrintMenu(_currentMenu);
                        selectedSubOption = 0;
                        goto MainMenu;
                    }

                    if (selectedSubOption is > 0 and < 5)
                    {
                        Console.Clear();
                        SelectSubMenu(_currentMenu, selectedSubOption);
                        PrintLine(Constants.PressAnyKey);
                        Console.ReadLine();
                    }

                    goto SubMenu;

                }
            }
        }

        int OptionChooser()
        {
            PrintMenu(_currentMenu);
            int selectionMainMenu = 0;
            while (!int.TryParse(Console.ReadLine(), out selectionMainMenu) || selectionMainMenu is < 1 or > 5)
            {
                PrintMenu(_currentMenu);
            }

            return selectionMainMenu;
        }

        void SelectSubMenu(int value, int value2)
        {
            switch (value)
            {
                case 1:
                    VideoMenuOptions(value2);
                    break;
                case 2:
                    CustomerMenuOptions(value2);
                    break;
                case 3:
                    GenreMenuOptions(value2);
                    break;
                case 4:
                    FindMenuOptions(value2);
                    break;
                default:
                    PrintMenu(_currentMenu);
                    break;
            }
        }

        void VideoMenuOptions(int value)
        {
            switch (value)
            {
                case 1:
                    AddVideo();
                    break;
                case 2:
                    RemoveVideo();
                    break;
                case 3:
                    ListAllVideos();
                    break;
                case 4:
                    UpdateVideo();
                    break;
            }
        }

        void AddVideo()
        {
            Console.WriteLine(Constants.EnterVideoName);
            var title = Console.ReadLine();
            Console.WriteLine(Constants.EnterVideoGenre);
            var genre = Console.ReadLine();
            Console.WriteLine(Constants.EnterReleaseDate);
            var releaseDate = DateTime.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine(Constants.EnterVideoStoryLine);
            var storyLine = Console.ReadLine();
            _videoService.NewVideo(title,releaseDate,new Genre(){Type = genre},storyLine);
        }

        void RemoveVideo()
        {
            var count = 0;
            ShowVideoList:
            Console.WriteLine(Constants.ShowAllVideoList);
            var answer = Console.ReadLine();
            if (answer == "yes")
            {
                ListAllVideos();
            }

            if (count == 1 && answer == "no")
            {
                goto VideoEndPoint;
            }

            count++;
            Console.WriteLine(Constants.EnterVideoIdToRemove);
            var videoId = int.Parse(Console.ReadLine());
            var video = _videoService.FindVideoById(videoId);
            
                    Console.WriteLine(
                        $"{Constants.VideoRemoved} {video.Id}.{video.Title} {video.ReleaseDate.Day}.{video.ReleaseDate.Month}.{video.ReleaseDate.Year} {video.Genre.Type} {video.StoryLine}");
            
            

            _videoService.DeleteVideo(videoId);
            goto ShowVideoList;
            VideoEndPoint: ;
        }

        void ListAllVideos()
        {
            foreach (var video in _videoService.GetAllVideos())
            {
                Console.WriteLine(
                    $"{video.Id}.{video.Title} {video.ReleaseDate.Day}.{video.ReleaseDate.Month}.{video.ReleaseDate.Year} {video.Genre.Type} {video.StoryLine}");
            }
        }

        void UpdateVideo()
        {
            var count = 0;
            ShowVideoList:
            Console.WriteLine(Constants.ShowAllVideoList);
            var answer = Console.ReadLine();
            if (answer == "yes")
            {
                ListAllVideos();
                if (count != 0)
                {
                    goto VideoEndPoint;
                }
            }

            if (count == 1 && answer == "no")
            {
                goto VideoEndPoint;
            }

            count++;
            Console.WriteLine(Constants.EnterVideoIdToUpdate);
            var videoId = int.Parse(Console.ReadLine());
            foreach (var video in _videoService.GetAllVideos())
            {
                if (video.Id == videoId)
                {
                    EditVideoInformation(video);
                }
            }

            goto ShowVideoList;
            VideoEndPoint: ;
        }

        void EditVideoInformation(Video video)
        {
            Console.WriteLine(Constants.UpdateVideoIdOrNot);
            var updateVideoIdAnswer = Console.ReadLine();
            if (updateVideoIdAnswer == "yes")
            {
                Console.WriteLine(Constants.EnterNewVideoId);
                video.Id = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(Constants.UpdateVideoName);
            var updateVideoNameAnswer = Console.ReadLine();
            if (updateVideoNameAnswer == "yes")
            {
                Console.WriteLine(Constants.EnterNewVideoName);
                video.Title = Console.ReadLine();
            }

            Console.WriteLine(Constants.UpdateVideoStoryLine);
            var updateVideoStoryLineAnswer = Console.ReadLine();
            if (updateVideoStoryLineAnswer == "yes")
            {
                Console.WriteLine(Constants.EnterNewVideoStoryLine);
                video.StoryLine = Console.ReadLine();
            }

            Console.WriteLine(Constants.UpdateVideoReleaseDate);
            var updateVideoReleaseDateAnswer = Console.ReadLine();
            if (updateVideoReleaseDateAnswer == "yes")
            {
                Console.WriteLine(Constants.EnterNewVideoReleaseDate);
                video.ReleaseDate = DateTime.Parse(Console.ReadLine());
            }

            Console.WriteLine(Constants.UpdateVideoGenre);
            var updateVideoGenreAnswer = Console.ReadLine();
            if (updateVideoGenreAnswer == "yes")
            {
                Console.WriteLine(Constants.EnterNewVideoGenre);
                video.Genre = new Genre()
                {
                    Type = Console.ReadLine()
                };
            }
        }

        void CustomerMenuOptions(int value)
        {
            switch (value)
            {
                case 1:
                    AddCustomer();
                    break;
                case 2:
                    RemoveCustomer();
                    break;
                case 3:
                    ListAllCustomers();
                    break;
                case 4:
                    UpdateCustomer();
                    break;
            }
        }

        void AddCustomer()
        {
            Customer customer = new Customer();
            Console.WriteLine(Constants.EnterCustomerName);
            customer.FirstName = Console.ReadLine();
            Console.WriteLine(Constants.EnterCustomerSurName);
            customer.LastName = Console.ReadLine();
            Console.WriteLine(Constants.EnterBirthday);
            customer.Birthday = DateTime.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine(Constants.EnterEmail);
            customer.Email = Console.ReadLine();
            Console.WriteLine(Constants.EnterPhoneNumber);
            customer.PhoneNumber = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            _customerService.CreateCustomer(customer);
        }

        void RemoveCustomer()
        {
            var count = 0;
            ShowCustomerList:
            Console.WriteLine(Constants.ShowAllCustomerList);
            var answer = Console.ReadLine();
            if (answer == "yes")
            {
                ListAllCustomers();
            }

            if (count == 1 && answer == "no")
            {
                goto CustomerEndPoint;
            }

            count++;
            Console.WriteLine(Constants.EnterCustomerIdToRemove);
            var customerId = int.Parse(Console.ReadLine());
            foreach (var customer in (_customerService.GetAllCustomers()))
            {
                if (customer.Id == customerId)
                {
                    Console.WriteLine(
                        $"Id:{customer.Id} {customer.FirstName} {customer.LastName} {customer.Email} {customer.PhoneNumber} " +
                        $"{customer.Birthday.Year}.{customer.Birthday.Month}.{customer.Birthday.Day}");
                    _customerService.DeleteCustomer(customerId);
                }
            }

            goto ShowCustomerList;
            CustomerEndPoint: ;
        }

        void ListAllCustomers()
        {
            _customerService.GetAllCustomers();
            foreach (var customer in  _customerService.GetAllCustomers())
            {
                Console.WriteLine(
                    $"Id:{customer.Id} {customer.FirstName} {customer.LastName} {customer.Email} {customer.PhoneNumber} " +
                    $"{customer.Birthday.Year}.{customer.Birthday.Month}.{customer.Birthday.Day}");
            }
        }

        void UpdateCustomer()
        {
            var count = 0;
            ShowCustomerList:
            Console.WriteLine(Constants.ShowAllCustomerList);
            var answer = Console.ReadLine();
            if (answer == "yes")
            {
                ListAllCustomers();
                if (count != 0)
                {
                    goto CustomerEndPoint;
                }
            }

            if (count == 1 && answer == "no")
            {
                goto CustomerEndPoint;
            }

            count++;
            Console.WriteLine(Constants.EnterCustomerIdToUpdate);
            var customerId = int.Parse(Console.ReadLine());
            foreach (var customer in _customerService.GetAllCustomers())
            {
                if (customer.Id == customerId)
                {
                    EditCustomerInformation(customer);
                }
            }

            goto ShowCustomerList;
            CustomerEndPoint: ;
        }

        void EditCustomerInformation(Customer Customer)
        {
            Console.WriteLine(Constants.UpdateCustomerIdOrNot);
            var updateCustomerIdAnswer = Console.ReadLine();
            if (updateCustomerIdAnswer == "yes")
            {
                Console.WriteLine(Constants.EnterNewCustomerId);
                Customer.Id = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(Constants.UpdateCustomerName);
            var updateCustomerNameAnswer = Console.ReadLine();
            if (updateCustomerNameAnswer == "yes")
            {
                Console.WriteLine(Constants.EnterNewCustomerName);
                Customer.FirstName = Console.ReadLine();
            }

            Console.WriteLine(Constants.UpdateCustomerSurname);
            var updateCustomerSurnameAnswer = Console.ReadLine();
            if (updateCustomerSurnameAnswer == "yes")
            {
                Console.WriteLine(Constants.EnterNewCustomerSurname);
                Customer.LastName = Console.ReadLine();
            }

            Console.WriteLine(Constants.UpdateNewCustomerBirthDate);
            var updateCustomerBirthdateAnswer = Console.ReadLine();
            if (updateCustomerBirthdateAnswer == "yes")
            {
                Console.WriteLine(Constants.EnterNewCustomerBirthDate);
                Customer.Birthday = DateTime.Parse(Console.ReadLine());
            }

            Console.WriteLine(Constants.UpdateCustomerEmail);
            var updateCustomerEmailAnswer = Console.ReadLine();
            if (updateCustomerEmailAnswer == "yes")
            {
                Console.WriteLine(Constants.EnterNewCustomerEmail);
                Customer.Email = Console.ReadLine();
            }

            Console.WriteLine(Constants.UpdateCustomerPhonenumber);
            var updateCustomerPhonenumberAnswer = Console.ReadLine();
            if (updateCustomerPhonenumberAnswer == "yes")
            {
                Console.WriteLine(Constants.EnterNewCustomerPhoneNUmber);
                Customer.PhoneNumber = int.Parse(Console.ReadLine());
            }
        }

        void GenreMenuOptions(int value)
        {
            switch (value)
            {
                case 1:
                    AddGenre();
                    break;
                case 2:
                    RemoveGenre();
                    break;
                case 3:
                    ListAllGenres();
                    break;
                case 4:
                    UpdateGenre();
                    break;
            }
        }

        void AddGenre()
        {
            Console.WriteLine(Constants.EnterGenreType);
            var genreType = Console.ReadLine();
            Genre genre = new Genre()
            {
                Type = genreType
            };
            _genreService.CreateNewGenre(genre);
        }

        void RemoveGenre()
        {
            var count = 0;
            ShowGenreList:
            Console.WriteLine(Constants.ShowAllGenresList);
            var answer = Console.ReadLine();
            if (answer == "yes")
            {
                ListAllGenres();
            }

            if (count == 1 && answer == "no")
            {
                goto GenreEndPoint;
            }

            count++;
            Console.WriteLine(Constants.EnterGenreIdToRemove);
            var genreId = int.Parse(Console.ReadLine());
            foreach (var genre in _genreService.GetAllGenre())
            {
                if (genre.Id == genreId)
                {
                    Console.WriteLine($"Id: {genre.Id} {genre.Type}");
                }
            }

            _genreService.DeleteGenre(genreId);
            goto ShowGenreList;
            GenreEndPoint: ;
        }

        void ListAllGenres()
        {
            foreach (var genre in _genreService.GetAllGenre())
            {
                Console.WriteLine($"Id: {genre.Id} {genre.Type}");
            }
        }

        void UpdateGenre()
        {
            var count = 0;
            ShowGenreList:
            Console.WriteLine(Constants.ShowAllGenresList);
            var answer = Console.ReadLine();
            if (answer == "yes")
            {
                ListAllGenres();
                if (count != 0)
                {
                    goto GenreEndPoint;
                }
            }

            if (count == 1 && answer == "no")
            {
                goto GenreEndPoint;
            }

            count++;
            Console.WriteLine(Constants.EnterGenreIdToUpdate);
            var genreId = int.Parse(Console.ReadLine());
            foreach (var genre in _genreService.GetAllGenre())
            {
                if (genre.Id == genreId)
                {
                    EditGenreInformation(genre);
                }
            }

            goto ShowGenreList;
            GenreEndPoint: ;
        }

        void EditGenreInformation(Genre genre)
        {
            Console.WriteLine(Constants.UpdateGenreIdOrNot);
            var updateGenreIdAnswer = Console.ReadLine();
            if (updateGenreIdAnswer == "yes")
            {
                Console.WriteLine(Constants.EnterNewGenreId);
                genre.Id = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(Constants.UpdateGenreName);
            var updategenreNameAnswer = Console.ReadLine();
            if (updategenreNameAnswer == "yes")
            {
                Console.WriteLine(Constants.EnterNewGenreName);
                genre.Type = Console.ReadLine();
            }

        }

        void FindMenuOptions(int value)
        {
            switch (value)
            {
                case 1:
                    FindVideo();
                    break;
                case 2:
                    FindCustomer();
                    break;
                case 3:
                    FindGenre();
                    break;
                case 4:
                    SearchAny();
                    break;
            }
        }

        void FindVideo()
        {
            Console.WriteLine(Constants.FindAnyVideoMatch);
            var find = Console.ReadLine();
            List<Video> result = new List<Video>();
            if (double.TryParse(find, out double value))
            {
                foreach (var video in _videoService.GetAllVideos().FindAll(video => video.Id == value)) result.Add(video);
            }

            foreach (var video in _videoService.GetAllVideos().FindAll(video => video.Title == find)) result.Add(video);
            foreach (var video in _videoService.GetAllVideos().FindAll(video => video.StoryLine == find)) result.Add(video);
            foreach (var video in _videoService.GetAllVideos().FindAll(video => video.Genre.Type == find)) result.Add(video);
            foreach (var video in _videoService.GetAllVideos().FindAll(video => video.ReleaseDate.ToString() == find)) result.Add(video);
            foreach (var cust in result)
            {
                Console.WriteLine($"Id:{cust.Id} {cust.Title} {cust.ReleaseDate} {cust.StoryLine} {cust.Genre}");
            }
        }

        Customer FindCustomer()
        {
            Console.WriteLine(Constants.FindAnyCustomerMatch);
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Please insert number");
            }

            var cust = _customerService.FindCustomerById(value);

            Console.WriteLine($"Id:{cust.Id} {cust.FirstName} {cust.LastName} {cust.Email} {cust.PhoneNumber} " +
                              $"{cust.Birthday.Year}.{cust.Birthday.Month}.{cust.Birthday.Day}");
            return cust;
        }

        void FindGenre()
        {
            Console.WriteLine(Constants.FindAnyGenreMatch);
            var find = Console.ReadLine();
            List<Genre> result = new List<Genre>();
            if (double.TryParse(find, out double value))
            {
                foreach (var genre in _genreService.GetAllGenre().FindAll(genre => genre.Id == value)) result.Add(genre);
            }

            foreach (var genre in _genreService.GetAllGenre().FindAll(genre => genre.Type == find)) result.Add(genre);
            foreach (var cust in result)
            {
                Console.WriteLine($"Id:{cust.Id} {cust.Type}");
            }
        }

        void SearchAny()
        {
            Console.WriteLine("God dammit!!! Still not Enough?");
        }


        void PrintMenu(int menuOption)
        {
            Console.Clear();
            PrintLine(Constants.PleaseSelectOption);

            switch (menuOption)
            {
                case 1:
                    PrintMenu(Enum.GetNames(typeof(VideoMenu)));
                    break;
                case 2:
                    PrintMenu(Enum.GetNames(typeof(CustomerMenu)));
                    break;
                case 3:
                    PrintMenu(Enum.GetNames(typeof(GenreMenu)));
                    break;
                case 4:
                    PrintMenu(Enum.GetNames(typeof(SearchMenu)));
                    break;
                default:
                    PrintMenu(Enum.GetNames(typeof(MainMenu)));
                    break;
            }
        }

        void PrintMenu(Array getValues)
        {
            for (int i = 0; i < getValues.Length; i++)
            {
                Console.WriteLine($" {i + 1}. {getValues.GetValue(i)}");
            }
        }

        void PrintLine(string value)
        {
            Console.WriteLine(value);
        }

        #region Data Initiliazation
        private void InitData()
        {
            Video video1 = new Video()
            {
                Title = "Star Wars",
                ReleaseDate = new DateTime(1991, 08, 02),
                Genre = new Genre() {Id = 1, Type = "Fantasy"},
                StoryLine = "Bing Pow Bum Bum"
            };
            Video video2 = new Video()
            {
                Title = "Liar Liar",
                ReleaseDate = new DateTime(1988, 02, 24),
                Genre = new Genre() {Id = 1, Type = "Comedy"},
                StoryLine = "Ha Ha Ha Ha"
            };
            Customer cust1 = new Customer()
            {
                FirstName = "Darius",
                LastName = "Tarvydas",
                Birthday = new DateTime(1990, 05, 06),
                Email = "tarvydasdarius@gmail.com",
                PhoneNumber = 86967868
            };
            Customer cust2 = new Customer()
            {
                FirstName = "Vytenis",
                LastName = "Urbonas",
                Birthday = new DateTime(1991, 09, 30),
                Email = "vytenisurbonas@gmail.com",
                PhoneNumber = 86967869
            };
            Genre gen1 = new Genre()
            {
                Type = "Horror"
            };
            Genre gen2 = new Genre()
            {
                Type = "Documentary"
            };
            _videoService.CreateNewVideo(video1);
            _videoService.CreateNewVideo(video2);
            _genreService.CreateNewGenre(gen1);
            _genreService.CreateNewGenre(gen2);
            _customerService.CreateCustomer(cust1);
            _customerService.CreateCustomer(cust2);
        }
        #endregion
       
    }
}