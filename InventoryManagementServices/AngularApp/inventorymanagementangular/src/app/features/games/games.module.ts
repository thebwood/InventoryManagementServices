import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GamesComponent } from './games.component';
import { GameDetailComponent } from './detail/game-detail.component';
import { BrowserModule } from '@angular/platform-browser';
import { GamesRoutingModule } from './games-routing.module';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [GamesComponent, GameDetailComponent],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    GamesRoutingModule
  ]
})
export class GamesModule { }
