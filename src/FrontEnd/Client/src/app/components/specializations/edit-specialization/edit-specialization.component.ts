import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ISpecialization } from 'src/app/models/ISpecialization';
import { SpecializationService } from 'src/app/services/specialization.service';

@Component({
  selector: 'app-edit-specialization',
  templateUrl: './edit-specialization.component.html',
  styleUrls: ['./edit-specialization.component.css']
})
export class EditSpecializationComponent implements OnInit {

  specializationId: string | null = null;
  loading: boolean = false;
  specialization: ISpecialization = {} as ISpecialization;
  errorMessage: string | null = null;

  constructor(
    private activatedRoute: ActivatedRoute,
    private specializationService: SpecializationService,
    private router: Router) { }

  ngOnInit(): void {
    this.loading = true;
    this.activatedRoute.paramMap.subscribe((param: ParamMap) => {
      this.specializationId = param.get('id');
    });
    if(this.specializationId){
      this.specializationService.getSpecialization(this.specializationId).subscribe((data: ISpecialization) => {
        this.specialization = data;
        this.loading = false;
      }, (error) => {
        this.errorMessage = error;
        this.loading = false;
      })
    }
  }

  updateSpecialization(){
    if(this.specializationId){
      this.specializationService.updateSpecialization(this.specialization, this.specializationId).subscribe((data: ISpecialization) => {
        this.router.navigate(['/admin/specializations']).then();
      }, (error) => {
        this.errorMessage = error;
        this.router.navigate([`/admin/specializations/edit/${this.specializationId}`]).then();
      })
    }
  }
}
