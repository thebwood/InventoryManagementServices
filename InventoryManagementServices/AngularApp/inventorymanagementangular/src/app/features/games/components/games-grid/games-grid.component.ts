import { Component, Input, OnInit } from '@angular/core';
import { GamesGridModel } from '../../models/gamesGrid/games-grid-model';
import {MatTableDataSource} from '@angular/material/table';

@Component({
  selector: 'app-games-grid',
  templateUrl: './games-grid.component.html',
  styleUrls: ['./games-grid.component.scss']
})
export class GamesGridComponent implements OnInit {
  @Input() games: GamesGridModel[] = [];

  displayedColumns: string[] = ['name', 'description', 'gameRating'];
  dataSource = new MatTableDataSource<GamesGridModel>();

  constructor() { }

  ngOnInit(): void {
    this.dataSource = new MatTableDataSource<GamesGridModel>(this.games);
  }

}
