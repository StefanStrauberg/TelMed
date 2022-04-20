import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ISpecialization } from 'src/app/shared/models/specialization';
import { SpecializationsService } from '../specializations.service';

@Component({
  selector: 'app-update-specialization',
  templateUrl: './update-specialization.component.html',
  styleUrls: ['./update-specialization.component.scss']
})
export class UpdateSpecializationComponent implements OnInit {
  specializationId: string | null = null;
  specialization: ISpecialization = {} as ISpecialization;

  constructor(
    private activatedRoute: ActivatedRoute,
    private specializationsService: SpecializationsService,
    private router: Router) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((param: ParamMap) => {
      this.specializationId = param.get('id');
    });
    if(this.specializationId){
      this.specializationsService.getSpecialization(this.specializationId).subscribe((data: ISpecialization) => {
        this.specialization = data;
      }, (error) => {
        this.router.navigate([`/admin/specializations`]).then();
      })
    }
  }

  updateSpecialization(){
    if(this.specializationId){
      this.specializationsService.updateSpecialization(this.specialization, this.specializationId).subscribe((data: {}) => {
        this.router.navigate(['/admin/specializations']).then();
      }, (error) => {
        this.router.navigate([`/admin/specializations/edit/${this.specializationId}`]).then();
      })
    }
  }

}
