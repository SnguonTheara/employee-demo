import { Pipe, PipeTransform } from '@angular/core';
@Pipe({
  name: 'gender'
})
export class GenderPipe implements PipeTransform {
  transform(value: string): string {
    if(value == "1") return "Male";
    if(value == "2") return "Female";
    return "Other";
  }
}