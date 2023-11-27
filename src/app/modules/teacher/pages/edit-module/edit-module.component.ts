import { Component } from '@angular/core';

@Component({
  selector: 'app-edit-module',
  templateUrl: './edit-module.component.html',
  styleUrls: ['./edit-module.component.scss'],
})
export class EditModuleComponent {
  isLessonOpen: boolean = false;
  selectedLesson: any = {}; // Objeto para armazenar a aula selecionada para edição

  abrirLessonDialog() {
    // Lógica para abrir o modal de edição da aula
    this.isLessonOpen = true;
  }

  fecharLessonDialog() {
    // Lógica para fechar o modal de edição da aula
    this.isLessonOpen = false;
  }
}
