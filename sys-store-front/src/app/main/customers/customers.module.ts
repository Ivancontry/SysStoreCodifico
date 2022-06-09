import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {CustomersRoutingModule} from './customers-routing.module';
import {CustomersComponent} from './customers.component';
import {MatPaginatorModule} from "@angular/material/paginator";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {MatTableModule} from "@angular/material/table";
import {MatSortModule} from "@angular/material/sort";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";
import {ReactiveFormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import {CustomersService} from "./customers.service";


@NgModule({
    declarations: [CustomersComponent],
    imports: [
        CommonModule,
        HttpClientModule,
        CustomersRoutingModule,
        MatPaginatorModule,
        MatFormFieldModule,
        MatInputModule,
        MatTableModule,
        MatSortModule,
        MatIconModule,
        MatButtonModule,
        ReactiveFormsModule
    ],
    providers: [CustomersService],
    entryComponents: [CustomersComponent]
})
export class CustomersModule {
}
