import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IAccount, IRole } from 'src/app/shared/models/account';
import { Params } from 'src/app/shared/models/params';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-view-accounts',
  templateUrl: './view-accounts.component.html',
  styleUrls: ['./view-accounts.component.scss']
})
export class ViewAccountsComponent implements OnInit {
  accounts: IAccount[] = [];
  displayedColumns: string[] = ['userName', 'fullName', 'roleId', 'specializationId', 'organizationId', 'contacts', 'isActive', 'actions'];
  accParams = new Params();

  constructor(private accountService: AccountService,
    private router: Router) { }

  ngOnInit(): void {
    this.getAllSpecializations();
  }

  getAllSpecializations() {
    this.accountService.getAccounts(this.accParams).subscribe(response => {
      this.accounts = <IAccount[]>response?.body?.data;
    }, (error) => {
      this.router.navigate(['/']).then();
      console.log(error);
    })
  }

  deleteAccount(accountId: string){
    if(accountId)
    {
      this.accountService.deleteAccount(accountId).subscribe((date: {}) => {
        this.getAllSpecializations();
      }, (error) => {
        this.getAllSpecializations();
      });
    }
  }
}
