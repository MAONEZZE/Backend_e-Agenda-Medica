import { Component, Input, OnInit } from '@angular/core';
import { ListarMedicoVM } from '../models/listar-medico.view-model';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent {
  @Input() medico!: ListarMedicoVM;
}
