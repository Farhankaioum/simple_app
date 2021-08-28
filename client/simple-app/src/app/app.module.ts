import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { JwtModule } from '@auth0/angular-jwt';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { RegisterComponent } from './register/register.component';
import {AuthService} from './_services/auth.service';
import {UserService} from './_services/user.service';
import {BookService} from './_services/book.service';
import {AlertifyService} from './_services/alertify.service';
import { BookListComponent } from './books/book-list/book-list.component';
import { BookAddComponent } from './books/book-add/book-add.component';
import { BookEditComponent } from './books/book-edit/book-edit.component';
import { AuthGuard } from './_guards/auth.guard';
import { AdminGuard } from './_guards/admin.guard';
import { BookListResolver } from './_resolver/book-list.resolver';
import { ArchiveBookListResolver } from './_resolver/archive-book-list.resolver';
import { BookEditResolver } from './_resolver/book-edit.resolver';
import { UserListResolver } from './_resolver/user-list.resolver';
import { UserEditResolver } from './_resolver/user-edit.resolver';
import { ArchiveBookListComponent } from './archive-book-list/archive-book-list.component';
import { HomeComponent } from './home/home.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { UserAddComponent } from './users/user-add/user-add.component';
import { UserEditComponent } from './users/user-edit/user-edit.component';

export function tokenGetter(){
  return localStorage.getItem('auth-token');
}

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    RegisterComponent,
    BookListComponent,
    BookAddComponent,
    BookEditComponent,
    ArchiveBookListComponent,
    HomeComponent,
    UserListComponent,
    UserAddComponent,
    UserEditComponent
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    BsDropdownModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:44388'],
        disallowedRoutes: ['localhost:44388/api/auth']
      }
    })
  ],
  providers: [
    AuthService,
    UserService,
    AlertifyService,
    BookService,
    AuthGuard,
    AdminGuard,
    BookListResolver,
    UserListResolver,
    BookEditResolver,
    UserEditResolver,
    ArchiveBookListResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
