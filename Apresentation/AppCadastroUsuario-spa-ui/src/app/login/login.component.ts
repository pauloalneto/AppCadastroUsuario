import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../Common/api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  form: FormGroup = new FormGroup({
    login: new FormControl(),
    senha: new FormControl(),
  })

  constructor(private api: ApiService, private route: Router) { }

  ngOnInit(): void {
  }

  onEfetuarLogin(model: any) {
    this.api.Post('auth', model).subscribe({
      next: (result) => {
        window.localStorage.setItem('AUTH_TOKEN', result.token)
        window.localStorage.setItem('USER_INFO', JSON.stringify(result))

        this.route.navigateByUrl('/home')
      },
      error: (error) => {
        this.api.notificacaoErro("Erro", "Login ou Senha inválido")
      }
    })
  }

  get login() { return this.form.get('login'); }
  get senha() { return this.form.get('senha'); }


}
