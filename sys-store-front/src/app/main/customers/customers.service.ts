import {Injectable} from '@angular/core';
import {Observable, of} from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class CustomersService {
    private customers: CustomerSalesPrediction[] = [
        {
            customerName: "Customer AHPOP",
            empId: 1,
            lastOrderDate: new Date(2020, 1, 1),
            nextPredictedOrder: new Date(2020, 2, 1)
        },
        {
            empId: 2,
            customerName: "Customer AHXHT",
            lastOrderDate: new Date(2020, 4, 1),
            nextPredictedOrder: new Date(2020, 5, 5)
        }
    ]

    constructor() {
    }

    getCustomerSalesPredictions(filter: string): Observable<GetCustomerSalesPredictionResponse> {
        return of({salesDatePrediction: this.customers.filter(t => !filter || t.customerName.toLowerCase().includes(filter.toLowerCase()))})
    }
}

export class GetCustomerSalesPredictionResponse {
    salesDatePrediction: CustomerSalesPrediction[];
}

export class CustomerSalesPrediction {
    empId: number;
    customerName: string;
    lastOrderDate: Date;
    nextPredictedOrder: Date;
}
