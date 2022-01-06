using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Filmy.Data.Base;
using Filmy.Models;

namespace Filmy.Data.Services
{
    public interface IMovieServices : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);

        Task<List<Movie>> SearchMovieAsync(string hledej);
    }
}
