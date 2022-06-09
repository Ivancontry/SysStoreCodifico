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
import {ViewOrdersComponent} from './view-orders/view-orders.component';
import {OrdersService} from "./services/orders.service";
import {CustomersService} from "./services/customers.service";
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatDialogModule} from "@angular/material/dialog";
import {MatDividerModule} from "@angular/material/divider";


@NgModule({
    declarations: [CustomersComponent, ViewOrdersComponent],
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
        ReactiveFormsModule,
        MatToolbarModule,
        MatDialogModule,
        MatDividerModule,
    ],
    providers: [OrdersService, CustomersService]
})
export class CustomersModule {
}
