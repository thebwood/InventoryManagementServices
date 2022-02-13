import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes } from '@angular/router';
import { GamesComponent } from './games.component';
import { GameDetailComponent } from './detail/game-detail.component';

const routes: Routes = [
  {path: '', component: GamesComponent},
  {path: ':id', component: GameDetailComponent}
]


@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class GamesRoutingModule { }
