import { Component, Input, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { PacienteService } from '../services/paciente.service';
import { ActivatedRoute } from '@angular/router';
import { Observable, map } from 'rxjs';
import { ListarPacienteVM } from '../models/listar-paciente.view-model';
import { DialogExcluirComponent } from 'src/app/shared/componentes/dialog-excluir/dialog-excluir.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-listar-paciente',
  templateUrl: './listar-paciente.component.html',
  styleUrls: ['./listar-paciente.component.scss']
})
export class ListarPacienteComponent implements OnInit{
  pacientes$!: Observable<ListarPacienteVM[]>;

  constructor(private pacienteService: PacienteService, private toastrService: ToastrService, private route: ActivatedRoute, private dialog: MatDialog){}

  ngOnInit(): void {
    this.pacientes$ = this.route.data.pipe(map((dados) => dados['pacientes']));
  }

  excluir(paciente: ListarPacienteVM){
    let result = this.dialog.open(DialogExcluirComponent, {
      data: { 
        registro: paciente.nome
      }
    });

    result.afterClosed().subscribe(res => {
      if(res == true){
        console.log('entrou excluir no listarts')
        this.pacienteService.excluir(paciente.id).subscribe({
          next: () => this.processarSucessoExclusao(),
          error: (err) => this.processarFalhaExclusao(err)
          
        })
      }
    });
  }

  processarSucessoExclusao(): void {
    this.toastrService.success(`Paciente excluido com sucesso`, 'Exclusão')
    this.pacientes$ = this.pacienteService.selecionarTodos();
  }

  processarFalhaExclusao(err: Error): void {
    this.toastrService.error(err.message, 'Error')
  }

}
