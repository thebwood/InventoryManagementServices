import { Alert, Button, Container, FormControl, InputLabel, MenuItem, Select, TextField } from '@mui/material';
import moment from 'moment';
import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { Movie } from '../../../app/models/movies/movie';
import { MovieRatings } from '../../../app/models/movies/movieRatings';
import { useService } from '../../../app/services/services';

const MovieDetail: React.FC = () => {
  const navigate = useNavigate();
  const { id } = useParams();
  const { movieService } = useService();
  const { loadMovie, loadMovieRatings, saveMovie } = movieService;

  const [movie, setMovie] = useState<Movie>(new Movie());
  const [movieRatings, setMovieRatings] = useState<MovieRatings[]>([]);
  const [errorMessages, setErrorMessages] = useState<string[]>([]);
  const { title, description, movieRatingsId, releaseDate, hours, minutes } = movie;
  useEffect(() => {
    loadMovieRatings().then(movieRatingDetails => {
      if (movieRatingDetails)
        setMovieRatings(movieRatingDetails);
    });

    if (id) {
      loadMovie(id).then(movieDetail => {
        if (movieDetail)
          setMovie(movieDetail);
      });
    }
  }, [loadMovie]);
  const handleSave = () => {
    setErrorMessages([]);
    saveMovie(movie).then(errors => {
      if (errors && errors.length > 0) {
        setErrorMessages(errors);
      }
      else {
        navigate("/movies");
      }
    })

  }

  const handleCancel = () => {
    navigate("/movies");
  }
  return (
    <Container maxWidth="md">

      {(errorMessages && errorMessages.length > 0) && errorMessages.map(error => (
        <Alert severity="error">{error}</Alert>
      ))}
      {id ? <h4>Game: {id}</h4> : <h4>Add Game</h4>}
      {
        movie &&
        <div className="container">
          <div className="row mb-2">
            <div className="col-6">
              <TextField
                id="Title"
                label="Title"
                fullWidth
                value={title || ''}
                inputProps={{
                  maxLength: 50
                }}
                onChange={(e) => setMovie({ ...movie, title: e.target.value })}
              ></TextField>

            </div>
            <div className="col-6">
              <FormControl fullWidth>
                <InputLabel>Rating</InputLabel>
                <Select
                  id="MovieRating"
                  value={movieRatingsId || ""}
                  onChange={(e) => setMovie({ ...movie, movieRatingsId: e.target.value })}>
                  <MenuItem value="">Clear Selection</MenuItem>
                  {movieRatings.map(rating => (
                    <MenuItem key={rating.id} value={rating.id}>
                      {rating.rating}
                    </MenuItem>
                  ))}
                </Select>
              </FormControl>

            </div>
          </div>
          <div className="row mb-2">
            <div className="col-12">
              <TextField
                id="Description"
                label="Description"
                fullWidth
                value={description || ''}
                inputProps={{
                  maxLength: 2000
                }}
                onChange={(e) => setMovie({ ...movie, description: e.target.value })}
              ></TextField>
            </div>
          </div>
          <div className="row mb-2">
            <div className="col-6">
              <TextField
                id="Hours"
                label="Hours"
                type="number"
                fullWidth
                value={hours}
                onChange={(e) => setMovie({ ...movie, hours: e.target.value })}
                InputLabelProps={{
                  shrink: true,
                }}
              />
            </div>
            <div className="col-6">
              <TextField
                id="Minutes"
                label="Minutes"
                type="number"
                fullWidth
                value={minutes}
                onChange={(e) => setMovie({ ...movie, minutes: e.target.value })}
                InputLabelProps={{
                  shrink: true,
                }}
              />
            </div>
          </div>

          <div className="row mb-2">
            <div className="col-6">
              <TextField
                id="ReleaseDate"
                label="Release Date"
                type="date"
                value={releaseDate ? moment(releaseDate).format("YYYY-MM-DD") : ""}
                fullWidth
                onChange={(e) => setMovie({ ...movie, releaseDate: e.target.value })}
                InputLabelProps={{
                  shrink: true,
                }}
              />
            </div>
          </div>


          <div className="row mb-2">
            <div className="col-12 text-right">
              <Button className="mr-1" variant="contained" onClick={() => handleSave()}>Save</Button>
              <Button variant="contained" color="error" onClick={() => handleCancel()}>Cancel</Button>
            </div>
          </div>

        </div>

      }

    </Container >

  );

};


export default MovieDetail;