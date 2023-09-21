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



  counter: number = 0;
  newSTIterator: any[] = [];


  skillLevels = Object.values(SkillLevel);
  selectedSkillLevel: SkillLevel = SkillLevel.Beginner;


  constructor(
    public dialogRef: MatDialogRef<EmployeeViewComponent>,
    public dialog: MatDialog,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private addressService: AddressService
  ) {
    //
    this.selEmp = data?.content?.emp;
    console.log(`Employee from view: ${JSON.stringify(this.selEmp)}`);

    //addr
    this.empAddr = data?.content?.addrs;
    console.log(`Address from view: ${JSON.stringify(this.empAddr)}`);
    
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
      Postal_code: [null, [Validators.required, Validators.pattern(/^\d+$/)]]
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
        
       
        console.log("Happy Days for address")

          //reload modal
          // this.onCloseClick()

          //
          // this.openMyself();
          //   //get updated address
        this.addressService.GetAddressOfEmployee(this.selEmp.Id).subscribe((result: any) => {
        console.log(`Updated address: ${JSON.stringify(result)}`);

          this.empAddr = result;

          //reset isAddress variable
          this.addNewAddress();
        });
      })
    } else {
      // Form is invalid, display error messages or take appropriate action
      alert("Invalid Form...");

      //wait for 5 seconds then reload page
    }
  }

 incrementNewSTIterator(){
  this.counter = this.counter + 1;
  console.log(`INC: ${this.counter}`)
  this.newSTIterator.push(this.counter)
 }

 removeSelectedSkillInMemory(indx: any)
 {
  console.log(`Indx to remove: ${indx}`)
  this.newSTIterator = this.newSTIterator.filter(r => r !== indx);
 }

 // Event handler to capture the selected value
//  onSkillLevelSelected(event: any) {
//   this.selectedSkillLevel = event.target.value;
//   console.log('Selected Skill Level:', this.selectedSkillLevel);
// }
onSkillLevelChange(event: any) {
  this.selectedSkillLevel = event.target.value;
  console.log('Selected Skill Level:', this.selectedSkillLevel);
}
}



export enum SkillLevel {
  Beginner = 'beginner',
  Intermediate = 'intermediate',
  Expert = 'expert',
}