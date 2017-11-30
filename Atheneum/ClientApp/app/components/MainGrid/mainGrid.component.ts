import { Component } from '@angular/core';
import { Http } from "@angular/http";

import { Entity } from '../domain/interface/libraryentitis';

@Component({
    selector: 'mainGrid',
    templateUrl: './mainGrid.component.html'
})
export class MainGridComponent {

    private newAttribute: any = {};
    public Atheneum: Entity[] = [];

    constructor(public http: Http) {
        this.getAtheneumData();
    }

    getAtheneumData() {
        this.http.get('/api/MainGridAPI/Atheneum').subscribe(result => {
            this.Atheneum = result.json();
        });
    }

    addFieldValue() {
        this.Atheneum.push(this.newAttribute)
        this.newAttribute = {};
    }

    deleteFieldValue(index: number) {
        this.Atheneum.splice(index, 1);
    }

}
