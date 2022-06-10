import {Injectable} from '@angular/core';
import {Observable } from "rxjs";
import {HttpClient, HttpParams} from "@angular/common/http";
import {environment} from "../../../../environments/environment";

@Injectable({
    providedIn: 'root'
})
export class OrdersService {
    private readonly baseApi:string = "api/orders";
    constructor(private httpClient: HttpClient) {
    }

    getCustomerSalesPredictions(filter: string): Observable<GetCustomerSalesPredictionResponse> {
        const params = new HttpParams().set('customerName', filter );
        return this.httpClient.get<GetCustomerSalesPredictionResponse>(`${environment.baseUrl}/${this.baseApi}`,{params:params})
    }
}

export class GetCustomerSalesPredictionResponse {
    salesDatePrediction: CustomerSalesPrediction[];
}

export class CustomerSalesPrediction {
    custId: number;
    customerName: string;
    lastOrderDate: Date;
    nextPredictedOrder: Date;
}
