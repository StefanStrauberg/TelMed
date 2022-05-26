import { Component, Input, OnInit } from '@angular/core';
import { IAnamnesis } from 'src/app/shared/models/anamnesis';
import { ReferralsService } from '../referrals.service';

@Component({
  selector: 'app-anamnesis-table',
  templateUrl: './anamnesis-table.component.html',
  styleUrls: ['./anamnesis-table.component.scss']
})
export class AnamnesisTableComponent implements OnInit {
  @Input() refferalId!: string;
  anamnesies: IAnamnesis[] = [];
  displayedColumns: string[] = ['categoryId', 'summary', 'actions'];

  constructor(private _referralsService: ReferralsService) { }

  ngOnInit(): void {
    this.getAnamnesies();
  }

  getAnamnesies() {
    if(this.refferalId){
      this._referralsService.getAnamnesies(`anamnesis/ByReferralId/${this.refferalId}`).subscribe(response => {
        this.anamnesies = response?.body!;
      }, error => {
        console.log(error);
      })
    }
  }

  deleteAnamnesis(anamnesisId: string) {
    this._referralsService.deleteAnamnesis(`anamnesis/${anamnesisId}`).subscribe(response => {
      this.getAnamnesies();
    }, error => {
      console.log(error);
    })
  }

}
