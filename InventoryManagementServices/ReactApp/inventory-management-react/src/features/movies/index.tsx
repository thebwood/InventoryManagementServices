import React, { Fragment, useEffect, useState } from "react";
import { MovieRatings } from "../../app/models/movieRatings";
import { MovieSearch } from "../../app/models/movieSearch";
import { MovieSearchResults } from "../../app/models/movieSearchResults";
import { useService } from "../../app/services/services";
import MovieSearchForm from "./components/movieSearchForm";
import MoviesGrid from "./components/moviesGrid";
import "./Movies.scss";

const Movies: React.FC = () => {
    const [movies, setMovies] = useState<MovieSearchResults[]>([]);
    const [movieRatings, setMovieRatings] = useState<MovieRatings[]>([]);
    const {movieService} = useService();
    const { loadMovieRatings, searchMovies} = movieService;


    
    useEffect(() => {
        loadMovieRatings().then(movieRatingsList => {
            if (movieRatingsList)
                setMovieRatings(movieRatingsList);
        });


        searchMovies(new MovieSearch).then(moviesList =>{
            if(moviesList)
                setMovies(moviesList);
        });
    }, [loadMovieRatings, searchMovies]); 

    const searchMoviesList = (movieSearchFields: MovieSearch) =>{
        searchMovies(movieSearchFields).then(moviesList =>{
            if(moviesList)
                setMovies(moviesList);
        });

    }
    return (
        <Fragment>
            <h1>Movies</h1>
            <MovieSearchForm MovieRatingsList={movieRatings} HandleSearch={ searchMoviesList }></MovieSearchForm>
            <MoviesGrid Movies={movies}></MoviesGrid>
  
        </Fragment>
    );
};


export default Movies;