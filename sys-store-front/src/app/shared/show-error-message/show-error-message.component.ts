import {Component, Inject, OnInit, ViewEncapsulation} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";

@Component({
    selector: 'app-show-error-message',
    templateUrl: './show-error-message.component.html',
    styleUrls: ['./show-error-message.component.scss'],
    encapsulation: ViewEncapsulation.None
})
export class ShowErrorMessageComponent implements OnInit {
    data: any;

    constructor(public matDialogRef: MatDialogRef<ShowErrorMessageComponent>,
                @Inject(MAT_DIALOG_DATA) private _data: any) {
        this.data = _data;
    }

    ngOnInit(): void {
    }

}
