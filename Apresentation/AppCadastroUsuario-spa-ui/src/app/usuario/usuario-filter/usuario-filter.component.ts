import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-usuario-filter',
  templateUrl: './usuario-filter.component.html',
  styleUrls: ['./usuario-filter.component.scss']
})
export class UsuarioFilterComponent implements OnInit, OnChanges {

  @Input() showModal?: boolean;
  @Output() showModalChange = new EventEmitter<boolean>();
  @Output() onFiltrar = new EventEmitter<any>();

  form: FormGroup = new FormGroup({
    nome: new FormControl(),
    email: new FormControl(),
    login: new FormControl(),
  })

  @ViewChild('filtroModal', { static: false }) filtroModal?: ModalDirective;

  constructor() { }

  ngOnInit(): void {
  }

  ngOnChanges(changes: SimpleChanges): void{
    if(this.showModal)
      this.filtroModal?.show();
    else
      this.filtroModal?.hide();
  }

  fecharModal(){
    this.showModal = false;
    this.showModalChange.emit(this.showModal);
    this.filtroModal?.hide();
  }

  filtrar(){
    this.onFiltrar.emit(this.form.value)
  }

}
