import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatInputModule } from '@angular/material/input';
import { CardHoverDirective } from './directives/card-hover.directive';



@NgModule({
  declarations: [CardHoverDirective],
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    MatTooltipModule,
    MatInputModule,
  ],
  exports: [
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    MatTooltipModule,
    MatInputModule,
    CardHoverDirective
  ],
})
export class SharedModule { }
