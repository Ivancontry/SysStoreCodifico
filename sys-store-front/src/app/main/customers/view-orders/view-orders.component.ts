import {Component, Inject, OnInit, ViewChild, ViewEncapsulation} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {MatTableDataSource} from "@angular/material/table";
import {MatSort} from "@angular/material/sort";
import {MatPaginator} from "@angular/material/paginator";
import {CustomersService, OrderForCustomer} from "../services/customers.service";

@Component({
    selector: 'app-view-orders',
    templateUrl: './view-orders.component.html',
    styleUrls: ['./view-orders.component.scss'],
    encapsulation:ViewEncapsulation.None
})
export class ViewOrdersComponent implements OnInit {
    modalTitle: string = "Customer";
    displayedColumns: string[] = ['orderId', 'requiredDate', 'shippedDate', "shipName", "shipAddress", "shipCity"];
    dataSource: MatTableDataSource<OrderForCustomer>;
    custId: number;

    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatPaginator) paginator: MatPaginator;

    constructor(
        public matDialogRef: MatDialogRef<ViewOrdersComponent>,
        @Inject(MAT_DIALOG_DATA) _data: any,
        private customersService: CustomersService
    ) {
        this.custId = +_data.customer.custId;
        this.modalTitle = `${_data.customer.customerName} - Orders`;
    }

    ngOnInit(): void {
        this.getOrders();
    }

    private getOrders(): void {
        this.customersService.getOrders(this.custId).subscribe(result => {
            this.renderTable(result.ordersForCustomer);
        })
    }

    private renderTable(orders: OrderForCustomer[]) {
        this.dataSource = new MatTableDataSource(orders);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
    }

}
