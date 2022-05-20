import { Component, OnInit } from '@angular/core';
import { _MAT_HINT } from '@angular/material/form-field';
import { IReferral } from 'src/app/shared/models/referral';
import { ReferralsService } from '../referrals.service';

@Component({
  selector: 'app-view-referrals',
  templateUrl: './view-referrals.component.html',
  styleUrls: ['./view-referrals.component.scss']
})
export class ViewReferralsComponent implements OnInit {
  referrals: IReferral[] = [];

  constructor(private _referralsService: ReferralsService) { }

  ngOnInit(): void {
    this.getAllReferrals();
  }

  getAllReferrals() {
    this._referralsService.getReferrals('referral').subscribe(response => {
      this.referrals = response?.body!;
    }, error => {
      console.log(error);
    })
  }

}
