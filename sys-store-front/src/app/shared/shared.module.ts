import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShowErrorMessageComponent } from './show-error-message/show-error-message.component';
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatDialogModule} from "@angular/material/dialog";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";



@NgModule({
  declarations: [ShowErrorMessageComponent],
    imports: [
        CommonModule,
        MatToolbarModule,
        MatDialogModule,
        MatIconModule,
        MatButtonModule
    ],
    schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class SharedModule { }
