import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ISpecialization } from 'src/app/models/ISpecialization';
import { SpecializationService } from 'src/app/services/specialization.service';

@Component({
  selector: 'app-create-specialization',
  templateUrl: './create-specialization.component.html',
  styleUrls: ['./create-specialization.component.css']
})
export class CreateSpecializationComponent implements OnInit {

  loading: boolean = false;
  specialization: ISpecialization = { isActive: true, denyConsult: false } as ISpecialization; 
  errorMessage: string | null = null;

  constructor(
    private specializationService: SpecializationService,
    private router: Router) { }

  ngOnInit(): void {
  }

  createSpecialization(){
    this.specializationService.createSpecialization(this.specialization).subscribe((data: ISpecialization) => {
      this.router.navigate(['/admin/specializations']).then();
    }, (error) => {
      this.errorMessage = error;
      this.router.navigate(['/admin/specializations/create']).then();
    })
  }

}
