import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { ApiService } from './Common/api.service';
import { ReactiveFormsModule } from '@angular/forms';
import { SimpleNotificationsModule } from 'angular2-notifications';
import { AuthGuard } from './Common/auth.guard';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { HomeComponent } from './home/home.component';
import { RelatorioComponent } from './relatorio/relatorio.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { UsuarioModalComponent } from './usuario/usuario-modal/usuario-modal.component';
import { UsuarioFilterComponent } from './usuario/usuario-filter/usuario-filter.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    UsuarioComponent,
    UnauthorizedComponent,
    HomeComponent,
    RelatorioComponent,
    UsuarioModalComponent,
    UsuarioFilterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    SimpleNotificationsModule.forRoot(),
    ModalModule.forRoot()
  ],
  providers: [ApiService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
