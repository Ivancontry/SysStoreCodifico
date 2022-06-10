import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatNativeDateModule} from "@angular/material/core";
import {BaseService} from "./services/base.service";
import {MatDialogModule} from "@angular/material/dialog";

@NgModule({
    declarations: [
        AppComponent,
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        MatNativeDateModule,MatDialogModule
    ],
    providers: [BaseService],
    bootstrap: [AppComponent]
})
export class AppModule {
}
