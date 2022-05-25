import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { enumValues } from 'src/app/helpers/enum.helper';
import { PatientGender } from 'src/app/shared/models/referral';
import { ReferralsService } from '../referrals.service';

@Component({
  selector: 'app-update-patient',
  templateUrl: './update-patient.component.html',
  styleUrls: ['./update-patient.component.scss']
})
export class UpdatePatientComponent implements OnInit {
  referralId: string | null = null;
  ownerForm!: FormGroup;
  genders = PatientGender;
  enumValuse = enumValues;

  constructor(
    private _activatedRoute: ActivatedRoute,
    private _formBuilder: FormBuilder,
    private _referralsService: ReferralsService,
    private _router: Router) { }

    ngOnInit(): void {
      this._activatedRoute.paramMap.subscribe((param: ParamMap) => {
        this.referralId = param.get('id');
      });
      this.getReferral();
    }
  
    getReferral() {
      if(this.referralId)
      {
        this._referralsService.getReferral(`referral/${this.referralId}`).subscribe(data => {
          this.ownerForm = this._formBuilder.group({
            patient: this._formBuilder.group({
              fullName: new FormControl(data?.body?.patient.fullName, Validators.required),
              gender: new FormControl(data?.body?.patient.gender, Validators.required),
              birthDate: new FormControl(data?.body?.patient.birthDate, Validators.required),
            })
          });
        }, error => {
          console.log(error);
          this._router.navigate(['/referrals']);
        })
      }
    }

    updateReferral(){
      if(this.referralId){
        this._referralsService.updateReferral(`referral/${this.referralId}` ,this.ownerForm.value).subscribe(data => {
          this._router.navigate([`/referrals/edit/${this.referralId}`]).then();
        }, (error) => {
          this._router.navigate([`/referrals/${this.referralId}/edit`]).then();
        })
      }
    }

}
