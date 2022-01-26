import agent from "../api/agent";
import { Movie } from "../models/movie";

export default class MovieService {
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
}