import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ListarMedicoVM } from '../../medico/models/listar-medico.view-model';
import { ListarPacienteVM } from '../../paciente/models/listar-paciente.view-model';
import { FormConsultaVM } from '../models/form-consulta.view-model';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MedicoService } from '../../medico/services/medico.service';
import { PacienteService } from '../../paciente/services/paciente.service';
import { ConsultaService } from '../services/consulta.service';

@Component({
  selector: 'app-inserir-consulta',
  templateUrl: './inserir-consulta.component.html',
  styleUrls: ['./inserir-consulta.component.scss']
})
export class InserirConsultaComponent {
  form!: FormGroup;
  pacientes!: ListarPacienteVM[];
  medicos!: ListarMedicoVM[];
  consultaVM!: FormConsultaVM;

  constructor(
    private formBuilder: FormBuilder, 
    private consultaService: ConsultaService,
    private toastrService: ToastrService,
    private router: Router,
    private pacienteService: PacienteService, 
    private medicoService: MedicoService) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      titulo: new FormControl('', [Validators.required, Validators.minLength(3)]),
      paciente_id: new FormControl('', [Validators.required]),
      data: new FormControl(new Date(), [Validators.required]),
      horaInicio: new FormControl('08:00:00', [Validators.required]),
      horaTermino: new FormControl('09:00:00', [Validators.required]),
      id_medico: new FormControl('', [Validators.required]),
    });

    this.medicoService.selecionarTodos().subscribe(medicos => this.medicos = medicos);
    this.pacienteService.selecionarTodos().subscribe(pacientes => this.pacientes = pacientes)
  }

  gravar() {
    if (this.form?.invalid) {
      for (let erro of this.form.validate()) {
        this.toastrService.warning(erro);
      }

      return;
    }

    this.consultaService.inserir(this.form?.value).subscribe({
      next: (res) => this.processarSucesso(res),
      error: (err) => this.processarFalha(err),
    });
  }

  processarSucesso(res: FormConsultaVM) {
    this.toastrService.success(
      `A Consulta "${res.titulo}" foi salva com sucesso!`,
      'Sucesso'
    );

    this.router.navigate(['/cirurgias/listar']);
  }

  processarFalha(erro: Error) {
    this.toastrService.error(erro.message, 'Erro');
  }
}
