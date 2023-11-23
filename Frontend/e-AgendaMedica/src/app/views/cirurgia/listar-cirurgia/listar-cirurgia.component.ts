import { Component } from '@angular/core';
import { CirurgiaService } from '../services/cirurgia.service';
import { Observable, map } from 'rxjs';
import { ListarCirurgiaVM } from '../models/listar-cirurgia.view-model';
import { OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';
import { DialogExcluirComponent } from 'src/app/shared/componentes/dialog-excluir/dialog-excluir.component';

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

  excluir(cirurgia: ListarCirurgiaVM){
    let result = this.dialog.open(DialogExcluirComponent, {
      data: { 
        registro: cirurgia.titulo
      }
    });

    result.afterClosed().subscribe(res => {
      if(res == true){
        this.cirurgiaService.excluir(cirurgia.id).subscribe({
          next: () => this.processarSucessoExclusao(),
          error: (err) => this.processarFalhaExclusao(err)
          
        })
      }
    });
  }

  processarSucessoExclusao(): void {
    this.toastrService.success(`Cirurgia excluida com sucesso`, 'Exclusão')
    this.cirurgias$ = this.cirurgiaService.selecionarTodos();
  }

  processarFalhaExclusao(err: Error): void {
    this.toastrService.error(err.message, 'Error')
  }
}
