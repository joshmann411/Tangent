import { Component } from '@angular/core';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeViewComponent } from '../template/employee-view/employee-view.component';
import { MatDialog } from '@angular/material/dialog';
import { AddressService } from 'src/app/services/address.service';
import { SkillService } from 'src/app/services/skill.service';
import { EmployeeAddComponent } from '../template/employee-add/employee-add.component';

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

  openAddNewEmployeeDialog(){
    const dialogRef = this.dialog.open(EmployeeAddComponent, {
      width: '400px',
      data: {
        title: 'Add Employee'
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('Dialog closed with result:', result);

      if (result === 'reload') {
        // Wait for 2 seconds and then reload the page
        setTimeout(() => {
          window.location.reload();
        }, 2000);
      }
    });
  }

  openDialog(selEmp: any) {
    let ampAddr: any[] | null = null;
    let empSkills: any[] | null = null;

    //append selEmp
    this.addressService.GetAddressOfEmployee(selEmp.Id).subscribe((result: any) => {
      console.log(`Employees address: ${JSON.stringify(result)}`);

      ampAddr = result;

      this.skillService.GetSkillsOfEmployee(selEmp.Id).subscribe((data: any) => {
        console.log(`Employees skills: ${JSON.stringify(data)}`);
        
        empSkills = data


        //
        let selEmp_Addr_Skills = {
          emp: selEmp,
          addrs: ampAddr,
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
      });
    });

    
  }
}
