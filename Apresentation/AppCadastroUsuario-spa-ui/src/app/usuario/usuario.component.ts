import { Component, OnInit } from '@angular/core';
import { ApiService } from '../Common/api.service';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.scss']
})
export class UsuarioComponent implements OnInit {

  listaUsuarios: any[] = [];
  usuario: any = {};
  abrirUsuarioModal: boolean = false;
  abrirFiltroModal: boolean = false;

  constructor(private api: ApiService) { }


  ngOnInit(): void {
    this.obterListaUsuarios(null)
  }

  public obterListaUsuarios(modelFilter?: any) {
    console.log(modelFilter)
    this.api.GetWithFilters('Usuario', modelFilter).subscribe(
      {
        next: (result: any) => {
          this.listaUsuarios = result
          this.abrirFiltroModal = false;
        },
        error: (error) => {
          this.api.notificacaoErro('Erro', 'Erro ao tentar obter os usuários')
        }
      })
  }

  public obterDetalheUsuario(id: string) {
    this.api.GetById('Usuario', id).subscribe(
      {
        next: (result: any) => {
          this.usuario = result
          this.abrirUsuarioModal = true;
        },
        error: (error) => {
          this.api.notificacaoErro('Erro', 'Erro ao tentar obter o usuário')
        }
      })
  }

  public abrirModalFiltro(){
    this.abrirFiltroModal = true;
  }

  public abrirModalNovoUsuario() {
    this.usuario = {};
    this.abrirUsuarioModal = true;
  }

  public salvarUsuario(model: any) {
    if (!model.id)
      this.salvarNovoUsuario(model);
    else
      this.atualizarUsuario(model)
  }

  public salvarNovoUsuario(model: any) {
    this.api.Post('usuario', model).subscribe({
      next: (result) => {
        this.api.notificacaoSucesso('Sucesso', 'Usuário criado')
        this.obterListaUsuarios(null);
        this.abrirUsuarioModal = false;
      },
      error: (error) => {
        this.api.notificacaoErro('Erro', 'Não foi possível criar o usuário')
      }
    })
  }

  public atualizarUsuario(model: any) {
    this.api.Put('usuario', model).subscribe({
      next: (result) => {
        this.api.notificacaoSucesso('Sucesso', 'Usuário atualizado')
        this.obterListaUsuarios(null);
        this.abrirUsuarioModal = false;
      },
      error: (error) => {
        this.api.notificacaoErro('Erro', 'Não foi possível alterar o usuário')
      }
    })
  }

  public excluirUsuario(id: any) {
    this.api.Delete('usuario', id).subscribe({
      next: (result) => {
        this.api.notificacaoSucesso('Sucesso', 'Usuário excluído')
        this.obterListaUsuarios(null);
      },
      error: (error) => {
        this.api.notificacaoErro('Erro', 'Não foi possível excluir o usuário')
      }
    })
  }


}
