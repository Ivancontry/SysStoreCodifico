import {Injectable} from '@angular/core';
import {HttpErrorResponse} from "@angular/common/http";
import {MatDialog} from "@angular/material/dialog";
import {throwError} from "rxjs";
import {ShowErrorMessageComponent} from "../shared/show-error-message/show-error-message.component";

@Injectable({
    providedIn: 'root'
})
export class BaseService {
    private responseStatus: ResponseStatus;

    constructor(private dialog: MatDialog) {
    }

    public transformError(error: HttpErrorResponse | string,dialog:MatDialog) {
        this.responseStatus = new ResponseStatus();
        const showError = (response: ResponseStatus): void => {
            if (response.errors || response.title) {

                dialog.open(ShowErrorMessageComponent, {
                    panelClass: 'modal-response',
                    width: '30%',
                    data: response
                });
            }
        };
        if (typeof error === 'string') {
            this.responseStatus.title = error;
            this.responseStatus.classAlert = 'accent';
            showError(this.responseStatus);
            return throwError(this.responseStatus);
        }
        if (!(error instanceof HttpErrorResponse)) {
            return throwError(this.responseStatus);
        }
        if (typeof error.error !== 'object') {
            this.responseStatus.title = error.error;
        }
        this.responseStatus.errors = [];
        if (error.status === 400) {
            this.responseStatus.title = error.error.Message;
            this.responseStatus.classAlert = 'accent';
            if (error.error.Errors) {
                error.error.Errors.forEach(element => {
                    this.responseStatus.errors.push(element.ErrorMessage);
                });
            }
            showError(this.responseStatus);
            return throwError(this.responseStatus);
        }
        this.responseStatus.classAlert = 'warn';

        if (error.status === 500) {
            this.responseStatus.title = error.error.Message;
            showError(this.responseStatus);
        }

        return throwError(this.responseStatus);
    }

}
export class ResponseStatus {
    constructor(public title?: string, public errors?: string[], public classAlert?: string) { }
}
