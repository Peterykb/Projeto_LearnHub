import { Instrutor } from "./Instrutor";
import { Student } from "./Student-cad";

export interface cadastro{
    email: string;
    senha: string;
    aluno: Student;
}
export interface cadastroInstrutor {
    email: string;
    senha: string;
    instrutor: Instrutor;
}