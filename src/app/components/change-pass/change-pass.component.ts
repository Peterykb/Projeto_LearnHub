import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-change-pass',
  templateUrl: './change-pass.component.html',
  styleUrls: ['./change-pass.component.scss'],
})
export class ChangePassComponent {
  formPass: any;
  oldPass = false;
  newPass = false;
  confirmNewPass = false;

  formSubmitted = false;

  constructor(private formBuilder: FormBuilder) {
    this.formPass = this.formBuilder.group({
      senha: [
        '',
        Validators.compose([Validators.required, Validators.minLength(8)]),
      ],
      nova_senha: [
        '',
        Validators.compose([Validators.required, Validators.minLength(8)]),
      ],
      confirmar_senha: [
        '',
        Validators.compose([Validators.required, Validators.minLength(8)]),
      ],
    });
  }

  submitForm() {
    this.formSubmitted = true;
    if (this.formPass.valid) {
      console.log('tudo certo');
    } else {
      return;
    }
  }

  showOldPass() {
    this.oldPass = !this.oldPass;
  }

  showNewPass() {
    this.newPass = !this.newPass;
  }

  showConfirmNewPass() {
    this.confirmNewPass = !this.confirmNewPass;
  }

  get senhaAtual() {
    return this.formPass.get('senha')!;
  }

  get novaSenha() {
    return this.formPass.get('nova_senha')!;
  }

  get confirmNovaSenha() {
    return this.formPass.get('confirmar_senha')!;
  }
}
