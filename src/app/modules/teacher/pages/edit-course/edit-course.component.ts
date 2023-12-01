import { Component, ElementRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-edit-course',
  templateUrl: './edit-course.component.html',
  styleUrls: ['./edit-course.component.scss'],
})
export class EditCourseComponent {
  dropdown = false;
  conteudoOriginalTextarea: string = 'Como fazer um CRUD em Angular!';

  accordionItems = [
    {
      id: 4,
      header: 'Módulo 1',
      dropdown: false,
      aulas: [
        { title: 'Aula 1', duration: '10min' },
        { title: 'Aula 2', duration: '10min' },
        { title: 'Aula 3', duration: '10min' },
        { title: 'Aula 4', duration: '10min' },
      ]
    },
    {
      id: 5,
      header: 'Modulo 2',
      dropdown: false,
      aulas: [
        { title: 'Aula 1', duration: '10min' },
        { title: 'Aula 2', duration: '10min' },
        { title: 'Aula 3', duration: '10min' },
        { title: 'Aula 4', duration: '10min' },
      ]
    },
  ];

  @ViewChild('textareaRef') textareaRef!: ElementRef<HTMLTextAreaElement>;

  clickDescription(item: any) {
    item.dropdown = !item.dropdown;
  }

  autoSize(event: Event) {
    const target = event.target as HTMLTextAreaElement;
    if (target) {
      target.style.height = 'auto';
      target.style.height = target.scrollHeight + 'px';
    }
  }

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
