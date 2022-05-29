import { Pipe, PipeTransform } from '@angular/core';
import { AnamnesisCategory } from '../shared/models/referral';

@Pipe({
  name: 'anamnesisCategories'
})
export class AnamnesisCategoriesPipe implements PipeTransform {

  transform(value: AnamnesisCategory): string {
    switch(value)
    {
      case AnamnesisCategory['Анамнез жизни']: return "Анамнез жизни";
      case AnamnesisCategory['Анамнез заболевания']: return "Анамнез заболевания";
      case AnamnesisCategory['Объективный статус']: return "Объективный статус";
    }
  }

}
