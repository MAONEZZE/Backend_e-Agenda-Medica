import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CirurgiaService {
  url: string = "https://localhost:7124/api/cirurgia";

  constructor(private http: HttpClient) { }

  public selecionarTodos(){
    return this.http.get<any>(this.url).pipe(
      map((x: any) => x.dados),
      catchError(this.processarErros)
    );
  }
  processarErros(processarErros: HttpErrorResponse){
    return throwError(() => new Error(processarErros.error.erro[0]));
  }

 
}
