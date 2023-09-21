import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AddressService {
  private APIUrl: string = 'http://localhost:5186/api/Address/';
  
  constructor(private http: HttpClient) { }

  GetAllAddress(): Observable<any>{
    let url = this.APIUrl + 'GetAllAddress';

    return this.http.get<any>(url);
  }

  GetAddressById(id: number): Observable<any>{
    let url = this.APIUrl + `GetAddressById/${id}`;

    return this.http.get<any>(url);
  }
  
  GetAddressOfEmployee(employee: string): Observable<any>{
    let url = this.APIUrl + `GetAddressOfEmployee/${employee}`;

    return this.http.get<any>(url);
  }

  AddAddress(employeeAddress: any): Observable<any>{
    let url = this.APIUrl + `AddAddress`;

    return this.http.post<any>(url, employeeAddress);
  }

  // Task<String> UpdateAddress(Address addressChanges);
  // Task<String> DeleteAddress(int Id);
}
