import { Pipe, PipeTransform } from '@angular/core';
import { OrganizationLevel } from '../models/IOrganization';

@Pipe({
  name: 'orgLev'
})
export class OrgLevPipe implements PipeTransform {

  transform(value: OrganizationLevel): string {
    switch(value){
      case OrganizationLevel['Областной уровень']: return "Областной уровень";
      case OrganizationLevel['Районный уровень']: return "Районный уровень";
      case OrganizationLevel['Республиканский уровень']: return "Республиканский уровень";
    }
  }

}
