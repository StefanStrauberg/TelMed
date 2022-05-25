import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { enumValues } from 'src/app/helpers/enum.helper';
import { AnamnesisCategory } from 'src/app/shared/models/anamnesis';
import { ReferralsService } from '../referrals.service';

@Component({
  selector: 'app-create-anamnesis',
  templateUrl: './create-anamnesis.component.html',
  styleUrls: ['./create-anamnesis.component.scss']
})
export class CreateAnamnesisComponent implements OnInit {
  referralId: string | null = null;
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
      this.referralId = param.get('id');
      this.ownerForm = this._formBuilder.group({
        referralId: new FormControl(this.referralId, Validators.required),
        categoryId : new FormControl(null, Validators.required),
        summary : new FormControl(null, Validators.required),
      });
    });
  }

}
