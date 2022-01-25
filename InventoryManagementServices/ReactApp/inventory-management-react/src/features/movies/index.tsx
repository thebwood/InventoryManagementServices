import React, { FC, Fragment, useEffect } from "react";
import { useService } from "../../app/services/services";
import MoviesGrid from "./components/moviesGrid";
import "./Movies.scss";

const Movies = () => {
    const {movieService} = useService();
    const { movies, loadMovies } = movieService;

    useEffect(() => {
        loadMovies();
    }, [loadMovies]); 


    return (
        <Fragment>
            <h1>Movies</h1>
            
            {(movies && movies.length > 0) && 
                <MoviesGrid Movies={movies}></MoviesGrid>
            }
            
            {(!movies || movies.length == 0)  &&
                <div>No movies are available</div>
            }

        </Fragment>
    );
};


export default Movies;