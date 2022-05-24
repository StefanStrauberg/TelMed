import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { enumValues } from 'src/app/helpers/enum.helper';
import { PatientGender } from 'src/app/shared/models/referral';
import { ReferralsService } from '../referrals.service';

@Component({
  selector: 'app-create-referral',
  templateUrl: './create-referral.component.html',
  styleUrls: ['./create-referral.component.scss']
})
export class CreateReferralComponent implements OnInit {
  ownerForm!: FormGroup;
  genders = PatientGender;
  enumValuse = enumValues;

  constructor(private _formBuilder: FormBuilder,
    private _referralsService: ReferralsService,
    private router: Router) { }

  ngOnInit(): void {
    this.ownerForm = this._formBuilder.group({
      patient: this._formBuilder.group({
        fullName: new FormControl(null, Validators.required),
        gender : new FormControl(null, Validators.required),
        birthDate : new FormControl(null, Validators.required),
      })
    });
  }

  createReferral(){
    if(this.ownerForm.valid)
    {
      this._referralsService.createReferral('referral', this.ownerForm.value).subscribe(response => {
        this.router.navigate(['/referrals']).then();
      }, (error) => {
        console.log(error);
        this.router.navigate(['/referrals/create']).then();
      })
    }
  }
}
