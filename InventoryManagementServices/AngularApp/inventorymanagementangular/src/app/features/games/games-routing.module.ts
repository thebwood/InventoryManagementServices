import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GamesComponent } from './games.component';
import { GameDetailComponent } from './detail/game-detail.component';

const routes: Routes = [
  {path: ':id', component: GameDetailComponent},
  {path: '', component: GamesComponent}
]


@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class GamesRoutingModule { }
