import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-usuario-modal',
  templateUrl: './usuario-modal.component.html',
  styleUrls: ['./usuario-modal.component.scss']
})
export class UsuarioModalComponent implements OnInit, OnChanges {

  @Input() usuario: any = {};
  
  @Input() showModal?: boolean;
  @Output() showModalChange = new EventEmitter<boolean>();
  
  @Output() onSalvar = new EventEmitter<any>();

  form: FormGroup = new FormGroup({
    id: new FormControl(),
    nome: new FormControl(),
    email: new FormControl(),
    login: new FormControl(),
    senha: new FormControl(),
    dataCadastro: new FormControl(),
  })
  
  @ViewChild('editarUsuarioModal', { static: false }) editarUsuarioModal?: ModalDirective;

  constructor() { }

  ngOnInit(): void {
  }

  ngOnChanges(changes: SimpleChanges): void{
    if(this.showModal)
      this.editarUsuarioModal?.show();
    else
      this.editarUsuarioModal?.hide();
  }

  fecharModal(){
    this.showModal = false;
    this.showModalChange.emit(this.showModal);
    this.editarUsuarioModal?.hide();
  }

  salvar(){
    this.onSalvar.emit(this.usuario)
  }

}
