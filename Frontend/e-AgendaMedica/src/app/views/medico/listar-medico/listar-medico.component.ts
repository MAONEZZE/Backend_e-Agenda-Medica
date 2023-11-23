import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, map } from 'rxjs';
import { ListarMedicoVM } from '../models/listar-medico.view-model';
import { FloatLabelType } from '@angular/material/form-field';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { DialogExcluirComponent } from 'src/app/shared/componentes/dialog-excluir/dialog-excluir.component';
import { MedicoService } from '../services/medico.service';

@Component({
  selector: 'app-listar-medico',
  templateUrl: './listar-medico.component.html',
  styleUrls: ['./listar-medico.component.scss']
})
export class ListarMedicoComponent {
  medicos$!: Observable<ListarMedicoVM[]>;
  crmBusca: string = "";
  floatLabelControl = new FormControl('auto' as FloatLabelType);

  constructor(private medicoService: MedicoService, private toastrService: ToastrService, private route: ActivatedRoute, private dialog: MatDialog){}

  ngOnInit(): void {
    this.medicos$ = this.route.data.pipe(map((dados) => dados['medicos']));
  }
  
  getFloatLabelValue(): FloatLabelType {
    return this.floatLabelControl.value || 'auto';
  }

  excluir(medico: ListarMedicoVM){
    let result = this.dialog.open(DialogExcluirComponent, {
      data: { 
        registro: medico.nome
      }
    });

    result.afterClosed().subscribe(res => {
      if(res == true){
        this.medicoService.excluir(medico.id).subscribe({
          next: () => this.processarSucessoExclusao(),
          error: (err) => this.processarFalhaExclusao(err)
          
        })
      }
    });
  }

  processarSucessoExclusao(): void {
    this.toastrService.success(`Medico excluido com sucesso`, 'Exclusão')
    this.medicos$ = this.medicoService.selecionarTodos();
  }

  processarFalhaExclusao(err: Error): void {
    this.toastrService.error(err.message, 'Error')
  }

  buscarPorCrm(){
    
  }
}
