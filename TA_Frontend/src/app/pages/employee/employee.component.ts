import { Component } from '@angular/core';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeViewComponent } from '../template/employee-view/employee-view.component';
import { MatDialog } from '@angular/material/dialog';
import { AddressService } from 'src/app/services/address.service';
import { SkillService } from 'src/app/services/skill.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent {
  allEmployees: any;

  constructor(
    public dialog: MatDialog,
    private employeeService: EmployeeService,
    private addressService: AddressService,
    private skillService: SkillService
    ){
  }

  ngOnInit()
  {
    this.employeeService.GetAllEmployees().subscribe((data: any) =>{
      this.allEmployees = data;

      console.log(`All Emps: ${JSON.stringify(data)}`);
      
    })
  }

  // TriggerSelectedEmployee(selEmployee: any)
  // {
  //   // alert(`Employee ${JSON.stringify(selEmployee)} clicked`)

    
  //   this.openDialog(selEmployee);
  // }

  openDialog(selEmp: any) {
    let empAddress = null;
    let empSkills = null;

    //append selEmp
    this.addressService.GetAddressOfEmployee(selEmp.Id).subscribe((result: any) => {
      console.log(`Employees address: ${JSON.stringify(result)}`);

      empAddress = result;

      this.skillService.GetSkillsOfEmployee(selEmp.Id).subscribe((data: any) => {
        console.log(`Employees skills: ${JSON.stringify(result)}`);
        empSkills = data
      });
    });

    let selEmp_Addr_Skills = {
      emp: selEmp,
      addr: empAddress,
      skills: empSkills
    }

    const dialogRef = this.dialog.open(EmployeeViewComponent, {
      width: '400px',
      data: {
        title: 'View Employee',
        content: selEmp_Addr_Skills
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('Dialog closed with result:', result);
    });
  }
}
