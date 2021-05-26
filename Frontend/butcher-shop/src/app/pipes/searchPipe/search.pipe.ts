import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'search'
})
export class SearchPipe implements PipeTransform {
  transform(array: any, searchBy: string): any {
    if(searchBy) {
      return array.filter(element => element.name.includes(searchBy));
    } return array;
  }

}
