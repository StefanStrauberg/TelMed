import { Pipe, PipeTransform } from '@angular/core';
import { OrganizationRegion } from '../shared/models/organization';

@Pipe({
  name: 'orgReg'
})
export class OrgRegPipe implements PipeTransform {

  transform(value: OrganizationRegion): string {
    switch(value)
    {
      case OrganizationRegion['Брестская область']: return "Брестская область";
      case OrganizationRegion['Витебская область']: return "Витебская область";
      case OrganizationRegion['Гомельская область']: return "Гомельская область";
      case OrganizationRegion['Гродненская область']: return "Гродненская область";
      case OrganizationRegion['Минская область']: return "Минская область";
      case OrganizationRegion['Могилевская область']: return "Могилевская область";
      case OrganizationRegion['Республика Беларусь']: return "Республика Беларусь";
      case OrganizationRegion['г. Минск']: return "г. Минск";
    }
  }

}
