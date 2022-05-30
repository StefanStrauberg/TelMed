import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { IAccount, IRole } from 'src/app/shared/models/account';
import { IPagination } from 'src/app/shared/models/pagination';
import { Params } from 'src/app/shared/models/params';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-view-accounts',
  templateUrl: './view-accounts.component.html',
  styleUrls: ['./view-accounts.component.scss']
})
export class ViewAccountsComponent implements OnInit {
  accounts: IAccount[] = [];
  roles: IRole[] = [];
  displayedColumns: string[] = ['userName', 'fullName', 'roleId', 'specializationId', 'organizationId', 'contacts', 'isActive', 'actions'];
  accParams = new Params();
  @ViewChild('search', {static: false}) searchTerm!: ElementRef;
  paginationResponse!: IPagination;

  constructor(private accountService: AccountService,
    private router: Router) { }

  ngOnInit(): void {
    this.getAllAccounts();
    this.getAllRoles();
  }

  getAllAccounts() {
    this.accountService.getAccounts('Api/User',this.accParams).subscribe(response => {
      this.paginationResponse = JSON.parse(response?.headers.get('X-Pagination') as string);
      this.accounts = response?.body!;
    }, (error) => {
      this.router.navigate(['/']).then();
      console.log(error);
    })
  }

  private getAllRoles() {
    this.accountService.getRoles('Api/Role').subscribe(response => {
      this.roles = response?.body!;
    }, (error) => {
      this.router.navigate(['/']).then();
      console.log(error);
    })
  }

  deleteAccount(accountId: string){
    if(accountId)
    {
      this.accountService.deleteAccount(`Api/User/${accountId}`).subscribe((date: {}) => {
        this.getAllAccounts();
      }, (error) => {
        console.log(error);
        this.getAllAccounts();
      });
    }
  }

  getRoleName(roleid: string) : string {
    return this.roles.find(x => x.id == roleid)?.name as string;
  }

  onSearch() {
    this.accParams.search = this.searchTerm.nativeElement.value;
    this.accParams.pageNumber = 0;
    this.getAllAccounts();
  }

  onPageChange(event: PageEvent) {
    if(this.paginationResponse.PageSize !== event.pageSize)
    {
      this.accParams.pageSize = event.pageSize;
      this.getAllAccounts();
    }
    if(this.paginationResponse.CurrentPage !== event.pageIndex)
    {
      this.accParams.pageNumber = event.pageIndex;
      this.getAllAccounts();
    }
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.accParams = new Params();
    this.getAllAccounts();
  }
}
