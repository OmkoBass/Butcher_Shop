import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'search'
})
export class SearchPipe implements PipeTransform {
  transform(array: any, objectType: string, searchBy: string,): any {
    if(searchBy) {
      return array.filter(element => element[objectType].includes(searchBy));
    }
    
    return array;
  }

}
