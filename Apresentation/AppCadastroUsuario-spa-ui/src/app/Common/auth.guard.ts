import { Injectable } from "@angular/core";
import { ActivatedRoute, ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";

@Injectable()
export class AuthGuard implements CanActivate {
    user: any = {};

    constructor(private route: Router) { }
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot):  | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        let userInfo = window.localStorage.getItem('USER_INFO')?.toString();

        if (userInfo == null || userInfo == undefined) {
            this.route.navigateByUrl('/login')
        }
        else {
            var rotaAtual = route.url[0].path;
            this.user = JSON.parse(userInfo);

            if (this.user.permissoes == 'AcessoTotal'){
                return true;
            }
            else {
                if (!this.user.rotas) return false;

                let temAcessoRota: boolean = false;

                for (let i = 0; i < this.user.rotas.length; i++) {

                    if (this.user.rotas[i] == rotaAtual)
                        temAcessoRota = true;
                }

                if (temAcessoRota) 
                    return true;
                else {
                    window.localStorage.removeItem('USER_INFO')
                    this.route.navigateByUrl('/unauthorized')
                }
            }
        }

        return false;
    }
}
