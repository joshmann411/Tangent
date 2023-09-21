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
  
  // Task<JsonResult> GetAllSkills();
  // Task<JsonResult> GetSkill(int id);
  // Task<string> AddSkill(Skill skill);
  // Task<string> UpdateSkill(Skill skillChanges);
  // Task<string> DeleteSkill(int Id);
}
