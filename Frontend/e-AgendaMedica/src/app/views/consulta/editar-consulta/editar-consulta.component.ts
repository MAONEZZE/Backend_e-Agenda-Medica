import { Component } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { FloatLabelType } from '@angular/material/form-field';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ListarMedicoVM } from '../../medico/models/listar-medico.view-model';
import { MedicoService } from '../../medico/services/medico.service';
import { ListarPacienteVM } from '../../paciente/models/listar-paciente.view-model';
import { PacienteService } from '../../paciente/services/paciente.service';
import { FormConsultaVM } from '../models/form-consulta.view-model';
import { ConsultaService } from '../services/consulta.service';

@Component({
  selector: 'app-editar-consulta',
  templateUrl: './editar-consulta.component.html',
  styleUrls: ['./editar-consulta.component.scss']
})
export class EditarConsultaComponent {
  form!: FormGroup;

  pacientes!: ListarPacienteVM[];
  medicos!: ListarMedicoVM[];

  consultaVM!: FormConsultaVM;

  floatLabelControl = new FormControl('auto' as FloatLabelType);

  constructor(
    private formBuilder: FormBuilder, 
    private consultaService: ConsultaService,
    private toastrService: ToastrService,
    private router: Router,
    private pacienteService: PacienteService, 
    private medicoService: MedicoService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    const consulta = this.route.snapshot.data['consulta'];

    this.form = this.formBuilder.group({
      titulo: new FormControl('', [Validators.required, Validators.minLength(5)]),
      paciente_id: new FormControl('', [Validators.required]),
      data: new FormControl(consulta.data, [Validators.required]),
      horaInicio: new FormControl('00:00', [Validators.required]),
      horaTermino: new FormControl('00:00', [Validators.required]),
      id_medico: new FormControl('', [Validators.required]),
    });

    this.medicoService.selecionarTodos().subscribe(medicos => this.medicos = medicos);
    this.pacienteService.selecionarTodos().subscribe(pacientes => this.pacientes = pacientes);

    this.form.patchValue(consulta);
  }

  getFloatLabelValue(): FloatLabelType {
    return this.floatLabelControl.value || 'auto';
  }

  gravar() {
    if (this.form?.invalid) {
      for (let erro of this.form.validate()) {
        this.toastrService.warning(erro);
      }

      return;
    }

    const horaTermino = this.form.get('horaTermino')?.value;
    const horaInicio = this.form.get('horaInicio')?.value;

    this.form.get('horaInicio')?.setValue(`${horaInicio}:00`);
    this.form.get('horaTermino')?.setValue(`${horaTermino}:00`);

    const id = this.route.snapshot.paramMap.get('id')!;

    this.consultaService.editar(id, this.form?.value).subscribe({
      next: (res) => this.processarSucesso(res),
      error: (err) => this.processarFalha(err),
    });
  }

  processarSucesso(res: FormConsultaVM) {
    this.toastrService.success(
      `A Consulta "${res.titulo}" alterada com sucesso!`,
      'Sucesso'
    );

    this.router.navigate(['/consultas/listar']);
  }

  processarFalha(erro: Error) {
    this.toastrService.error(erro.message, 'Erro');
  }
}
