import { Component } from '@angular/core';
import { ListarConsultaVM } from '../models/listar-consulta.view-model';
import { map, tap } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-listar-consulta',
  templateUrl: './listar-consulta.component.html',
  styleUrls: ['./listar-consulta.component.scss']
})
export class ListarConsultaComponent {
  consultas: ListarConsultaVM[] = [];

  constructor(private toastrService: ToastrService, private route: ActivatedRoute){}

  ngOnInit(): void {
    this.route.data.pipe(map((dados) => dados['consultas'])).subscribe({
      next: (consultas) => this.processarSucesso(consultas),
      error: (err: Error) => this.processarFalha(err)
    });
  }

  processarSucesso(consultas: ListarConsultaVM[]){
    this.consultas = consultas;
  }

  processarFalha(error: Error){
    this.toastrService.error(error.message, 'Error')
  }
}
