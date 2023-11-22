import { Component, Input, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { PacienteService } from '../services/paciente.service';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs';
import { ListarPacienteVM } from '../models/listar-paciente.view-model';

@Component({
  selector: 'app-listar-paciente',
  templateUrl: './listar-paciente.component.html',
  styleUrls: ['./listar-paciente.component.scss']
})
export class ListarPacienteComponent implements OnInit{
  pacientes: ListarPacienteVM[] = [];

  constructor(private toastrService: ToastrService, private route: ActivatedRoute){}

  ngOnInit(): void {
    this.route.data.pipe(map((dados) => dados['pacientes'])).subscribe({
      next: (pacientes) => this.processarSucesso(pacientes),
      error: (err: Error) => this.processarFalha(err)
    });
  }

  processarSucesso(pacientes: ListarPacienteVM[]){
    this.pacientes = pacientes;
  }

  processarFalha(error: Error){
    this.toastrService.error(error.message, 'Error')
  }

}
