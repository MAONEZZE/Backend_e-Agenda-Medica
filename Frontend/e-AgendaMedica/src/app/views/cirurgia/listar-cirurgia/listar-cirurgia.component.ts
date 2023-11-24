import { Component } from '@angular/core';
import { CirurgiaService } from '../services/cirurgia.service';
import { Observable, map } from 'rxjs';
import { ListarCirurgiaVM } from '../models/listar-cirurgia.view-model';
import { OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';
import { DialogExcluirComponent } from 'src/app/shared/componentes/dialog-excluir/dialog-excluir.component';
import { DialogVisualizacaoComponent } from '../dialog/dialog-visualizacao/dialog-visualizacao.component';

@Component({
  selector: 'app-listar-cirurgia',
  templateUrl: './listar-cirurgia.component.html',
  styleUrls: ['./listar-cirurgia.component.scss']
})
export class ListarCirurgiaComponent implements OnInit{
  cirurgias$!: Observable<ListarCirurgiaVM[]>;

  constructor(private cirurgiaService: CirurgiaService, private toastrService: ToastrService, private route: ActivatedRoute, private dialog: MatDialog){}

  ngOnInit(): void {
    this.cirurgias$ = this.route.data.pipe(map((dados) => dados['cirurgias']));
  }

  visualizar(cirurgia: ListarCirurgiaVM){
    this.cirurgiaService.selecionarCirurgiaCompletaPorId(cirurgia.id).subscribe((cirurgiaRes) => {
      this.dialog.open(DialogVisualizacaoComponent, {
        data: { 
          registro: cirurgiaRes
        }
      });
    })
  }

  excluir(cirurgia: ListarCirurgiaVM){
    console.log(cirurgia)
    let result = this.dialog.open(DialogExcluirComponent, {
      data: { 
        registro: cirurgia.titulo
      }
    });

    result.afterClosed().subscribe(res => {
      if(res == true){
        console.log(res)
        this.cirurgiaService.excluir(cirurgia.id).subscribe({
          next: () => this.processarSucessoExclusao(),
          error: (err) => this.processarFalhaExclusao(err)
          
        })
      }
    });
  }

  selecionarTodas(){
    this.cirurgias$ = this.cirurgiaService.selecionarTodos();
  }

  selecionarParaHoje(){
    this.cirurgias$ = this.cirurgiaService.selecionarTodosCirurgiasParaHoje();
  }

  selecionarFuturas(){
    this.cirurgias$ = this.cirurgiaService.selecionarCirurgiasFuturas();
  }

  selecionarPassadas(){
    this.cirurgias$ = this.cirurgiaService.selecionarCirurgiasPassadas();
  }

  processarSucessoExclusao(): void {
    this.toastrService.success(`Cirurgia excluida com sucesso`, 'Exclusão')
    this.cirurgias$ = this.cirurgiaService.selecionarTodos();
  }

  processarFalhaExclusao(err: Error): void {
    this.toastrService.error(err.message, 'Error')
  }
}
