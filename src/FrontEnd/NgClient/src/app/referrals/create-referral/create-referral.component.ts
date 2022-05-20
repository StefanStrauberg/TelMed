import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ReferralsService } from '../referrals.service';

@Component({
  selector: 'app-create-referral',
  templateUrl: './create-referral.component.html',
  styleUrls: ['./create-referral.component.scss']
})
export class CreateReferralComponent implements OnInit {
  ownerForm!: FormGroup;

  constructor(private _formBuilder: FormBuilder,
    private _referralsService: ReferralsService,
    private router: Router) { }

  ngOnInit(): void {
    this.ownerForm = this._formBuilder.group({
      fullName: new FormControl('', Validators.required),
      gender : new FormControl(null, Validators.required),
      birthDate : new FormControl(null, Validators.required),
    });
  }

}
