import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Params } from 'src/app/shared/models/params';
import { ISpecialization } from 'src/app/shared/models/specialization';
import { SpecializationsService } from '../specializations.service';

@Component({
  selector: 'app-view-specializations',
  templateUrl: './view-specializations.component.html',
  styleUrls: ['./view-specializations.component.scss']
})
export class ViewSpecializationsComponent implements OnInit {
  specializations: ISpecialization[] = [];
  specParams = new Params();
  
  constructor(
    private specializationsService: SpecializationsService,
    private router: Router) { }

  ngOnInit(): void {
    this.getAllSpecializations();
  }

  getAllSpecializations(){
    this.specializationsService.getSpecializations(this.specParams).subscribe(response => {
      this.specializations = <ISpecialization[]>response?.data;
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
