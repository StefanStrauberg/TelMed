import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IAccount, IRole } from 'src/app/shared/models/account';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-view-accounts',
  templateUrl: './view-accounts.component.html',
  styleUrls: ['./view-accounts.component.scss']
})
export class ViewAccountsComponent implements OnInit {
  accounts: IAccount[] = [];
  displayedColumns: string[] = ['userName', 'fullName', 'roleId', 'specializationId', 'organizationId', 'contacts', 'isActive', 'actions'];

  constructor(private accountService: AccountService,
    private router: Router) { }

  ngOnInit(): void {
    this.getAllSpecializations();
  }

  getAllSpecializations() {
    this.accountService.getAccounts().subscribe(response => {
      this.accounts = response;
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
