import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ISpecialization } from 'src/app/shared/models/specialization';
import { SpecializationsService } from '../specializations.service';

@Component({
  selector: 'app-create-specialization',
  templateUrl: './create-specialization.component.html',
  styleUrls: ['./create-specialization.component.scss']
})
export class CreateSpecializationComponent implements OnInit {
  specialization: ISpecialization = { 
    isActive: true,
    denyConsult: false
  } as ISpecialization;

  constructor(
    private specializationsService: SpecializationsService,
    private router: Router) { }

  ngOnInit(): void {
  }

  createSpecialization(){
    this.specializationsService.createSpecialization(this.specialization).subscribe((data: {}) => {
      this.router.navigate(['/admin/specializations']).then();
    }, (error) => {
      this.router.navigate(['/admin/specializations/create']).then();
    })
  }
}
