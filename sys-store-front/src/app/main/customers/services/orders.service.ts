import {Injectable} from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient, HttpParams} from "@angular/common/http";
import {environment} from "../../../../environments/environment";
import {BaseService} from "../../../services/base.service";
import {catchError} from "rxjs/operators";
import {Employee} from "../models/employee";
import {Shipper} from "../models/shipper";
import {Product} from "../models/product";
import {MatDialog} from "@angular/material/dialog";

@Injectable({
    providedIn: 'root'
})
export class OrdersService {
    private readonly baseApi:string = "api/orders";
    constructor(private httpClient: HttpClient,private baseService:BaseService, private matDialog:MatDialog) {
    }

    getCustomerSalesPredictions(filter: string): Observable<GetCustomerSalesPredictionResponse> {
        const params = new HttpParams().set('customerName', filter );
        return this.httpClient.get<GetCustomerSalesPredictionResponse>(`${environment.baseUrl}/${this.baseApi}`,{params:params})
    }

    createOrder(data: CreateOrderRequest) {
        return this.httpClient.post<{message:string}>(`${environment.baseUrl}/${this.baseApi}`,data)
            .pipe(catchError(t=> this.baseService.transformError(t,this.matDialog)));
    }

    getFormData(){
        return this.httpClient.get<GetFormDataResponse>(`${environment.baseUrl}/${this.baseApi}/form-data`)
    }
}

export class GetFormDataResponse{
    employees:Employee[];
    shippers:Shipper[];
    products:Product[];
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
export class CreateOrderRequest {
    custId: number;
    empid: number;
    shipperid: number;
    shipname: string;
    shipaddress: string;
    shipcity: string;
    shipcountry: string;
    orderdate: Date;
    requireddate: Date;
    shippeddate: Date;
    freight: number;
    detail: CreateOrderDetailRequest;
}

class CreateOrderDetailRequest {
    productid: number;
    unitprice: number;
    qty: number;
    discount: number;
}
