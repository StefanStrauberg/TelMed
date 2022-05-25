import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { IReferral } from 'src/app/shared/models/referral';
import { ReferralsService } from '../referrals.service';

@Component({
  selector: 'app-update-referral',
  templateUrl: './update-referral.component.html',
  styleUrls: ['./update-referral.component.scss']
})
export class UpdateReferralComponent implements OnInit {
  referralId: string | null = null;
  referral!: IReferral;

  constructor(
    private _activatedRoute: ActivatedRoute,
    private _referralsService: ReferralsService,
    private _router: Router) { }

  ngOnInit(): void {
    this._activatedRoute.paramMap.subscribe((param: ParamMap) => {
      this.referralId = param.get('id');
    });
    this.getAllReferral();
  }

  getAllReferral() {
    this._referralsService.getReferral(`referral/${this.referralId}`).subscribe(response => {
      this.referral = response?.body!;
    }, error => {
      console.log(error);
      this._router.navigate(['/referrals']);
    })
  }

}
