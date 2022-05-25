import { Component, Input, OnInit, Output } from '@angular/core';
import { IReferral, ReferralStatus } from 'src/app/shared/models/referral';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-referral-card',
  templateUrl: './referral-card.component.html',
  styleUrls: ['./referral-card.component.scss']
})
export class ReferralCardComponent implements OnInit {
  referralStatus = ReferralStatus;
  @Input() data!: IReferral;
  @Output() onRemove = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  onRemoveClick(id: string) {
    this.onRemove.emit(id);
  }

}
