import { Component, Input, OnInit } from '@angular/core';
import { IPurpose } from 'src/app/shared/models/referral';
import { ReferralsService } from '../referrals.service';

@Component({
  selector: 'app-purpose-table',
  templateUrl: './purpose-table.component.html',
  styleUrls: ['./purpose-table.component.scss']
})
export class PurposeTableComponent implements OnInit {
  @Input()referralId: string | null = null;
  @Input()purposes: IPurpose[] = [];
  displayedColumns: string[] = ['group', 'resume', 'actions'];

  constructor(private _referralsService: ReferralsService) { }

  ngOnInit(): void {
  }

  deletePurpose(purposeGroupId: string) {
    this._referralsService.deletePurpose(`purpose/${this.referralId}/${purposeGroupId}`).subscribe(response => {
    }, error => {
      console.log(error);
    })
  }

}
