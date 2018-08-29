using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.Core.DomainService;
using VideoMenu.Core.Entity;
using VideoMenu.Infrastructure.Static.Data.Repositories;

namespace VideoMenu
{
    public class Printer
    {
        static IVideoRepository VideoRepository = new VideoRepository();
        private static string exit = "";

        public Printer()
        {
            while (exit != "exit") {
                Console.Clear();
                DefaultMenu();
            }
        }

        void DefaultMenu()
        {
            Console.WriteLine("Select an option");
            Console.WriteLine("1. Add video \n2. List videos \n3. Update video \n4. Delete video \n5. Exit");
            switch (Console.ReadLine()) {
                case "1": {
                    AddMenu();
                    break;
                }
                case "2": {
                    Console.WriteLine("List videos (id title length)");
                    ListVideos();
                    exit = Console.ReadLine();
                    break;
                }
                case "3": {
                    UpdateMenu();
                    break;
                }
                case "4": {
                    DeleteMenu();
                    break;
                }
                case "5": {
                    exit = "exit";
                    break;
                }
                default: {
                    Console.WriteLine("Invalid choice");
                    break;
                }
            }
        }

        void DeleteMenu()
        {
            Console.WriteLine("Delete video");
            ListVideos();
            Console.Write("Select a video: ");
            Video selected = VideoRepository.ReadById(ToNumber());
            VideoRepository.Delete(selected.Id);
            Console.WriteLine("Video deleted SUCCESSFULLY!");
            exit = Console.ReadLine();
        }

        void AddMenu()
        {
            Console.WriteLine("Add video");

            var newvideo = new Video();
            Console.Write("Title: ");
            newvideo.Title = Console.ReadLine();

            Console.Write("Length (in minutes): ");
            newvideo.Length = ToNumber();
            VideoRepository.Create(newvideo);
            Console.WriteLine("Video added SUCCESSFULLY!");
            exit = Console.ReadLine();
        }

        void ListVideos()
        {
            foreach (var v in VideoRepository.ReadAll()) {
                Console.WriteLine(v.ToString());
            }
        }

        void UpdateMenu()
        {
            Console.WriteLine("Update video");
            ListVideos();
            Console.WriteLine("Select a video to update or type \"exit\"");
            Video selected = VideoRepository.ReadById(ToNumber());
            bool invalid = false;
            while (!invalid) {
                Console.WriteLine("Select a property \n1. Title \n2. Length");
                switch (Console.ReadLine()) {
                    case "1": {
                        Console.WriteLine("Current Title: {0}", selected.Title);
                        Console.Write("New Title: ");
                        selected.Title = Console.ReadLine();
                        invalid = true;
                        break;
                    }
                    case "2": {
                        Console.WriteLine("Current Length: {0}", selected.Length);
                        Console.Write("New Length: ");
                        selected.Length = ToNumber();
                        invalid = true;
                        break;
                    }
                    default: {
                        Console.WriteLine("Invalid choice");
                        invalid = false;
                        break;
                    }
                }
            }
            exit = Console.ReadLine();
        }

        int ToNumber()
        {
            int a = 0;
            while (!int.TryParse(Console.ReadLine(), out a)) {
                Console.WriteLine("Non-numeric input");
                Console.Write("New: ");
            }
            return a;
        }

        #region MyRegion

        #endregion
    }
}
