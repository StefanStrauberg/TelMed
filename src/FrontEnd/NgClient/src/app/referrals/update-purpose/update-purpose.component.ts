import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { enumValues } from 'src/app/helpers/enum.helper';
import { IPurpose, PurposeGroup } from 'src/app/shared/models/referral';
import { ReferralsService } from '../referrals.service';

@Component({
  selector: 'app-update-purpose',
  templateUrl: './update-purpose.component.html',
  styleUrls: ['./update-purpose.component.scss']
})
export class UpdatePurposeComponent implements OnInit {
  referralId: string | null = null;
  purposeGroupId: string | null = null;
  purpose!: IPurpose;
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
      this.referralId = param.get('referralId');
      this.purposeGroupId = param.get('purposeGroupId');
    });
    this.getPurpose();
  }

  getPurpose() {
    if(this.referralId && this.purposeGroupId)
    {
      this._referralsService.getPurpose(`purpose/${this.referralId}/${this.purposeGroupId}`).subscribe(response => {
        this.ownerForm = this._formBuilder.group({
          group : new FormControl(response?.body?.group, Validators.required),
          resume : new FormControl(response?.body?.resume, Validators.required),
        });
      }, error => {
        console.log(error);
        this._router.navigate([`/referrals/edit/${this.referralId}`]).then();
      })
    }
  }

  updatePurpose() {
    if(this.referralId && this.purposeGroupId)
    {
      this._referralsService.updateAnamnesis(`purpose/${this.referralId}`, this.ownerForm.value).subscribe(response => {
        this._router.navigate([`/referrals/edit/${this.referralId}`]).then();
      }, error => {
        console.log(error);
        this._router.navigate([`/referrals/${this.referralId}/purpose/edit/${this.purposeGroupId}`]).then();
      })
    }
  }

}
