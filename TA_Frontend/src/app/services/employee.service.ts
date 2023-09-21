import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private APIUrl: string = 'http://localhost:5186/api/';

  constructor(private http: HttpClient) { }

  GetAllEmployees(): Observable<any>{
    let url = this.APIUrl + 'Employee/GetAllEmployees';

    return this.http.get<any>(url);
  }
  // Task<JsonResult> GetAllEmployees();
  // Task<JsonResult> GetEmployeeById(string id);
  // Task<string> AddEmployee(Employee employee);
  // Task<string> UpdateEmployee(Employee employeeChanges);
  // Task<string> DeleteEmployeeWithId(string Id);
}
