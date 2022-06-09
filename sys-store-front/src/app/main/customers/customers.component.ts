import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {MatTableDataSource} from "@angular/material/table";
import {MatSort} from "@angular/material/sort";
import {MatPaginator} from "@angular/material/paginator";
import {FormControl} from "@angular/forms";
import {debounceTime, distinctUntilChanged, filter} from "rxjs/operators";
import {CustomerSalesPrediction, CustomersService} from "./customers.service";

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

    constructor(private customersService: CustomersService) {
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

}

