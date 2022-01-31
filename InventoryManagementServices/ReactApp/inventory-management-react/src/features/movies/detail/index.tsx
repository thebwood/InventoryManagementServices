import { Paper, TextField } from '@mui/material';
import React, { Fragment, useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Movie } from '../../../app/models/movie';
import { useService } from '../../../app/services/services';



const MovieDetail: React.FC = () => {
  const { id } = useParams();
  const { movieService } = useService();
  const { loadMovie } = movieService;

  const [movie, setMovie] = useState<Movie>(new Movie());
  const { title, description } = movie;
  useEffect(() => {
    if (id) {
      loadMovie(id).then(movieDetail => {
        if (movieDetail)
          setMovie(movieDetail);
      });
    }
  }, [loadMovie]);

  return (
    <Fragment>
      {id ? <h3>Movie: {id}</h3> : <h3>Add Movie</h3>}
      <Paper>
        {
          movie &&
          <div className="container">
            <div className="row">
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


            </div>
            <div className="row">
              <div className="col-12">
                <TextField
                  id="Description"
                  label="Description"
                  fullWidth
                  value={description || ''}
                  inputProps={{
                    maxLength: 200
                  }}
                  onChange={(e) => setMovie({ ...movie, description: e.target.value })}
                ></TextField>
              </div>
            </div>
          </div>
        }

      </Paper>

    </Fragment>
  );

};


export default MovieDetail;