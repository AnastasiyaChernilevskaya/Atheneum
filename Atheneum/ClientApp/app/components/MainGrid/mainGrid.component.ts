import { Component } from '@angular/core';
import { Http } from "@angular/http";

import { Entity } from '../domain/interface/libraryentitis';
import { LibraryService } from "../Services/libraryService";
import { LibraryType } from "../Domain/Enums/LibraryType";

@Component({
    selector: 'mainGrid',
    templateUrl: './mainGrid.component.html'
})
export class MainGridComponent {
    libraryType =  LibraryType;
    private newAttribute: any = {};
    public atheneum: Entity[] = [];

    constructor(public http: Http, public libraryService: LibraryService) {
        this.getAtheneumData();
    }

    getAtheneumData() {
        this.libraryService.getData().subscribe(result => {
            this.atheneum = result.json();
        })
    }

    deleteFieldValue(index: number, id: string) {
        this.libraryService.destroyEntity(id, this.atheneum[index].libraryType);
        this.atheneum.splice(index, 1);
    }

    editFieldValue(book: Entity) {
        this.libraryService.editEntity(book);
    }

}
