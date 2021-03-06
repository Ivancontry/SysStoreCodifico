import {Component, Inject, OnInit, ViewEncapsulation} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {CreateOrderRequest, OrdersService} from "../services/orders.service";
import {MatSnackBar} from "@angular/material/snack-bar";
import {Employee} from "../models/employee";
import {Shipper} from "../models/shipper";
import {Product} from "../models/product";


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
        private formBuilder:FormBuilder,
        private orderService:OrdersService,
        private matSnackBar:MatSnackBar
    ) {
        this.custId = +_data.customer.custId;
        this.modalTitle = `${_data.customer.customerName} - New Order`;
    }

    ngOnInit(): void {
        this.formGroup = this.buildForm();
        this.orderService.getFormData().subscribe(result => {
            this.employees = result.employees;
            this.shippers = result.shippers;
            this.products = result.products;
        });
    }

    newOrder() {
        const data:CreateOrderRequest = this.formGroup.getRawValue();
        this.orderService.createOrder(data).subscribe(result=> {
          if (!result) return;
          this.matSnackBar.open(result.message,'Create Order',{duration: 3000});
          this.matDialogRef.close();
        })
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
                'discount':["",[Validators.required,Validators.pattern("^[0]([.,][0-9]{1,3})?$")]],
            })
        });
    }

}
