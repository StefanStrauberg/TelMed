import { Component, Input, OnInit } from '@angular/core';
import { IPurpose } from 'src/app/shared/models/referral';
import { ReferralsService } from '../referrals.service';

@Component({
  selector: 'app-purpose-table',
  templateUrl: './purpose-table.component.html',
  styleUrls: ['./purpose-table.component.scss']
})
export class PurposeTableComponent implements OnInit {
  @Input() refferalId!: string;
  purposes: IPurpose[] = [];
  displayedColumns: string[] = ['group', 'resume', 'actions'];

  constructor(private _referralsService: ReferralsService) { }

  ngOnInit(): void {
  }

  getPurposes() {
    if(this.refferalId){
      this._referralsService.getPurposes(`purpose/ByReferralId/${this.refferalId}`).subscribe(response => {
        this.purposes = response?.body!;
      }, error => {
        console.log(error);
      })
    }
  }

  deletePurpose(purposeId: string) {
    this._referralsService.deleteAnamnesis(`purpose/${purposeId}`).subscribe(response => {
      this.getPurposes();
    }, error => {
      console.log(error);
    })
  }

}
