import { Component, Input, OnInit } from '@angular/core';
import { IAnamnesis } from 'src/app/shared/models/referral';
import { ReferralsService } from '../referrals.service';

@Component({
  selector: 'app-anamnesis-table',
  templateUrl: './anamnesis-table.component.html',
  styleUrls: ['./anamnesis-table.component.scss']
})
export class AnamnesisTableComponent implements OnInit {
  @Input()referralId: string | null = null;
  @Input()anamnesies: IAnamnesis[] = [];
  displayedColumns: string[] = ['categoryId', 'summary', 'actions'];

  constructor(private _referralsService: ReferralsService) { }

  ngOnInit(): void {
  }

  deleteAnamnesis(anamnesisId: string) {
    this._referralsService.deleteAnamnesis(`anamnesis/${this.referralId}/${anamnesisId}`).subscribe(response => {
    }, error => {
      console.log(error);
    })
  }

}
