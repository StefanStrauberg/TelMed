import { Pipe, PipeTransform } from '@angular/core';
import { ReferralStatus } from '../shared/models/referral';

@Pipe({
  name: 'referralStatus'
})
export class ReferralStatusPipe implements PipeTransform {

  transform(value: ReferralStatus): string {
    switch(value) 
    {
      case ReferralStatus['Недооформлено']: return "Недооформлено";
      case ReferralStatus['Открыто']: return "Открыто";
      case ReferralStatus['Консультация оформлена']: return "Консультация оформлена";
      case ReferralStatus['Требует дополнения']: return "Требует дополнения";
      case ReferralStatus['Аннулировано']: return "Аннулировано";
    }
  }

}
