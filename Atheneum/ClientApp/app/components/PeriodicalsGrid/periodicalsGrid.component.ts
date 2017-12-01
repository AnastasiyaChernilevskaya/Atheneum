import { Component } from '@angular/core';
import { Http } from "@angular/http";

import { Periodical } from '../domain/interface/libraryentitis';
import { LibraryType } from "../Domain/Enums/LibraryType";
import { PeriodicalService } from "../Services/periodicalService";

@Component({
    selector: 'periodicalsGrid',
    templateUrl: './periodicalsGrid.component.html',
})
export class PeriodicalsGridComponent {
    public periodicals: Periodical[] = [];

    constructor(public http: Http, public periodicalService: PeriodicalService) {
        this.periodicalService.getPeriodicalData().subscribe(result => {
            this.periodicals = result.json(); 
        });
    }

    private newAttribute: Periodical = {
        id: "",
        includeToFile: false,
        libraryType: 2,
        name: "",
        publisher: "",
        isChanged: false
    };

    addFieldValue() {
        this.periodicals.push(this.newAttribute);
        var periodical: Periodical = {
            id: "",
            name: this.newAttribute.name,
            includeToFile: this.newAttribute.includeToFile,
            libraryType: 2,
            publisher: this.newAttribute.publisher,
            isChanged: false
        }
        this.periodicalService.addPeriodical(periodical);

        this.newAttribute = {
            id: "",
            includeToFile: false,
            libraryType: 2,
            name: "",
            publisher: "",
            isChanged: false
        };
    }

    deleteFieldValue(index: number, id: string) {
        this.periodicals.splice(index, 1);
        this.periodicalService.destroyPeriodical(id);
    }

    editFieldValue(periodical: Periodical) {
        this.periodicalService.editPeriodical(periodical);
    }

}