import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, map, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MedicoService {
  private url: string = "https://localhost:7124/api/medico";

  constructor(private http: HttpClient) { }

  private processarErroHttp(error: HttpErrorResponse){
    let msgErro = '';

    if(error.status == 401){
      msgErro = 'O usuário não está autorizado. Faça o o login e tente novamente.'
    }
    else if(error.status == 0){
      msgErro = 'Ocorreu um erro ao processar a requisição.'
    }
    else{
      msgErro = error.error?.erros[0]
    }
    return throwError(() => new Error(msgErro));
  }

  public inserir(medico: any): Observable<any>{
    return this.http.post<any>(`${this.url}`, medico)
      .pipe(
        map((res) => res.dados),
        catchError((error: HttpErrorResponse) => this.processarErroHttp(error))
      );
  }

  public editar(id: string, medico: any): Observable<any>{
    return this.http.put<any>(`${this.url}/${id}`, medico)
      .pipe(
        map((res) => res.dados),
        catchError((error: HttpErrorResponse) => this.processarErroHttp(error))
      );
  }

  public editarPorCrm(crm: string, medico: any): Observable<any>{
    return this.http.put<any>(`${this.url}/${crm}`, medico)
      .pipe(
        map((res) => res.dados),
        catchError((error: HttpErrorResponse) => this.processarErroHttp(error))
      );
  }

  public excluir(id: string): Observable<any>{
    return this.http.delete(`${this.url}/${id}`)
      .pipe(
        catchError((error: HttpErrorResponse) => this.processarErroHttp(error))
      );
  }

  public selecionarTodos(){
    return this.http.get<any>(this.url).pipe(
      map((x: any) => x.dados),
      catchError((error: HttpErrorResponse) => this.processarErroHttp(error))
    );
  }

  public selecionarMedicoPorId(id: string){
    return this.http
    .get<any>(`${this.url}/${id}`)
    .pipe(
      map((res) => res.dados),
      catchError((error: HttpErrorResponse) => this.processarErroHttp(error))
    );
  }

  public selecionarMedicoCompletoPorId(id: string){
    return this.http
    .get<any>(`${this.url}/visualizacao-completa/${id}`)
    .pipe(
      map((res) => res.dados),
      catchError((error: HttpErrorResponse) => this.processarErroHttp(error))
    );
  }

  public selecionarMedicosMaisTrabalharam(){
    return this.http
    .get<any>(`${this.url}/medicos-mais-trabalhadores`)
    .pipe(
      map((res) => res.dados),
      catchError((error: HttpErrorResponse) => this.processarErroHttp(error))
    );
  }

  public selecionarMedicoPorCrm(crm: string){
    return this.http
    .get<any>(`${this.url}/${crm}`)
    .pipe(
      map((res) => res.dados),
      catchError((error: HttpErrorResponse) => this.processarErroHttp(error))
    );
  }
}
