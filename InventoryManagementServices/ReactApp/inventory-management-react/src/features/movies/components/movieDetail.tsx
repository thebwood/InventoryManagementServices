import React, { Fragment } from "react";
import { Movie } from "../../../app/models/movie";


interface ChildProps {
  Movie: Movie
}

 
const MovieDetail: React.FC<ChildProps> = (props) => {
    const {Movie} = props;

    if(!Movie)
      return <div>No movies were found!</div>

    return(
        <Fragment>
            <div>

            </div>
        </Fragment>

  

    );
};


export default MovieDetail;