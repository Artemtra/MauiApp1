using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace MauiApp1.DB
{
    static class DBFile
    {
        static private List<Author> authorList  = new List<Author>();
        static private List<Movies> moviesList  = new List<Movies>();
        static private List<ListMovies> listMovies = new List<ListMovies>();

        

        public static async void SaveFileMovie()
        {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "movie.db");
            using (FileStream outputStream = File.Create(targetFile))
            {
                await JsonSerializer.SerializeAsync(outputStream, moviesList);
            }
            moviesList.Clear();
            LoadFileMovie();
        }

        public static async void LoadFileMovie()
        {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "movie.db");
            if (File.Exists(targetFile))
            {
                string a = File.ReadAllText(targetFile);
                moviesList = JsonSerializer.Deserialize<List<Movies>>(a);

            }
           
        }

        public static async void SaveFileAuthor()
        {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "author.db");
            using (FileStream outputStream = File.Create(targetFile))
            {
                await JsonSerializer.SerializeAsync(outputStream, authorList);
            }
            authorList.Clear();
            LoadFileAuthor();
        }
        public static async void LoadFileAuthor()
        {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "author.db");
            if (File.Exists(targetFile))
            {
                string a = File.ReadAllText(targetFile);

                authorList = JsonSerializer.Deserialize<List<Author>>(a);

            }
       
        }
    
    }




}
