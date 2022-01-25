import React, { FC, Fragment, useEffect, useState } from "react";
import { Movie } from "../../app/models/movie";
import { useService } from "../../app/services/services";
import MoviesGrid from "./components/moviesGrid";
import "./Movies.scss";

const Movies = () => {
    const [movies, setMovies] = useState<Movie[]>([]);

    const {movieService} = useService();
    const { loadMovies } = movieService;

    useEffect(() => {
        loadMovies().then(movieList =>{
            if(movieList)
                setMovies(movieList);
        });
    }, [loadMovies]); 


    return (
        <Fragment>
            <h1>Movies</h1>
            <MoviesGrid Movies={movies}></MoviesGrid>
  
        </Fragment>
    );
};


export default Movies;