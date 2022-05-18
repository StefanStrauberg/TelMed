import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { IPagination } from 'src/app/shared/models/pagination';
import { Params } from 'src/app/shared/models/params';
import { ISpecialization } from 'src/app/shared/models/specialization';
import { SpecializationsService } from '../specializations.service';

@Component({
  selector: 'app-view-specializations',
  templateUrl: './view-specializations.component.html',
  styleUrls: ['./view-specializations.component.scss']
})
export class ViewSpecializationsComponent implements OnInit {

  @ViewChild('search', {static: false}) searchTerm!: ElementRef;
  specializations: ISpecialization[] = [];
  specParams = new Params();
  displayedColumns: string[] = ['name', 'isActive', 'denyConsult', 'actions'];
  paginationResponse!: IPagination;

  constructor(
    private _specializationsService: SpecializationsService,
    private _router: Router) { }

  ngOnInit(): void {
    this.getAllSpecializations();
  }

  getAllSpecializations(){
    this._specializationsService.getSpecializations('Specialization', this.specParams).subscribe(response => {
      this.paginationResponse = JSON.parse(response?.headers.get('X-Pagination') as string);
      this.specializations = response?.body!;
    }, (error) => {
      console.log(error);
      this._router.navigate(['/']).then();
    })
  }

  deleteSpecialization(specializationId: string){
    this._specializationsService.deleteSpecialization(`Specialization/${specializationId}`).subscribe(data => {
      this.getAllSpecializations();
    }, error => {
      this.getAllSpecializations();
    })
  }

  onSearch() {
    this.specParams.search = this.searchTerm.nativeElement.value;
    this.specParams.pageNumber = 0;
    this.getAllSpecializations();
  }

  onPageChange(event: PageEvent) {
    if(this.paginationResponse.PageSize)
    {
      this.specParams.pageSize = event.pageSize;
      this.getAllSpecializations();
    }
    if(this.paginationResponse.HasNext || this.paginationResponse.HasPrevious)
    {
      this.specParams.pageNumber = event.pageIndex;
      this.getAllSpecializations();
    }
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.specParams = new Params();
    this.getAllSpecializations();
  }
}
