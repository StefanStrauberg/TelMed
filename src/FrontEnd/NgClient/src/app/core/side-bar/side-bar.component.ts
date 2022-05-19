import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss']
})
export class SideBarComponent implements OnInit {
  @Input() isUserAdmin: boolean = false;
  @Input() isUserAuthenticated: boolean = false;
  @Input() isUserDocktor: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

}
