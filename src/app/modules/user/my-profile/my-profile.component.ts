import { Component, ElementRef, ViewChildren, QueryList } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.scss'],
})
export class MyProfileComponent {
  constructor( public auth: AuthService, private formBuilder: FormBuilder) {

    this.dateForm = formBuilder.group({
      nome_completo: ['', Validators.required],
      data_nascimento: ['', Validators.required],
      email: ['', Validators.required],
      senha: ['', Validators.required],
    })
  }

  canEdit: boolean = false;
  imageUrl: string | ArrayBuffer | null = null;
  dateForm: any;

  @ViewChildren('inputContainer') inputContainers!: QueryList<ElementRef>;

  habilitEdit() {
    if (!this.canEdit) {
      this.inputContainers.forEach((container) => {
        const inputElement = container.nativeElement.querySelector('input');
        this.canEdit = true;
        inputElement.setAttribute('disabled', 'false');
      });
    }
  }

  alterDate(){
    alert("Dados alterados")
  }

  logout(){
    this.auth.logout()
  }

  cancelEdit() {
    this.canEdit = !this.canEdit;
    this.imageUrl = null
  }

  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    if (file) {
      this.imageUrl = URL.createObjectURL(file);
    }
  }
}
