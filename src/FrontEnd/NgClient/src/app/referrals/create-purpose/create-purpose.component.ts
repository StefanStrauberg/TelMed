import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { enumValues } from 'src/app/helpers/enum.helper';
import { PurposeGroup } from 'src/app/shared/models/referral';
import { ReferralsService } from '../referrals.service';

@Component({
  selector: 'app-create-purpose',
  templateUrl: './create-purpose.component.html',
  styleUrls: ['./create-purpose.component.scss']
})
export class CreatePurposeComponent implements OnInit {
  referralId: string | null = null;
  ownerForm!: FormGroup;
  purposeGroup = PurposeGroup;
  enumValuse = enumValues;

  constructor(
    private _activatedRoute: ActivatedRoute,
    private _formBuilder: FormBuilder,
    private _referralsService: ReferralsService,
    private _router: Router) { }

  ngOnInit(): void {
    this._activatedRoute.paramMap.subscribe((param: ParamMap) => {
      this.referralId = param.get('id');
      this.ownerForm = this._formBuilder.group({
        group : new FormControl(null, Validators.required),
        resume : new FormControl(null, Validators.required),
      });
    });
  }

  createPurpose(){
    if(this.ownerForm.valid)
    {
      this._referralsService.createPurpose('purpose', this.ownerForm.value).subscribe(response => {
        this._router.navigate([`/referrals/edit/${this.referralId}`]).then();
      }, (error) => {
        console.log(error);
        this._router.navigate([`/referrals/${this.referralId}/purpose/create`]).then();
      })
    }
  }

}
