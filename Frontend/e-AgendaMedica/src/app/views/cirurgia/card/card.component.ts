import { Component, Input } from '@angular/core';
import { ListarCirurgiaVM } from '../models/listar-cirurgia.view-model';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent {
  @Input() cirurgia!: ListarCirurgiaVM;
}
