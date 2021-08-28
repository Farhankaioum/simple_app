import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { ArchiveBookListComponent } from './archive-book-list/archive-book-list.component';
import { BookAddComponent } from './books/book-add/book-add.component';
import { BookEditComponent } from './books/book-edit/book-edit.component';
import { BookListComponent } from './books/book-list/book-list.component';
import { HomeComponent } from './home/home.component';
import { UserAddComponent } from './users/user-add/user-add.component';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { AdminGuard } from './_guards/admin.guard';

import { AuthGuard} from './_guards/auth.guard';
import { ArchiveBookListResolver } from './_resolver/archive-book-list.resolver';
import { BookEditResolver } from './_resolver/book-edit.resolver';
import { BookListResolver } from './_resolver/book-list.resolver';
import { UserEditResolver } from './_resolver/user-edit.resolver';
import { UserListResolver } from './_resolver/user-list.resolver';

const routes: Routes = [
  { path: '', component: HomeComponent},
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
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AdminGuard],
    children: [
      { path: 'user-list', component: UserListComponent, resolve: {users: UserListResolver}},
      { path: 'add-user', component: UserAddComponent},
      { path: 'edit-user/:id', component: UserEditComponent, resolve: {user: UserEditResolver}},
    ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
