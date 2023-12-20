import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class RegisterService {
  private apiURL = environment.baseApiUrl;

  constructor(private registerBuilder: FormBuilder, private http: HttpClient) {}

  createRegisterForm(): FormGroup {
    return this.registerBuilder.group({
      nome_completo: ['', Validators.required],
      data_nascimento: ['', Validators.required],
      username: ['', [Validators.required, Validators.pattern(/^[a-zA-Z0-9]+$/)]],
      cpf: ['', Validators.required],
      email: [
        '',
        Validators.compose([
          Validators.required,
          Validators.pattern(/^[a-z0-9.]+@[a-z0-9]+\.[a-z]+(\.[a-z]+)?$/i),
        ]),
      ],
      senha: [
        '',
        Validators.compose([
          Validators.required,
          Validators.minLength(8),
          Validators.pattern(
            /^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]).{8,}$/
          ),
        ]),
      ],
      confirmar_senha: [
        '',
        Validators.compose([
          Validators.required,
          Validators.minLength(8),
          Validators.pattern(
            /^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]).{8,}$/
          ),
        ]),
      ],
    });
  }

  formatCPF(cpfInput: string): string {
    const cpf = cpfInput.replace(/\D/g, ''); // Remove caracteres não numéricos
    const cpfFormatted = cpf
      .replace(/(\d{3})(\d)/, '$1.$2')
      .replace(/(\d{3})(\d)/, '$1.$2')
      .replace(/(\d{3})(\d{1,2})/, '$1-$2')
      .replace(/(-\d{2})\d+?$/, '$1');

    return cpfFormatted;
  }

  cadastrarAluno(alunoData: any): Observable<any> {
    return this.http.post<any>(`${this.apiURL}/Autentication/aluno`, alunoData);
  }

  cadastrarInstrutor(instrutorData: any): Observable<any> {
    return this.http.post<any>(`${this.apiURL}/Autentication/instrutor`, instrutorData);
  }
}
