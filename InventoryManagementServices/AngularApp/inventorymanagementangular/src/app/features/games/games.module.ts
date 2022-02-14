import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GamesComponent } from './games.component';
import { GameDetailComponent } from './detail/game-detail.component';
import { GamesRoutingModule } from './games-routing.module';


@NgModule({
  declarations: [GamesComponent, GameDetailComponent],
  imports: [
    CommonModule,
    GamesRoutingModule
  ],
  exports: [GamesComponent]
})
export class GamesModule { }
