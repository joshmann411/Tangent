import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators  } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { AddressService } from 'src/app/services/address.service';

@Component({
  selector: 'app-employee-view',
  templateUrl: './employee-view.component.html',
  styleUrls: ['./employee-view.component.scss']
})
export class EmployeeViewComponent {
  selEmp: any;
  empAddr: any;
  empSkills: any;


  addressForm: FormGroup | any;

  //address form fields
  // streetNumber: number = 0
  // Street: string = ""
  // Suburb: string = ""
  // City : string = ""
  // StateProvince: string = ""
  // Country: string = ""
  // PostalCode: number = 0

  isAddAddress: boolean = false;

  constructor(
    public dialogRef: MatDialogRef<EmployeeViewComponent>,
    public dialog: MatDialog,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private addressService: AddressService
  ) {
    //
    this.selEmp = data?.content?.emp;
    //addr
    this.empAddr = data?.content?.addr;
    //skills
    this.empSkills = data?.content?.skills


    this.addressForm = this.fb.group({
      EmployeeId: [this.selEmp.Id, Validators.required],
      Street_Number: [null, [Validators.required, Validators.pattern(/^\d+$/)]],
      Street: [null, Validators.required],
      Suburb: [null, Validators.required],
      City: [null, Validators.required],
      State: [null, Validators.required],
      Country: [null, Validators.required],
      PostalCode: [null, [Validators.required, Validators.pattern(/^\d+$/)]]
    });
  }

  onCloseClick(): void {
    // You can perform any necessary actions before closing the dialog here
    this.dialogRef.close();
  }

  addNewAddress(){
    // toggle add template
    this.isAddAddress = !this.isAddAddress
  }

  onAddressSubmit(){
    if (this.addressForm.valid) {
      // Form is valid, handle the submission here
      console.log('Form submitted:', this.addressForm.value);

      //send for address update for employee
      this.addressService.AddAddress(this.addressForm.value).subscribe((response: any) => {
        console.log(`Response: ${JSON.stringify(response)}`);
        
        if(response.status == 200) //success
        {
          //reload modal
          this.onCloseClick()

          //
          this.openMyself();
        }
      })
    } else {
      // Form is invalid, display error messages or take appropriate action
      alert("Invalid Form...");

      //wait for 5 seconds then reload page
    }
  }

  openMyself() {
    let selEmp_Addr_Skills = {
      emp: this.selEmp,
      addr: this.empAddr,
      skills: this.empSkills
    }

    const dialogRef = this.dialog.open(EmployeeViewComponent, {
      width: '400px',
      data: {
        title: 'View Employee',
        content: selEmp_Addr_Skills
      }
    });
  }

  getObjectLength(obj: any): number {
    if (!obj) {
      return 0; // Return 0 if the object is not defined or falsy
    }

    console.log(`Count: ${Object.keys(obj).length}`);
    
    return Object.keys(obj).length;
  }

  
}
