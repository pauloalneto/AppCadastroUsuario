import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsuarioFilterComponent } from './usuario-filter.component';

describe('UsuarioFilterComponent', () => {
  let component: UsuarioFilterComponent;
  let fixture: ComponentFixture<UsuarioFilterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UsuarioFilterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UsuarioFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
