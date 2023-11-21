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
        {title: 'Aula 1', duration: '10min'},
        {title: 'Aula 1', duration: '10min'},
        {title: 'Aula 1', duration: '10min'},
        {title: 'Aula 1', duration: '10min'},
      ]
    },
    {
      id: 5,
      header: 'Modulo 2',
      dropdown: false,
      title: 'Item 2',
      duration: '15 min',
    },
  ];

  @ViewChild('textareaRef') textareaRef!: ElementRef<HTMLTextAreaElement>;

  clickDescription() {
    this.dropdown = !this.dropdown;
  }

  autoSize(event: Event) {
    const target = event.target as HTMLTextAreaElement;
    if (target) {
      target.style.height = 'auto';
      target.style.height = target.scrollHeight + 'px';
    }
  }

  isOpen: boolean = false;

  abrirDialog() {
    this.isOpen = true;
    this.conteudoOriginalTextarea = this.textareaRef.nativeElement.value;
  }

  fecharDialog() {
    this.isOpen = false;
    this.textareaRef.nativeElement.value = this.conteudoOriginalTextarea;
  }
}
