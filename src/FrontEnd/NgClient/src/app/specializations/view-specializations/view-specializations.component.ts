import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ISpecialization } from 'src/app/shared/models/specialization';
import { SpecializationsService } from '../specializations.service';

@Component({
  selector: 'app-view-specializations',
  templateUrl: './view-specializations.component.html',
  styleUrls: ['./view-specializations.component.scss']
})
export class ViewSpecializationsComponent implements OnInit {
  specializations: ISpecialization[] = [];
  
  constructor(
    private specializationsService: SpecializationsService,
    private router: Router) { }

  ngOnInit(): void {
    this.getAllSpecializations();
  }

  getAllSpecializations(){
    this.specializationsService.getSpecializations().subscribe((data: ISpecialization[]) => {
      this.specializations = data;
    }, (error) => {
      this.router.navigate(['/']).then();
    })
  }

  deleteSpecialization(specializationId: string){
    this.specializationsService.deleteSpecialization(specializationId).subscribe((data: {}) => {
      this.getAllSpecializations();
    }, error => {
      this.getAllSpecializations();
    })
  }
}
