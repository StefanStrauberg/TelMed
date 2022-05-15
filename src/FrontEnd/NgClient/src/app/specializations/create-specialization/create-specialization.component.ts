import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SpecializationsService } from '../specializations.service';

@Component({
  selector: 'app-create-specialization',
  templateUrl: './create-specialization.component.html',
  styleUrls: ['./create-specialization.component.scss']
})
export class CreateSpecializationComponent implements OnInit {
  ownerForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private specializationsService: SpecializationsService,
    private router: Router) { }

  ngOnInit(): void {
    this.ownerForm = this.formBuilder.group({
      name: new FormControl('', Validators.required),
      denyConsult : new FormControl(null, Validators.required)
    });
  }

  createSpecialization(){
    this.specializationsService.createSpecialization('Specialization' ,this.ownerForm.value).subscribe((data: {}) => {
      this.router.navigate(['/admin/specializations']).then();
    }, (error) => {
      this.router.navigate(['/admin/specializations/create']).then();
    })
  }
}
