import { Pipe, PipeTransform } from '@angular/core';
import { Role } from '../shared/models/account';

@Pipe({
  name: 'roles'
})
export class RolesPipe implements PipeTransform {

  transform(value: Role): string {
    switch(value)
    {
      case Role['Врач']: return "Врач";
      case Role['Консультант']: return "Консультант";
      case Role['Администратор']: return "Администратор";
      case Role['Координатор-консультант']: return "Координатор-консультант";
      case Role['Координатор-врач']: return "Координатор-врач";
      case Role['Разработчик [Exception]']: return "Разработчик [Exception]";
    }
  }

}
