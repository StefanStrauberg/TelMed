import { Component, OnInit } from '@angular/core';
import { ISpecialization } from 'src/app/models/ISpecialization';
import { SpecializationService } from 'src/app/services/specialization.service';

@Component({
  selector: 'app-view-specializations',
  templateUrl: './view-specializations.component.html',
  styleUrls: ['./view-specializations.component.css']
})
export class ViewSpecializationsComponent implements OnInit {

  loading: boolean = false;
  specializations: ISpecialization[] = [];
  errorMessage: string | null = null;

  constructor(private specializationService: SpecializationService) { }

  ngOnInit(): void {
    this.getAllOrganizations();
  }

  getAllOrganizations(){
    this.loading = true;
    this.specializationService.getAllSpecializations().subscribe((data: ISpecialization[]) => {
      this.specializations = data;
      this.loading = false;
    }, (error) => {
      this.errorMessage = error;
      console.log(this.errorMessage);
      this.loading = false;
    })
  }
}
