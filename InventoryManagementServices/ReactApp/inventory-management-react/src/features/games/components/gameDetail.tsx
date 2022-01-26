import { TextField } from "@mui/material";
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import React, { Fragment } from "react";
import { Game } from "../../../app/models/game";


interface ChildProps {
  Game: Game
}

 
const GameDetail: React.FC<ChildProps> = (props) => {
    const {Game} = props;

    if(!Game)
      return <div>No games were found!</div>

    return(
        <Fragment>
            <div className="col-12">
                <div className="col-md-6">
                    <TextField 
                        id="Title"
                        label="Title"
                        value={Game.title || ''}
                        inputProps={{
                            maxLength: 50
                        }}
                        ></TextField>

                </div>
                <div className="col-md-6">
                    <TextField 
                            id="Description"
                            label="Description"
                            value={Game.description || ''}
                            inputProps={{
                                maxLength: 50
                            }}
                            ></TextField>
                </div>

            </div>
        </Fragment>

  

    );
};


export default GameDetail;