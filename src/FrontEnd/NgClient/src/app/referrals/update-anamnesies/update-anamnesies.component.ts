import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { enumValues } from 'src/app/helpers/enum.helper';
import { AnamnesisCategory } from 'src/app/shared/models/anamnesis';
import { ReferralsService } from '../referrals.service';

@Component({
  selector: 'app-update-anamnesies',
  templateUrl: './update-anamnesies.component.html',
  styleUrls: ['./update-anamnesies.component.scss']
})
export class UpdateAnamnesiesComponent implements OnInit {
  referralId: string | null = null;
  anamnesisId: string | null = null;
  ownerForm!: FormGroup;
  anamnesisCategory = AnamnesisCategory;
  enumValuse = enumValues;

  constructor(
    private _formBuilder: FormBuilder,
    private _referralsService: ReferralsService,
    private _router: Router,
    private _activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this._activatedRoute.paramMap.subscribe((param: ParamMap) => {
      this.referralId = param.get('referralId');
      this.anamnesisId = param.get('anamnesisId');
      });
    this.getAnamnesis();
  }

  getAnamnesis() {
    if(this.referralId && this.anamnesisId){
      this._referralsService.getAnamnesis(`anamnesis/${this.anamnesisId}`).subscribe(response => {
        this.ownerForm = this._formBuilder.group({
          referralId: new FormControl(response?.body?.referralId, Validators.required),
          categoryId : new FormControl(response?.body?.categoryId, Validators.required),
          summary : new FormControl(response?.body?.summary, Validators.required),
        });
      }, error => {
        console.log(error);
        this._router.navigate([`/referrals/edit/${this.referralId}`]);
      })
    }
  }

  updateAnamnesis() {
    this._referralsService.updateAnamnesis(`anamnesis/${this.anamnesisId}`, this.ownerForm.value).subscribe(response => {
      this._router.navigate([`/referrals/edit/${this.referralId}`]).then();
    }, error => {
      this._router.navigate([`/referrals/${this.referralId}/anamnesis/edit/${this.anamnesisId}`]).then();
    })
  }

}
