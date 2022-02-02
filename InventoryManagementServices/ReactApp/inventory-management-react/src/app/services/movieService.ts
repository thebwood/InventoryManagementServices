import agent from "../api/agent";
import { Movie } from "../models/movies/movie";
import { MovieSearch } from "../models/movies/movieSearch";

export default class MovieService {
    searchMovies = async (MovieSearchFields: MovieSearch) => {
        try {
            return await agent.Movies.search(MovieSearchFields);
        } 
        catch (error) {
            console.log(error);
        }

    }
    
    loadMovies = async () => {
        try {
            return await agent.Movies.list();
        } 
        catch (error) {
            console.log(error);
        }
    }

    loadMovie = async (id: string) => {
        try {
            return await agent.Movies.details(id);
        } 
        catch (error) {
            console.log(error);
        }
    }

    loadMovieRatings = async () =>{
        try {
            return await agent.Movies.movieRatings();
        } 
        catch (error) {
            console.log(error);
        }
    }

    saveMovie = async (movie: Movie) => {
        try {
            return await agent.Movies.save(movie);
        } 
        catch (error) {
            console.log(error);
        }
    }
}