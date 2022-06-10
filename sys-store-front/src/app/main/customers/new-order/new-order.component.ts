import {Component, Inject, OnInit, ViewEncapsulation} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {CustomersService} from "../services/customers.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

class Employee {
    emplId: number;
    firstName: string;
}

class Shipper {
    companyName: string;
    shipperId: number;
}

class Product {
    productId: number;
    productName: string;
}

@Component({
    selector: 'app-new-order',
    templateUrl: './new-order.component.html',
    styleUrls: ['./new-order.component.scss'],
    encapsulation:ViewEncapsulation.None
})
export class NewOrderComponent implements OnInit {
    modalTitle: string;
    custId: number;
    formGroup:FormGroup;
    employees: Employee[];
    shippers: Shipper[];
    products: Product[];

    constructor(
        public matDialogRef: MatDialogRef<NewOrderComponent>,
        @Inject(MAT_DIALOG_DATA) _data: any,
        private customersService: CustomersService,
        private formBuilder:FormBuilder
    ) {
        this.custId = +_data.customer.custId;
        this.modalTitle = `${_data.customer.customerName} - New Order`;
    }

    ngOnInit(): void {
        this.formGroup = this.buildForm();
    }

    newOrder() {

    }

    private buildForm() {
        return this.formBuilder.group({
            'custId':this.custId,
            'empid':[0,[Validators.required]],
            'shipperid':[0,[Validators.required]],
            'shipname':["",[Validators.required,Validators.maxLength(40)]],
            'shipaddress':["",[Validators.required,Validators.maxLength(60)]],
            'shipcity':["",[Validators.required,Validators.maxLength(15)]],
            'shipcountry':["",[Validators.required,Validators.maxLength(15)]],
            'orderdate':["",[Validators.required]],
            'requireddate':["",[Validators.required]],
            'shippeddate':["",[Validators.required]],
            'freight':["",[Validators.required]],
            'detail': this.formBuilder.group({
                'productid':["",[Validators.required]],
                'unitprice':["",[Validators.required]],
                'qty':["",[Validators.required]],
                'discount':["",[Validators.required]],
            })
        });
    }
}