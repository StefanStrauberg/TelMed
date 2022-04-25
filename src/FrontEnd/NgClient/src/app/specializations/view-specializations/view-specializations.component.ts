import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
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
  totalCount!: number;
  
  constructor(
    private specializationsService: SpecializationsService,
    private router: Router) { }

  ngOnInit(): void {
    this.getAllSpecializations();
  }

  getAllSpecializations(){
    this.specializationsService.getSpecializations(this.specParams).subscribe(response => {
      this.specializations = <ISpecialization[]>response?.data;
      this.specParams.pageNumber = response!.pageIndex;
      this.specParams.pageSize = response!.pageSize;
      this.totalCount = response!.count;
    }, (error) => {
      this.router.navigate(['/']).then();
      console.log(error);
    })
  }

  deleteSpecialization(specializationId: string){
    this.specializationsService.deleteSpecialization(specializationId).subscribe((data: {}) => {
      this.getAllSpecializations();
    }, error => {
      this.getAllSpecializations();
    })
  }

  onSearch() {
    this.specParams.search = this.searchTerm.nativeElement.value;
    this.specParams.pageNumber = 1;
    this.getAllSpecializations();
  }

  onPageChange(event: any) {
    if(this.specParams.pageNumber !== event)
    {
      this.specParams.pageNumber = event;
      this.getAllSpecializations();
    }
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.specParams = new Params();
    this.getAllSpecializations();
  }
}
