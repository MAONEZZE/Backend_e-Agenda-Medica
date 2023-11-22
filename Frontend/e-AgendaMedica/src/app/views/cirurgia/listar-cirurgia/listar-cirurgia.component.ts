import { Component } from '@angular/core';
import { CirurgiaService } from '../services/cirurgia.service';
import { Observable, map } from 'rxjs';
import { ListarCirurgiaVM } from '../models/listar-cirurgia.view-model';
import { OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-listar-cirurgia',
  templateUrl: './listar-cirurgia.component.html',
  styleUrls: ['./listar-cirurgia.component.scss']
})
export class ListarCirurgiaComponent implements OnInit{
  cirurgias: ListarCirurgiaVM[] = [];

  constructor(private toastrService: ToastrService, private route: ActivatedRoute){}

  ngOnInit(): void {
    this.route.data.pipe(map((dados) => dados['cirurgias'])).subscribe({
      next: (pacientes) => this.processarSucesso(pacientes),
      error: (err: Error) => this.processarFalha(err)
    });
  }

  processarSucesso(cirurgias: ListarCirurgiaVM[]){
    this.cirurgias = cirurgias;
  }

  processarFalha(error: Error){
    this.toastrService.error(error.message, 'Error')
  }
}
