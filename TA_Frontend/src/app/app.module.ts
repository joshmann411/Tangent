import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeComponent } from './pages/employee/employee.component';
import { AddSkillComponent } from './pages/template/skillTemplate/add-skill/add-skill.component';
import { EditSkillComponent } from './pages/template/skillTemplate/edit-skill/edit-skill.component';
import { ViewSkillComponent } from './pages/template/skillTemplate/view-skill/view-skill.component';
import {HttpClientModule} from '@angular/common/http';
import { EmployeeViewComponent } from './pages/template/employee-view/employee-view.component';
import { EmployeeEditComponent } from './pages/template/employee-edit/employee-edit.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EmployeeAddComponent } from './pages/template/employee-add/employee-add.component';
import { EmployeeFilterPipe } from './Util/employee-filter.pipe';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeComponent,
    AddSkillComponent,
    EditSkillComponent,
    ViewSkillComponent,
    EmployeeViewComponent,
    EmployeeEditComponent,
    EmployeeAddComponent,
    EmployeeFilterPipe,

    
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
