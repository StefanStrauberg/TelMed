import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-update-anamnesies',
  templateUrl: './update-anamnesies.component.html',
  styleUrls: ['./update-anamnesies.component.scss']
})
export class UpdateAnamnesiesComponent implements OnInit {
  referralId: string | null = null;
  anamnesisId: string | null = null;

  constructor(
    private _activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this._activatedRoute.paramMap.subscribe((param: ParamMap) => {
      this.referralId = param.get('referralId');
      this.anamnesisId = param.get('anamnesisId');
      });
  }

}
