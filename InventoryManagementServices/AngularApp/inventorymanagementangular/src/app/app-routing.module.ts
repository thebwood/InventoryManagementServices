import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GamesComponent } from './features/games/games.component';
import { HomeComponent } from './features/home/home/home.component';
import { MoviesComponent } from './features/movies/movies.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent} ,
  { path: 'games', component: GamesComponent} ,
  { path: 'movies', component: MoviesComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
