import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {environment} from "../../../../environments/environment";

export class OrderForCustomer {
    orderId: number;
    requiredDate: Date;
    shippedDate: Date;
    shipName: string;
    shipAddress: string;
    shipCity: string;
}

class GetOrdersResponse {
    ordersForCustomer: OrderForCustomer[]
}

@Injectable({
    providedIn: 'root'
})
export class CustomersService {
    private readonly baseApi: string = "api/customers";

    constructor(private httpClient: HttpClient) {
    }

    getOrders(custId: number): Observable<GetOrdersResponse> {
        return this.httpClient.get<GetOrdersResponse>(`${environment.baseUrl}/${this.baseApi}/${custId}/orders`)
    }
}

