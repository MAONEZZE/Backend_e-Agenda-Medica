import { Component, Input } from '@angular/core';
import { ListarConsultaVM } from '../models/listar-consulta.view-model';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent {
  @Input() consulta!: ListarConsultaVM;
}
