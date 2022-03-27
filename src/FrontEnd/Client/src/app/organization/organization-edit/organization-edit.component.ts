import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { OrganizationUpdate } from 'src/app/_models/organizationUpdate';
import { OrganizationService } from 'src/app/_services/organization.service';

@Component({
  selector: 'app-organization-edit',
  templateUrl: './organization-edit.component.html',
  styleUrls: ['./organization-edit.component.scss']
})
export class OrganizationEditComponent implements OnInit {

  @ViewChild('editForm') editForm!: NgForm;
  data!: OrganizationUpdate;
  
  constructor(
    private organizationService: OrganizationService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.loadOrganization();
  }

  loadOrganization() {
    this.organizationService.getOrganization(this.route.snapshot.paramMap.get('id')!)?.subscribe(response => {
      this.data = response;
      console.log(response);
    })
  }

  updateOrganization(){
    this.organizationService.updateOrganization(this.data).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
    this.router.navigate(['/organizations']);
  }
}
