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
    LibraryType = LibraryType;
    options: string[] = [];
    private newAttribute: any = {};
    public Atheneum: Entity[] = [];

    constructor(public http: Http, public libraryService: LibraryService) {
        this.getAtheneumData();
        this.getLibraryTypes();
    }

    getAtheneumData() {
        this.libraryService.getData().subscribe(result => {
            this.Atheneum = result.json();
        })
    }

    deleteFieldValue(index: number, id: string) {
        this.libraryService.destroyEntity(id, this.Atheneum[index].libraryType);
        this.Atheneum.splice(index, 1);
    }

    editFieldValue(book: Entity) {
        this.libraryService.editEntity(book);
    }

    getLibraryTypes() {
        for (var key in LibraryType) {
            if (key.length == 1) {
                this.options.push(LibraryType[key]);
            }
        }
    }

}
