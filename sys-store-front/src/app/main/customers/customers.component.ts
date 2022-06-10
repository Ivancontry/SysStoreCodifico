import {AfterViewInit, Component,  ViewChild} from '@angular/core';
import {MatTableDataSource} from "@angular/material/table";
import {MatSort} from "@angular/material/sort";
import {MatPaginator} from "@angular/material/paginator";
import {FormControl} from "@angular/forms";
import {debounceTime, distinctUntilChanged, filter} from "rxjs/operators";
import {CustomerSalesPrediction, OrdersService} from "./services/orders.service";
import { MatDialog } from '@angular/material/dialog';
import {ViewOrdersComponent} from "./view-orders/view-orders.component";
import {NewOrderComponent} from "./new-order/new-order.component";

@Component({
    selector: 'app-customers',
    templateUrl: './customers.component.html',
    styleUrls: ['./customers.component.scss']
})
export class CustomersComponent implements AfterViewInit {
    displayedColumns: string[] = ['name', 'lastOrderDate', 'nextPredictedOrderDate', "actions"];
    dataSource: MatTableDataSource<CustomerSalesPrediction>;
    searchControl: FormControl = new FormControl();

    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatPaginator) paginator: MatPaginator;

    constructor(private customersService: OrdersService,private matDialog:MatDialog) {
        this.applyFilter("");
    }

    private renderTable(customers: CustomerSalesPrediction[]) {
        this.dataSource = new MatTableDataSource(customers);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
    }

    ngAfterViewInit() {
        this.searchControl.valueChanges.pipe(distinctUntilChanged(), filter(t => t.length >= 2 || t.length == 0), debounceTime(500))
            .subscribe(change => {
                this.applyFilter(change)
            })
    }

    applyFilter(filterValue: string) {
        this.customersService.getCustomerSalesPredictions(filterValue)
            .subscribe(result => {
                this.renderTable(result.salesDatePrediction)
            })
    }

    viewOrders(customer: CustomerSalesPrediction) {
        this.matDialog.open(ViewOrdersComponent, {
            panelClass: ['modal-component'],
            width: '70%',
            height: 'auto',
            data: {
                customer: customer
            }
        });
    }

    newOrder(customer:CustomerSalesPrediction) {
        this.matDialog.open(NewOrderComponent, {
            panelClass: ['modal-component'],
            data: {
                customer: customer
            }
        });
    }
}

