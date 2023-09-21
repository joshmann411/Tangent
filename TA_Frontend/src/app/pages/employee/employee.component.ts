import { Component } from '@angular/core';
import { EmployeeService } from 'src/app/services/employee.service';
import { MatDialog } from '@angular/material/dialog';
import { EmployeeViewComponent } from '../template/employee-view/employee-view.component';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent {
  allEmployees: any;

  constructor(
    private employeeService: EmployeeService,
    public dialog: MatDialog
    ){
  }

  ngOnInit()
  {
    this.employeeService.GetAllEmployees().subscribe((data: any) =>{
      this.allEmployees = data;

      console.log(`All Emps: ${JSON.stringify(data)}`);
      
    })
  }

  TriggerSelectedEmployee(selEmployee: any)
  {
    alert(`Employee ${JSON.stringify(selEmployee)} clicked`)
  }

  openDialog(selEmp: any) {
    const dialogRef = this.dialog.open(EmployeeViewComponent, {
      width: '250px',
      data: {
        title: 'Dialog Title',
        content: `Data to display in the dialog: ${selEmp}`
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('Dialog closed with result:', result);
    });
  }
}
