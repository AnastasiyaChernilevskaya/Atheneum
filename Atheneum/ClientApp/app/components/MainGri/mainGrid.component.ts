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
        this.fieldArray.push(this.newAttribute)
        this.newAttribute = {};
    }

    deleteFieldValue(index: number) {
        this.fieldArray.splice(index, 1);
    }   

    public Atheneum: Entity[] = [];

    public Book: Entity[] = [];
    public Newspaper: Entity[] = [];
    public periodical: Entity[] = [];

    constructor(public http: Http) {
        //this.getAtheneumData();
        this.getBooksData();
        //this.getNewspapersData();
        //this.getPeriodicalData();
    }



    //getAtheneumData() {
    //    this.getBooksData();
    //    this.getNewspapersData();
    //    this.getPeriodicalData();
    //}

    getBooksData() {

        this.http.get('/api/MainGridAPI/Book').subscribe(result => {
            this.Book = result.json();
        });
    }

    ngOnInit() {
        this.addEntitysToArray();
    }

    addEntitysToArray() {
        for (var item of this.Book) {
            this.fieldArray.push(item)
        }
    };
    //JSON.stringify{

    //getNewspapersData() {

    //    this.http.get('/api/MainGridAPI/Newspaper').subscribe(result => {
    //        this.Book = result.json();
    //    });
    //}

    //getPeriodicalData() {

    //    this.http.get('/api/MainGridAPI/Periodical').subscribe(result => {
    //        this.Book = result.json();
    //    });
    //}
}

export interface Entity {
    ID: string;
    IncludeToFile: boolean;
    Name: string;
    Publisher: string;
    LibraryType: string;
    Author: string;
}