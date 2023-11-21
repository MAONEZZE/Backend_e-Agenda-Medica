import { Component } from '@angular/core';
import { CirurgiaService } from '../services/cirurgia.service';
import { Observable } from 'rxjs';
import { ListarCirurgiaVM } from '../models/listar-cirurgia.view-model';
import { OnInit } from '@angular/core';

@Component({
  selector: 'app-listar-cirurgia',
  templateUrl: './listar-cirurgia.component.html',
  styleUrls: ['./listar-cirurgia.component.scss']
})
export class ListarCirurgiaComponent implements OnInit{
  cirurgias$!: Observable<ListarCirurgiaVM[]>;

  constructor(private cirurgiaService: CirurgiaService) {

  }

  ngOnInit(): void {
    this.cirurgias$ = this.cirurgiaService.selecionarTodos();
  }


}
