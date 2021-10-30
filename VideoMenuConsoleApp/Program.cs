using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VideoMenuConsoleApp
{
    internal static class Program
    {
        private static int _currentMenu = 0;
        private static int _videoId = 1;
        private static int _customerId = 1;
        private static int _genreId = 1;
        private static List<Video> _videos = new List<Video>();
        private static List<Customer> _customers = new List<Customer>();
        private static List<Genre> _genres = new List<Genre>();
        private static void Main()
        {
            Video video1 = new Video()
            {
                Id = _videoId++,
                Name = "Star Wars",
                ReleaseDate = new DateTime(1991, 08, 02 ),
                Genre = new Genre(){Id = 1,Type = "Fantasy"},
                StoryLine = "Bing Pow Bum Bum"
            };
            Video video2 = new Video()
            {
                Id = _videoId++,
                Name = "Liar Liar",
                ReleaseDate = new DateTime(1988, 02, 24 ),
                Genre = new Genre(){Id = 1,Type = "Comedy"},
                StoryLine = "Ha Ha Ha Ha"
            };
            Customer cust1 = new Customer()
            {
                Id = _customerId++,
                Name = "Darius",
                SurName = "Tarvydas",
                Birthday = new DateTime(1990,05,06),
                Email = "tarvydasdarius@gmail.com",
                PhoneNumber = 86967868
            };
            Customer cust2 = new Customer()
            {
                Id = _customerId++,
                Name = "Vytenis",
                SurName = "Urbonas",
                Birthday = new DateTime(1991,09,30),
                Email = "vytenisurbonas@gmail.com",
                PhoneNumber = 86967869
            };
            Genre gen1 = new Genre()
            {
                Id = _genreId++,
                Type = "Horror"
            };
            Genre gen2 = new Genre()
            {
                Id = _genreId++,
                Type = "Documentary"
            };
            _videos.Add(video1);
            _videos.Add(video2);
            _genres.Add(gen1);
            _genres.Add(gen2);
            _customers.Add(cust1);
            _customers.Add(cust2);
            ShowMainMenu();
        }

        private static void ShowMainMenu()
        {
            var selectedOption = 0;
            var selectedSubOption = 0;
            MainMenu:
            while (_currentMenu == 0 & selectedOption != 5)
            {
                selectedOption = OptionChooser(); //skipp
                if (selectedOption == 5)
                {
                    break;
                }

                if (selectedOption is > 0 and < 5)
                {
                    _currentMenu = selectedOption; 
                } 
                SubMenu: 
                PrintMenu(_currentMenu); //skipp
                while (_currentMenu > 0 && selectedSubOption != 5)
                {
                    selectedSubOption = OptionChooser();
                    if (selectedSubOption == 5) 
                    {
                        _currentMenu = 0;
                        PrintMenu(_currentMenu); //skipp
                        selectedSubOption = 0;
                        goto MainMenu; //skipp
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
        
        private static int OptionChooser()
        {
            PrintMenu(_currentMenu);
            int selectionMainMenu = 0;
            while (!int.TryParse(Console.ReadLine(), out selectionMainMenu) || selectionMainMenu is < 1 or > 5)
            {
                PrintMenu(_currentMenu);
            }
            return selectionMainMenu;
        }

        private static void SelectSubMenu(int value, int value2)
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

        private static void VideoMenuOptions( int value)
        {
            switch (value)
            {
                case 1 :
                    AddVideo();
                    break;
                case 2 :
                    RemoveVideo();
                    break;
                case 3 :
                    ListAllVideos();
                    break;
                case 4 :
                    UpdateVideo();
                    break;
            }
        }
        
        private static void AddVideo()
        {
            Video video = new Video();
            video.Id = _customerId++;
            Console.WriteLine(Constants.EnterVideoName);
            video.Name = Console.ReadLine();
            Console.WriteLine(Constants.EnterVideoGenre);
            video.Genre = new Genre()
            {
                Type = Console.ReadLine()
            };
            Console.WriteLine(Constants.EnterReleaseDate);
            video.ReleaseDate = DateTime.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine(Constants.EnterVideoStoryLine);
            video.StoryLine = Console.ReadLine();
            _videos.Add(video);
        }
        
        private static void RemoveVideo()
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
            foreach (var video in _videos)
            {
                if (video.Id == videoId)
                {
                    Console.WriteLine($"{Constants.VideoRemoved} {video.Id}.{video.Name} {video.ReleaseDate.Day}.{video.ReleaseDate.Month}.{video.ReleaseDate.Year} {video.Genre.Type} {video.StoryLine}");
                }
            }
            _videos.Remove(_videos.Find(video => video.Id == videoId ));
            goto ShowVideoList;
            VideoEndPoint:;
        }
        
        private static void ListAllVideos()
        {
            foreach (var video in _videos)
            {
                Console.WriteLine($"{video.Id}.{video.Name} {video.ReleaseDate.Day}.{video.ReleaseDate.Month}.{video.ReleaseDate.Year} {video.Genre.Type} {video.StoryLine}");
            }
        }

        private static void UpdateVideo()
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
            foreach (var video in _videos)
            {
                if (video.Id == videoId)
                {
                    EditVideoInformation(video);
                }
            }
            
            goto ShowVideoList;
            VideoEndPoint:;
        }

        private static void EditVideoInformation(Video video)
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
                video.Name = Console.ReadLine();
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

        private static void CustomerMenuOptions(int value)
        {
            switch (value)
            {
                case 1 :
                    AddCustomer();
                    break;
                case 2 :
                    RemoveCustomer();
                    break;
                case 3 :
                    ListAllCustomers();
                    break;
                case 4 :
                    UpdateCustomer();
                    break;
            }
        }
        
        private static void AddCustomer()
        {
            Customer customer = new Customer();
            customer.Id = _customerId++;
            Console.WriteLine(Constants.EnterCustomerName);
            customer.Name = Console.ReadLine();
            Console.WriteLine(Constants.EnterCustomerSurName);
            customer.SurName = Console.ReadLine();
            Console.WriteLine(Constants.EnterBirthday);
            customer.Birthday = DateTime.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine(Constants.EnterEmail);
            customer.Email = Console.ReadLine();
            Console.WriteLine(Constants.EnterPhoneNumber);
            customer.PhoneNumber = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            _customers.Add(customer);
        }
        private static void RemoveCustomer()
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
            foreach (var customer in _customers)
            {
                if (customer.Id == customerId)
                {
                    Console.WriteLine($"Id:{customer.Id} {customer.Name} {customer.SurName} {customer.Email} {customer.PhoneNumber} " +
                                      $"{customer.Birthday.Year}.{customer.Birthday.Month}.{customer.Birthday.Day}");
                }
            }
            _customers.Remove(_customers.Find(customer => customer.Id == customerId ));
            goto ShowCustomerList;
            CustomerEndPoint:;
        }
        private static void ListAllCustomers()
        {
            foreach (var customer in _customers)
            {
                Console.WriteLine($"Id:{customer.Id} {customer.Name} {customer.SurName} {customer.Email} {customer.PhoneNumber} " +
                                  $"{customer.Birthday.Year}.{customer.Birthday.Month}.{customer.Birthday.Day}");
            }
        }
        private static void UpdateCustomer()
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
            foreach (var customer in _customers)
            {
                if (customer.Id == customerId)
                {
                    EditCustomerInformation(customer);
                }
            }
            
            goto ShowCustomerList;
            CustomerEndPoint:;
        }
        
        private static void EditCustomerInformation(Customer Customer)
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
                Customer.Name = Console.ReadLine();
            }
            Console.WriteLine(Constants.UpdateCustomerSurname);
            var updateCustomerSurnameAnswer = Console.ReadLine();
            if (updateCustomerSurnameAnswer == "yes")
            {
                Console.WriteLine(Constants.EnterNewCustomerSurname);
                Customer.SurName = Console.ReadLine();
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

        private static void GenreMenuOptions(int value)
        {
            switch (value)
            {
                case 1 :
                    AddGenre();
                    break;
                case 2 :
                    RemoveGenre();
                    break;
                case 3 :
                    ListAllGenres();
                    break;
                case 4 :
                    UpdateGenre();
                    break;
            }
        }
        
        private static void AddGenre()
        {
            Console.WriteLine(Constants.EnterGenreType);
            var genreType = Console.ReadLine();
            Genre genre = new Genre()
            {
                Id = _genreId++,
                Type = genreType
            };
            _genres.Add(genre);
        }
        private static void RemoveGenre()
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
            foreach (var genre in _genres)
            {
                if (genre.Id == genreId)
                {
                    Console.WriteLine($"Id: {genre.Id} {genre.Type}" );
                }
            }
            _genres.Remove(_genres.Find(genre => genre.Id == genreId ));
            goto ShowGenreList;
            GenreEndPoint:;
        }

        private static void ListAllGenres()
        {
            foreach (var genre in _genres)
            {
                Console.WriteLine($"Id: {genre.Id} {genre.Type}" );
            }
        }
        
        private static void UpdateGenre()
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
            foreach (var genre in _genres)
            {
                if (genre.Id == genreId)
                {
                    EditGenreInformation(genre);
                }
            }
            
            goto ShowGenreList;
            GenreEndPoint:;
        }
        
        private static void EditGenreInformation(Genre genre)
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

        private static void FindMenuOptions(int value)
        {
            switch (value)
            {
                case 1 :
                    FindVideo();
                    break;
                case 2 :
                    FindCustomer();
                    break;
                case 3 :
                    FindGenre();
                    break;
                case 4 :
                    SearchAny();
                    break;
            }
        }
        
        private static void FindVideo()
        {
            Console.WriteLine(Constants.FindAnyVideoMatch);
            var find = Console.ReadLine();
            List<Video> result = new List<Video>();
            if (double.TryParse(find, out double value))
            {
                foreach (var video in _videos.FindAll(video => video.Id == value)) result.Add(video);
            }

            foreach (var video in _videos.FindAll(video => video.Name == find)) result.Add(video);
            foreach (var video in _videos.FindAll(video => video.StoryLine == find)) result.Add(video);
            foreach (var video in _videos.FindAll(video => video.Genre.Type == find)) result.Add(video);
            foreach (var video in _videos.FindAll(video => video.ReleaseDate.ToString() == find)) result.Add(video);
            foreach (var cust in result)
            {
                Console.WriteLine($"Id:{cust.Id} {cust.Name} {cust.ReleaseDate} {cust.StoryLine} {cust.Genre}");
            }
        }

        private static void FindCustomer()
        {
            Console.WriteLine(Constants.FindAnyCustomerMatch);
            var find = Console.ReadLine();
            List<Customer> result = new List<Customer>();
            if (double.TryParse(find, out double value))
            {
                foreach (var customer1 in _customers.FindAll(customer => customer.Id == value)) result.Add(customer1);
                foreach (var customer1 in _customers.FindAll(customer => customer.PhoneNumber == value)) result.Add(customer1);
            }

            foreach (var customer1 in _customers.FindAll(customer => customer.Name == find)) result.Add(customer1);
            foreach (var customer1 in _customers.FindAll(customer => customer.SurName == find)) result.Add(customer1);
            foreach (var customer1 in _customers.FindAll(customer => customer.Email == find)) result.Add(customer1);
            foreach (var customer1 in _customers.FindAll(customer => customer.Birthday.ToString() == find)) result.Add(customer1);
            foreach (var cust in result)
            {
                Console.WriteLine($"Id:{cust.Id} {cust.Name} {cust.SurName} {cust.Email} {cust.PhoneNumber} " +
                                  $"{cust.Birthday.Year}.{cust.Birthday.Month}.{cust.Birthday.Day}");
            }
        }

        private static void FindGenre()
        {
            Console.WriteLine(Constants.FindAnyGenreMatch);
            var find = Console.ReadLine();
            List<Genre> result = new List<Genre>();
            if (double.TryParse(find, out double value))
            {
                foreach (var genre in _genres.FindAll(genre => genre.Id == value)) result.Add(genre);
            }
            foreach (var genre in _genres.FindAll(genre => genre.Type == find)) result.Add(genre);
            foreach (var cust in result)
            {
                Console.WriteLine($"Id:{cust.Id} {cust.Type}");
            }
        }

        private static void SearchAny()
        {
            Console.WriteLine("God dammit!!! Still not Enough?");
        }
        

        private static void PrintMenu(int menuOption)
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

        private static void PrintMenu(Array getValues)
        {
            for (int i = 0; i < getValues.Length; i++)
            {
                Console.WriteLine($" { i+1 }. {getValues.GetValue(i)}");
            }
        }
        
        private static void PrintLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}