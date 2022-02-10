import { Button, Paper, styled, Table, TableBody, TableContainer, TableHead, TableRow } from "@mui/material";
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import React, { Fragment } from "react";
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import AddIcon from '@mui/icons-material/Add';
import { useNavigate } from "react-router-dom";
import { GameGenres } from "../../../app/models/games/gameGenres";

interface ChildProps {
  GameGenres: GameGenres[]
}

const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  '&:nth-of-type(odd)': {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  '&:last-child td, &:last-child th': {
    border: 0,
  },
}));

const GameGenresGrid: React.FC<ChildProps> = (props) => {
  const navigate = useNavigate();
  const { GameGenres } = props;


  const handleAddClick = () => {
    navigate("/games/add");
  }
  if (!GameGenres || GameGenres.length == 0)
    return (
      <Fragment>
        <div>No genres were found!</div>
      </Fragment>
    );

  return (
    <Fragment>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 700 }} aria-label="customized table">
          <TableHead>
            <TableRow>
              <StyledTableCell align="center">Description</StyledTableCell>
              <StyledTableCell align="center">Delete</StyledTableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {GameGenres.map((row) => (
              <StyledTableRow key={row.id}>
                <StyledTableCell align="right">{row.genreDescription}</StyledTableCell>
                <StyledTableCell align="center">
                  <Button variant="outlined" color="error" startIcon={<DeleteIcon />} onClick={() => { }}>
                    Delete
                  </Button>
                </StyledTableCell>
              </StyledTableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>

    </Fragment>

  );
};


export default GameGenresGrid;