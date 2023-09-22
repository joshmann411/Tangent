import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SkillService {

  private APIUrl: string = 'http://localhost:5186/api/Skill';

  constructor(private http: HttpClient) { }

  GetSkillsOfEmployee(employeeId: string): Observable<any>{
    let url = this.APIUrl + `/GetSkillsOfEmployee/${employeeId}`;

    return this.http.get<any>(url);
  }

  AddSkill(skill: any): Observable<any>{
    let url = this.APIUrl + `/AddSkill`;

    return this.http.post<any>(url, skill);
  }

  AddMultipleSkill(skillSet: any): Observable<any>{
    let url = this.APIUrl + `/AddMultipleSkill`;

    return this.http.post<any>(url, skillSet);
  }


  // Task<JsonResult> GetSkill(int id);
  // Task<string> UpdateSkill(Skill skillChanges);
  // Task<string> DeleteSkill(int Id);
}
