import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShellComponent } from './shell.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { SharedModule } from 'src/app/shared/shared.module';
import { MedicoRoutingModule } from 'src/app/views/medico/medico-routing.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [ShellComponent],
  imports: [
    CommonModule,
    SharedModule,
    MatToolbarModule, 
    MatSidenavModule,
    
  ],
  exports: [
    ShellComponent
  ]
})
export class ShellModule { }
