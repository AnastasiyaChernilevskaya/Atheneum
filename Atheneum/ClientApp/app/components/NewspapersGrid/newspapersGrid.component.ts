import { Component } from '@angular/core';
import { Http } from "@angular/http";

import { Periodical } from '../domain/interface/libraryentitis';
import { LibraryType } from "../Domain/Enums/LibraryType";
import { NewspaperService } from "../Services/newspaperService";

@Component({
    selector: 'newspapersGrid',
    templateUrl: './newspapersGrid.component.html'
})
export class NewspapersGridComponent {
    public Newspapers: Periodical[] = [];

    constructor(public http: Http, public newspaperService: NewspaperService) {
        this.newspaperService.getNewspapersData().subscribe(result => {
            this.Newspapers = result.json(); 
        });
    }

    private newAttribute: Periodical = {
        id: "",
        includeToFile: false,
        libraryType: 1,
        name: "",
        publisher: "",
        isChanged: false
    };

    addFieldValue() {
        this.Newspapers.push(this.newAttribute);
        var newspaper: Periodical = {
            id: "",
            name: this.newAttribute.name,
            includeToFile: this.newAttribute.includeToFile,
            libraryType: this.newAttribute.libraryType,
            publisher: this.newAttribute.publisher,
            isChanged: false
        }
        this.newspaperService.addNewspaper(newspaper);

        this.newAttribute = {
            id: "",
            includeToFile: false,
            libraryType: 1,
            name: "",
            publisher: "",
            isChanged: false
        };
    }

    deleteFieldValue(index: number, id: string) {
        this.Newspapers.splice(index, 1);
        this.newspaperService.destroyNewspaper(id);
    }

    editFieldValue(newspapers: Periodical) {
        this.newspaperService.editNewspaper(newspapers);
    }

}