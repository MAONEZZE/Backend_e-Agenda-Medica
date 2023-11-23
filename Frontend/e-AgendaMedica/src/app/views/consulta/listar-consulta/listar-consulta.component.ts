import { Component } from '@angular/core';
import { ListarConsultaVM } from '../models/listar-consulta.view-model';
import { Observable, map, tap } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';
import { ConsultaService } from '../services/consulta.service';
import { DialogExcluirComponent } from 'src/app/shared/componentes/dialog-excluir/dialog-excluir.component';

@Component({
  selector: 'app-listar-consulta',
  templateUrl: './listar-consulta.component.html',
  styleUrls: ['./listar-consulta.component.scss']
})
export class ListarConsultaComponent {
  consultas$!: Observable<ListarConsultaVM[]>;

  constructor(private consultaService: ConsultaService, private toastrService: ToastrService, private route: ActivatedRoute, private dialog: MatDialog){}

  ngOnInit(): void {
    this.consultas$ = this.route.data.pipe(map((dados) => dados['consultas']));
  }

  excluir(consulta: ListarConsultaVM){
    let result = this.dialog.open(DialogExcluirComponent, {
      data: { 
        registro: consulta.titulo
      }
    });

    result.afterClosed().subscribe(res => {
      if(res == true){
        this.consultaService.excluir(consulta.id).subscribe({
          next: () => this.processarSucessoExclusao(),
          error: (err) => this.processarFalhaExclusao(err)
          
        })
      }
    });
  }

  processarSucessoExclusao(): void {
    this.toastrService.success(`Medico excluido com sucesso`, 'Exclusão')
    this.consultas$ = this.consultaService.selecionarTodos();
  }

  processarFalhaExclusao(err: Error): void {
    this.toastrService.error(err.message, 'Error')
  }
}
