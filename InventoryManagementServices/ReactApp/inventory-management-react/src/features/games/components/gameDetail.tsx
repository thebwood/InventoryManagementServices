import { Paper, styled, Table, TableBody, TableContainer, TableHead, TableRow } from "@mui/material";
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
            <div>

            </div>
        </Fragment>

  

    );
};


export default GameDetail;