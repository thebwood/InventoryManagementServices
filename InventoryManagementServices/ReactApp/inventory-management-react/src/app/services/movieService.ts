import agent from "../api/agent";
import { Movie } from "../models/movie";

export default class MovieService {
    movies: Movie[] = [];

    loadMovies = async () => {
        try {
            this.movies = await agent.Movies.list();
        } 
        catch (error) {
            console.log(error);
        }
    }

}