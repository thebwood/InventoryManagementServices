import { Button, Container, FormControl, InputLabel, MenuItem, Select, TextField } from "@mui/material";
import React, { Fragment } from "react";
import { GameRatings } from "../../../app/models/games/gameRatings";
import { GameSearch } from "../../../app/models/games/gameSearch";

interface ChildProps {
    GameRatingsList: GameRatings[];
    HandleSearch: (gameSearchFields: GameSearch) => void;
}

const GameSearchForm: React.FC<ChildProps> = (props) => {
    const [gameSearch, setGameSearch] = React.useState<GameSearch>({})
    const { GameRatingsList, HandleSearch } = props;
    const { title, gameRatingsId, description } = gameSearch;

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
                        onChange={(e) => setGameSearch({ ...gameSearch, title: e.target.value })}
                    ></TextField>

                </div>
                <div className="col-6">
                    <FormControl fullWidth>
                        <InputLabel>Game Rating</InputLabel>
                        <Select
                            id="GameRating"

                            value={gameRatingsId || undefined}
                            onChange={(e) => setGameSearch({ ...gameSearch, gameRatingsId: e.target.value })}>
                            <MenuItem value={undefined}>Clear Selection</MenuItem>
                            {GameRatingsList.map(rating => (
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
                        onChange={(e) => setGameSearch({ ...gameSearch, description: e.target.value })}
                    ></TextField>
                </div>
            </div>
            <div className="row mb-2 text-right">
                <div className="col-12 text-right">
                    <Button variant="contained" onClick={() => HandleSearch(gameSearch)}>Search</Button>
                </div>
            </div>
        </Container>
    );
}

export default GameSearchForm;