import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-employee-add',
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.scss']
})
export class EmployeeAddComponent {
  employeeForm: FormGroup | any;
  
  constructor(
    public dialogRef: MatDialogRef<EmployeeAddComponent>,
    public dialog: MatDialog,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private employeeService: EmployeeService
  ) {
    this.employeeForm = this.fb.group({
      FirstName: [null, Validators.required],
      LastName: [null, [Validators.required]],
      ContactNumber: [null, Validators.required],
      Email: [null, Validators.required],
      DateOfBirth: [null, Validators.required],
    });
    
  }

  onCloseClick(): void {
    // You can perform any necessary actions before closing the dialog here
    this.dialogRef.close();
  }

  closeDialogAndReload() {
    this.dialogRef.close('reload'); // Pass 'reload' as the result
  }

  onEmployeeSubmit(){
    if (this.employeeForm.valid) {
      // Form is valid, handle the submission here
      console.log('New employee form submitted:', this.employeeForm.value);
    
      //add the employee to DB
      this.employeeService.AddEmployee(this.employeeForm.value).subscribe((data: any) => {
        console.log(`New employee add result: ${JSON.stringify(data)}`);
        
        //close the modal and reload the page
        this.closeDialogAndReload();

      })
    }
  }
}
