import { Paper } from '@mui/material';
import React, {Fragment, useEffect, useState} from 'react';
import { useParams } from 'react-router-dom';
import { Movie } from '../../../app/models/movie';
import { useService } from '../../../app/services/services';
import MovieDetail from '../components/movieDetail';




const EditMovie: React.FC =()=> {
    const {id} = useParams();
    const [movie, setMovie] = useState<Movie>(new Movie);
    const {movieService} = useService();
    const {loadMovie} = movieService;

    useEffect(() => {
        if(id)
        {
            loadMovie(id).then(movieDetail =>{
                if(movieDetail)
                    setMovie(movieDetail);
            });
        }
    }, [loadMovie]); 

    return (
        <Fragment>
            <h1>Movie: {id}</h1>
            <Paper>
                <MovieDetail Movie={movie}></MovieDetail>
            </Paper>

        </Fragment>
    );
}


export default EditMovie;