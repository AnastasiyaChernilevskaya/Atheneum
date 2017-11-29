import { Component } from '@angular/core';
import { Http } from "@angular/http";

@Component({
    selector: 'mainGrid',
    templateUrl: './mainGrid.component.html'
})
export class MainGridComponent {

    private fieldArray: Array<any> = [];
    private newAttribute: any = {};

    addFieldValue() {
        this.Atheneum.push(this.newAttribute)
        this.newAttribute = {};
    }

    deleteFieldValue(index: number, id: string, type: number) {
        this.Atheneum.splice(index, 1);
        //this.destroyAtheneumItem(id, type);
    }  

    public Atheneum: Entity[] = [];

    constructor(public http: Http) {
        this.getAtheneumData();
    }

    getAtheneumData() {
        this.http.get('/api/MainGridAPI/Atheneum').subscribe(result => {
            this.Atheneum = result.json();
        });
    }

    //destroyAtheneumItem(id: string, type: number) {
    //    this.http.get('/api/MainGridAPI/Destroy/' + id + '/' + type).subscribe(result => {
    //        this.Atheneum = result.json();
    //    });
    //}


}
enum LibraryType { Book = 0, Newspaper = 1, Periodical = 2, Other =3 };

export interface Entity {
    ID: string;
    IncludeToFile: boolean;
    Name: string;
    Publisher: string;
    LibraryType: LibraryType;
    Author: string;
}