import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'search'
})
export class SearchPipe implements PipeTransform {
  transform(array: any, objectType: string, searchBy: string,): any {
    if(searchBy) {
      if(objectType === 'employee') {
        return array.filter(element => element.name.includes(searchBy));
      } else if(objectType === 'storage') {
        return array.filter(element => element.address.includes(searchBy));
      }
    }
    
    return array;
  }

}
