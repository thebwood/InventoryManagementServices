import { Paper } from '@mui/material';
import React, {Fragment, useEffect, useState} from 'react';
import { useParams } from 'react-router-dom';
import { Movie } from '../../../app/models/movie';
import { useService } from '../../../app/services/services';
import MovieDetail from '../components/movieDetail';




const AddMovie: React.FC =()=> {
    const [movie, setMovie] = useState<Movie>(new Movie);
    const {movieService} = useService();


    return (
        <Fragment>
            <h1>New Movie</h1>
            <Paper>
                <MovieDetail Movie={movie}></MovieDetail>
            </Paper>

        </Fragment>
    );
}


export default AddMovie;