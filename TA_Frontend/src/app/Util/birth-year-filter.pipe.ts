import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'birthYearFilter'
})
export class BirthYearFilterPipe implements PipeTransform {

  transform(employees: any[], selectedYear: number): any[] {
    console.log(`S Y: ${selectedYear}`);
    if (!employees || !selectedYear) {
      return employees;
    }

    return employees.filter((employee) => {
      const birthYear = new Date(employee.DateOfBirth).getFullYear();
      console.log(`Full Year: ${birthYear}`);
      
      return birthYear === selectedYear;
    });
  }

}
