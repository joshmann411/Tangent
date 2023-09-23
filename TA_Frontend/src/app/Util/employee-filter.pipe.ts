import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'employeeFilter'
})
export class EmployeeFilterPipe implements PipeTransform {
  
  transform(employees: any[], searchTerm: string | undefined): any[] {
    console.log(`S T: ${searchTerm}`);
    if (!employees || !searchTerm) {
      return employees;
    }

    searchTerm = searchTerm?.toLowerCase();

    const filteredEmployees = employees.filter((employee) => {
      return (
        employee.FirstName?.toLowerCase().includes(searchTerm) ||
        employee.LastName?.toLowerCase().includes(searchTerm) ||
        employee.Email?.toLowerCase().includes(searchTerm)
      );
    });

    return filteredEmployees.length > 0 ? filteredEmployees : []; 
  }


}
