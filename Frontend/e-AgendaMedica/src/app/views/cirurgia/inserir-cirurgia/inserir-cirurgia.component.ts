import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ListarPacienteVM } from '../../paciente/models/listar-paciente.view-model';
import { ListarMedicoVM } from '../../medico/models/listar-medico.view-model';
import { FormCirurgiaVM } from '../models/form-cirurgia.view-model';
import { PacienteService } from '../../paciente/services/paciente.service';
import { MedicoService } from '../../medico/services/medico.service';
import { CirurgiaService } from '../services/cirurgia.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-inserir-cirurgia',
  templateUrl: './inserir-cirurgia.component.html',
  styleUrls: ['./inserir-cirurgia.component.scss']
})
export class InserirCirurgiaComponent implements OnInit{
  form!: FormGroup;
  pacientes!: ListarPacienteVM[];
  medicos!: ListarMedicoVM[];
  cirurgiaVM!: FormCirurgiaVM;

  constructor(
    private formBuilder: FormBuilder, 
    private cirurgiaService: CirurgiaService,
    private toastrService: ToastrService,
    private router: Router,
    private pacienteService: PacienteService, 
    private medicoService: MedicoService) { }
  
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      titulo: new FormControl('', [Validators.required, Validators.minLength(3)]),
      paciente_id: new FormControl('', [Validators.required]),
      data: new FormControl('09/10/2023', [Validators.required]),
      horaInicio: new FormControl('08:00:00', [Validators.required]),
      horaTermino: new FormControl('09:00:00', [Validators.required]),
      id_medicos: new FormControl('', [Validators.required]),
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

    this.cirurgiaService.inserir(this.form?.value).subscribe({
      next: (res) => this.processarSucesso(res),
      error: (err) => this.processarFalha(err),
    });
  }

  processarSucesso(res: FormCirurgiaVM) {
    this.toastrService.success(
      `O compromisso "${res.titulo}" foi salvo com sucesso!`,
      'Sucesso'
    );

    this.router.navigate(['/cirurgias/listar']);
  }

  processarFalha(erro: Error) {
    this.toastrService.error(erro.message, 'Erro');
  }

}
