import { Pipe, PipeTransform } from '@angular/core';
import { PatientGender } from '../shared/models/referral';

@Pipe({
  name: 'patientGender'
})
export class PatientGenderPipe implements PipeTransform {

  transform(value: PatientGender): string {
    switch(value)
    {
      case PatientGender['Мужской']: return "Мужской";
      case PatientGender['Женский']: return "Женский";
    }
  }

}
