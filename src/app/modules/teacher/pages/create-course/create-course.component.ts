import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Course } from 'src/app/models/Course';
import { CourseService } from 'src/app/services/course.service';


@Component({
  selector: 'app-create-course',
  templateUrl: './create-course.component.html',
  styleUrls: ['./create-course.component.scss'],
})
export class CreateCourseComponent {

  isActive: boolean = false;

  courseForm!: FormGroup;

  toggleButton() {
    this.isActive = !this.isActive;
  }


  curso = {
    nome: '',
    modulos: [
      {
        nome: '',
        aulas: [{ nome: '', titulo: '', descricao: '', linkVideo: ''}],
      },
    ],
  };

  constructor( private courseService: CourseService, private formBuilder: FormBuilder) {

    this.courseForm = formBuilder.group({
      id_curso: [''],
      name: [''],
      data_criacao:[''],
      idiomas: [''],
      disponivel: [''],
      preco: [''],
      instrutor_id: ['']
    })
  }


  /* createCourse(){

    const curso: Course = {
      name: this.courseForm.get('name')!.value,

    }

    this.courseService.createCourse(curso).subscribe((response)=>{
      console.log("Curso criada com sucesso");
    }, (error) =>{
      console.error("Erro ao criar curso", error);
    })
  } */


  adicionarModulo() {
    this.curso.modulos.push({
      nome: '',
      aulas: [{ nome: '', titulo: '', descricao: '', linkVideo: '' }],
    });
  }

  removerModulo(index: number) {
    this.curso.modulos.splice(index, 1);
  }

  adicionarAula() {
    const ultimoModulo = this.curso.modulos[this.curso.modulos.length - 1];
    if (ultimoModulo) {
      ultimoModulo.aulas.push({ nome: '', titulo: '', descricao: '', linkVideo: '' });
    }
  }

  adicionarAulaEmModulo(moduloIndex: number) {
  const modulo = this.curso.modulos[moduloIndex];
  if (modulo) {
    modulo.aulas.push({ nome: '', titulo: '', descricao: '', linkVideo: '' });
  }
}

  removerAula(moduloIndex: number, aulaIndex: number) {
    const modulo = this.curso.modulos[moduloIndex];
    if (modulo) {
      modulo.aulas.splice(aulaIndex, 1);
    }
  }
}
