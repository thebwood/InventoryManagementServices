import { Button, Container, FormControl, InputLabel, MenuItem, Select, TextField } from "@mui/material";
import React, { Fragment } from "react";
import { MovieRatings } from "../../../app/models/movieRatings";
import { MovieSearch } from "../../../app/models/movieSearch";

interface ChildProps {
    MovieRatingsList: MovieRatings[];
    HandleSearch: (movieSearchFields: MovieSearch) => void;
}

const MovieSearchForm: React.FC<ChildProps> = (props) => {
    const [movieSearch, setMovieSearch] = React.useState<MovieSearch>({})
    const { MovieRatingsList, HandleSearch } = props;
    const { title, movieRatingsId, description } = movieSearch;

    return (
        <Container>
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
                        onChange={(e) => setMovieSearch({ ...movieSearch, title: e.target.value })}
                    ></TextField>

                </div>
                <div className="col-6">
                    <FormControl fullWidth>
                        <InputLabel>Movie Rating</InputLabel>
                        <Select
                            id="MovieRating"

                            value={movieRatingsId || undefined}
                            onChange={(e) => setMovieSearch({ ...movieSearch, movieRatingsId: e.target.value })}>
                            <MenuItem value={undefined}>Clear Selection</MenuItem>
                            {MovieRatingsList.map(rating => (
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
                            maxLength: 200
                        }}
                        onChange={(e) => setMovieSearch({ ...movieSearch, description: e.target.value })}
                    ></TextField>
                </div>
            </div>
            <div className="row mb-2 text-right">
                <Button className="mr-1" variant="contained" onClick={() => HandleSearch(movieSearch)}>Search</Button>

            </div>
        </Container>
    );
}

export default MovieSearchForm;