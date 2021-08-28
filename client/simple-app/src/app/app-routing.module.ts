import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { ArchiveBookListComponent } from './archive-book-list/archive-book-list.component';
import { BookAddComponent } from './books/book-add/book-add.component';
import { BookEditComponent } from './books/book-edit/book-edit.component';
import { BookListComponent } from './books/book-list/book-list.component';

import { AuthGuard} from './_guards/auth.guard';
import { ArchiveBookListResolver } from './_resolver/archive-boo-list.resolver';
import { BookEditResolver } from './_resolver/book-edit.resolver';
import { BookListResolver } from './_resolver/book-list.resolver';

const routes: Routes = [
  { path: '', component: AppComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'book-list', component: BookListComponent, resolve: {books: BookListResolver}},
      { path: 'archive-book-list', component: ArchiveBookListComponent, resolve: {books: ArchiveBookListResolver}},
      { path: 'add-book', component: BookAddComponent},
      { path: 'edit-book/:id', component: BookEditComponent, resolve: {book: BookEditResolver}},
    ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
