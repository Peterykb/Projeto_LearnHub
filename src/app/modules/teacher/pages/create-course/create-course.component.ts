import { Component } from '@angular/core';
import { CourseService } from 'src/app/services/course.service';


@Component({
  selector: 'app-create-course',
  templateUrl: './create-course.component.html',
  styleUrls: ['./create-course.component.scss'],
})
export class CreateCourseComponent {

  isActive: boolean = false;

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

  constructor(private cursoService: CourseService) {}

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
  criarCurso() {
    this.cursoService.criarCurso(this.curso).subscribe(
      (resposta) => {
        console.log('Curso criado com sucesso!', resposta);
      },
      (erro) => {
        console.error('Erro ao criar curso', erro);
      }
      );
  }
}
