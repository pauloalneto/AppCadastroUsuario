import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsuarioComponent } from './usuario/usuario.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './Common/auth.guard';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { HomeComponent } from './home/home.component';
import { RelatorioComponent } from './relatorio/relatorio.component';

const routes: Routes = [
  {path: "home", component: HomeComponent},
  {path: "login", component: LoginComponent},
  {path: "unauthorized", component: UnauthorizedComponent},
  {path: "usuario", component: UsuarioComponent, canActivate: [AuthGuard]},
  {path: "relatorio", component: RelatorioComponent, canActivate: [AuthGuard]},
  {path: "", redirectTo: '/home', pathMatch: "full"},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
