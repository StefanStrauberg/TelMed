import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { SideBarComponent } from './side-bar/side-bar.component';
import { RouterModule } from '@angular/router';
import { FooterComponent } from './footer/footer.component';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [
    NavBarComponent,
    SideBarComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    MatButtonModule
  ],
  exports: [
    NavBarComponent,
    SideBarComponent,
    FooterComponent,
  ]
})
export class CoreModule { }
