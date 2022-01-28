import { Button, Paper, styled, Table, TableBody, TableContainer, TableHead, TableRow } from "@mui/material";
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import React, { Fragment } from "react";
import { Game } from "../../../app/models/game";
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import AddIcon from '@mui/icons-material/Add';
import { useNavigate } from "react-router-dom";

interface ChildProps {
  Games: Game[]
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

const GamesGrid: React.FC<ChildProps> = (props) => {
  const navigate = useNavigate();
  const { Games } = props;
  const handleEditClick = (rowId: string | undefined) => {
    if (rowId)
      navigate("/games/" + rowId);
  }
  const handleAddClick = () => {
    navigate("/games/add");
  }
  if (!Games || Games.length == 0)
    return (<div>No games were found!</div>);

  return (
    <Fragment>
      <Button variant="outlined" startIcon={<AddIcon />} onClick={() => { handleAddClick(); }} color="success">
        Add
      </Button>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 700 }} aria-label="customized table">
          <TableHead>
            <TableRow>
              <StyledTableCell align="center">Edit</StyledTableCell>
              <StyledTableCell align="center">Title</StyledTableCell>
              <StyledTableCell align="center">Description</StyledTableCell>
              <StyledTableCell align="center">Delete</StyledTableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {Games.map((row) => (
              <StyledTableRow key={row.id}>
                <StyledTableCell align="center">
                  <Button variant="outlined" startIcon={<EditIcon />} onClick={() => { handleEditClick(row.id); }}>
                    Edit
                  </Button>
                </StyledTableCell>
                <StyledTableCell align="left">{row.title}</StyledTableCell>
                <StyledTableCell align="right">{row.description}</StyledTableCell>
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


export default GamesGrid;