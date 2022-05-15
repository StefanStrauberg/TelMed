import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
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
  ownerForm!: FormGroup;
  specName: string | null = null;

  constructor(
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private specializationsService: SpecializationsService,
    private router: Router) { }

  async ngOnInit() {
    this.activatedRoute.paramMap.subscribe((param: ParamMap) => {
      this.specializationId = param.get('id');
    });
    this.getSpecialization();
  }

  getSpecialization() {
    if(this.specializationId){
      this.specializationsService.getSpecialization(`Specialization/${this.specializationId}`).subscribe((data: ISpecialization) => {
        this.specName = data.name;
        this.ownerForm = this.formBuilder.group({
          name: new FormControl(data.name, Validators.required),
          isActive: new FormControl(data.isActive, Validators.required),
          denyConsult: new FormControl(data.denyConsult, Validators.required),
        });
      }, (error) => {
        this.router.navigate([`/admin/specializations`]).then();
      })
    }
  }

  updateSpecialization(){
    if(this.specializationId){
      this.specializationsService.updateSpecialization(`Specialization/${this.specializationId}` ,this.ownerForm.value).subscribe((data: {}) => {
        this.router.navigate(['/admin/specializations']).then();
      }, (error) => {
        this.router.navigate([`/admin/specializations/edit/${this.specializationId}`]).then();
      })
    }
  }

}
