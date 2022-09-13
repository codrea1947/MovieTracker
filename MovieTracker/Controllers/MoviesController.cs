using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTracker.Models.Dto;
using MovieTracker.Models.Entities;
using MovieTracker.Services.Interfaces;

namespace MovieTracker.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
       // private readonly IMapper _mapper;
        private readonly ILogger<MoviesController> _logger;
        private readonly IMoviesService _moviesService;
        private readonly IMapper _mapper;
        public MoviesController(
            ILogger<MoviesController> logger, 
            IMoviesService moviesService,
            IMapper mapper)
        {
            _logger = logger;
            _moviesService = moviesService;
            _mapper = mapper;   
        }

        [HttpGet("getAllMovies")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieResponse[]))]
        public async Task<ActionResult<IEnumerable<MovieResponse>>> GetAllMovies()
        {
            var movies = await _moviesService.GetAllAsync(); 
            
            return _mapper.Map<MovieResponse[]>(movies);    
        }

        [HttpGet("GetMovieById/{movieId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieResponse))]
        public async Task<ActionResult<MovieResponse>> GetMovieById(
            int movieId)
        {
           var movie = await _moviesService.GetAsync(movieId);

           return _mapper.Map<MovieResponse>(movie);    

        }

        [HttpPost("createMovie")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MovieResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovieResponse>> CreateMovie(
            MovieRequest movieRequest)
        {
            var movie = _mapper.Map<Movie>(movieRequest);

            var outMovie = await _moviesService.CreateAsync(movie, movieRequest.MovieTypesId);

            return CreatedAtAction(
                nameof(GetMovieById),
                new { movieId = outMovie.Id },
                _mapper.Map<MovieResponse>(outMovie));
        }


        [HttpPut("updateMovie/{movieId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<MovieResponse>> UpDateMovie(
            int movieId,
            MovieRequest movieRequest)
        {
            var movie = await _moviesService.GetAsync(movieId);

            if (movie == null)
            {
                return NotFound();
            }

            _mapper.Map(movieRequest, movie);

            Movie updatedMovie = await _moviesService.UpdateAsync(movieId, movie, movieRequest.MovieTypesId);

            if (updatedMovie == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MovieResponse>(updatedMovie));

        }

        [HttpDelete("deleteMovie/{movieId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(MovieResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> DeleteMovie(int movieId)
        {
            var movie = await _moviesService.DeleteAsync(movieId);

            if (movie == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
