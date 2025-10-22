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
    class DBFile
    {
        private List<Author> authorList  = new List<Author>();
        private List<Movies> moviesList  = new List<Movies>();
        private  List<ListMovies> listMovies = new List<ListMovies>();
        private List<int> ints = new List<int>();
        public async Task SaveFileDiscriminant()
        {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "discriminant.db");
            using (FileStream outputStream = File.Create(targetFile))
            {
                await JsonSerializer.SerializeAsync(outputStream, ints);
            }
        }
        public async Task LoadDiscriminant()
        {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "discriminant.db");
            if (File.Exists(targetFile))
            {
                string a = await File.ReadAllTextAsync(targetFile);
                ints = JsonSerializer.Deserialize<List<int>>(a);

            }

        }

        public  async Task<IReadOnlyList<Author>> GetAuthorList()
        {
         await Task.Delay(1000);
         return authorList;

        }
        public async  Task<IReadOnlyList<Movies>> GetMovieList()
        {
            await Task.Delay(1000);
            return moviesList;

        }
        public async Task<IReadOnlyList<ListMovies>> GetMovieAuthorList()
        {
            await Task.Delay(1000);
            return listMovies;

        }

        public async Task DelAuthor(int id)
        {
            foreach (Author author in authorList) 
            { 
            if(author.Id == id)
                {
                    authorList.Remove(author);
                }          
            }
        }
        public async Task DelMovie(int id)
        {
            foreach (Movies author in moviesList)
            {
                if (author.Id == id)
                {
                    moviesList.Remove(author);
                }
            }
        }
        public async Task DelAuthorMovies(int idAuthor,int idMovies)
        {
            foreach (ListMovies author in listMovies)
            {
                if (author.IdAuthor == idAuthor && author.IdMovies == idMovies  )
                {
                    listMovies.Remove(author);
                }
            }
        }

        public async Task AddAuthor(string name,string secondName,string thrityName,DateTime birthDay)
        {

            LoadDiscriminant();
            Author author = new Author();
            author.Id = ints[0];
            author.Name = name;
            author.SecondName = secondName;
            author.BirthDay = birthDay;
            authorList.Add(author);
            ints[0] = ints[0]+1;
            SaveFileDiscriminant();
        }
        public async Task AddMovies(string name ,string description,DateTime date)
        {
            LoadDiscriminant();
            Movies movies = new Movies();
            movies.Id = ints[1];
            movies.Name = name;
            movies.Description = description;
            movies.Date = date;
            moviesList.Add(movies);
            ints[1] = ints[1] + 1;
            SaveFileDiscriminant();
        }
        public async Task AddMovies(int IdAuthor,int IdMovies, string Title,string FirstName,string LastName, string SecondName)
        {
            LoadDiscriminant();
            ListMovies listMoviesAdd = new ListMovies();
            listMoviesAdd.Id = ints[2];
            listMoviesAdd.IdAuthor = IdAuthor;
            listMoviesAdd.IdMovies = IdMovies;
            listMoviesAdd.Title = Title;
            listMoviesAdd.FirstName = FirstName;
            listMoviesAdd.LastName = LastName;
            listMoviesAdd.SecondName = SecondName;

            listMovies.Add(listMoviesAdd);
            ints[2] = ints[2] + 1;
            SaveFileDiscriminant();

        }

        public  async Task SaveFileMovie()
        {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "movie.db");
            using (FileStream outputStream = File.Create(targetFile))
            {
                await JsonSerializer.SerializeAsync(outputStream, moviesList);
            }
           
        }

        public async Task LoadFileMovie()
        {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "movie.db");
            if (File.Exists(targetFile))
            {
                string a = await File.ReadAllTextAsync(targetFile);
                moviesList = JsonSerializer.Deserialize<List<Movies>>(a);
                
            }
           
        }

        public async Task SaveFileAuthor()
        {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "author.db");
            using (FileStream outputStream = File.Create(targetFile))
            {
                await JsonSerializer.SerializeAsync(outputStream, authorList);
            }
        }
        public async Task LoadFileAuthor()
        {

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "author.db");
            if (File.Exists(targetFile))
            {
                string a = await File.ReadAllTextAsync(targetFile);

                authorList =  JsonSerializer.Deserialize<List<Author>>(a);

            }
       
        }
    
    }




}
