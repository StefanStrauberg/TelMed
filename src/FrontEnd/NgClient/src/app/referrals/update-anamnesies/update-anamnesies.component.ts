import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { enumValues } from 'src/app/helpers/enum.helper';
import { AnamnesisCategory, IAnamnesis } from 'src/app/shared/models/referral';
import { ReferralsService } from '../referrals.service';

@Component({
  selector: 'app-update-anamnesies',
  templateUrl: './update-anamnesies.component.html',
  styleUrls: ['./update-anamnesies.component.scss']
})
export class UpdateAnamnesiesComponent implements OnInit {
  referralId: string | null = null;
  anamnesisCategoryId: string | null = null;
  anamnesis!: IAnamnesis;
  ownerForm!: FormGroup;
  anamnesisCategory = AnamnesisCategory;
  enumValuse = enumValues;

  constructor(
    private _activatedRoute: ActivatedRoute,
    private _formBuilder: FormBuilder,
    private _referralsService: ReferralsService,
    private _router: Router) { }

  ngOnInit(): void {
    this._activatedRoute.paramMap.subscribe((param: ParamMap) => {
      this.referralId = param.get('referralId');
      this.anamnesisCategoryId = param.get('anamnesisCategoryId');
    });
    this.getAnamnesis();
  }

  getAnamnesis() {
    if(this.referralId && this.anamnesisCategoryId)
    {
      this._referralsService.getAnamnesis(`anamnesis/${this.referralId}/${this.anamnesisCategoryId}`).subscribe(response => {
        this.ownerForm = this._formBuilder.group({
          categoryId : new FormControl(response?.body?.categoryId, Validators.required),
          summary : new FormControl(response?.body?.summary, Validators.required),
        });
      }, error => {
        console.log(error);
        this._router.navigate([`/referrals/edit/${this.referralId}`]).then();
      })
    }
  }

  updateAnamnesis() {
    if(this.referralId && this.anamnesisCategoryId)
    {
      this._referralsService.updateAnamnesis(`anamnesis/${this.referralId}`, this.ownerForm.value).subscribe(response => {
        this._router.navigate([`/referrals/edit/${this.referralId}`]).then();
      }, error => {
        console.log(error);
        this._router.navigate([`/referrals/${this.referralId}/anamnesis/edit/${this.anamnesisCategoryId}`]).then();
      })
    }
  }

}
