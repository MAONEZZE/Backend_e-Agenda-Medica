import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs';
import { ListarMedicoVM } from '../models/listar-medico.view-model';
import { FloatLabelType } from '@angular/material/form-field';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-listar-medico',
  templateUrl: './listar-medico.component.html',
  styleUrls: ['./listar-medico.component.scss']
})
export class ListarMedicoComponent {
  medicos: ListarMedicoVM[] = [];
  crmBusca: string = "";
  floatLabelControl = new FormControl('auto' as FloatLabelType);

  constructor(private toastrService: ToastrService, private route: ActivatedRoute){}

  ngOnInit(): void {
    this.route.data.pipe(map((dados) => dados['medicos'])).subscribe({
      next: (medicos) => this.processarSucesso(medicos),
      error: (err: Error) => this.processarFalha(err)
    });
  }
  
  getFloatLabelValue(): FloatLabelType {
    return this.floatLabelControl.value || 'auto';
  }

  buscarPorCrm(){
    
  }

  processarSucesso(pacientes: ListarMedicoVM[]){
    this.medicos = pacientes;
  }

  processarFalha(error: Error){
    this.toastrService.error(error.message, 'Error')
  }
}
