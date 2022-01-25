import React, { FC, Fragment, useEffect } from "react";
import { useService } from "../../app/services/services";
import MoviesGrid from "./components/moviesGrid";
import "./Movies.scss";

const Movies = () => {
    const {movieService} = useService();
    const { loadMovies } = movieService;

    useEffect(() => {
        loadMovies();
    }, [loadMovies]); 


    return (
        <Fragment>
            <h1>Movies</h1>
            <MoviesGrid Movies={movieService.movies}></MoviesGrid>
        </Fragment>
    );
};


export default Movies;