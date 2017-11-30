import { Component } from '@angular/core';
import { Http } from "@angular/http";

import { Book } from '../domain/interface/libraryentitis';
import { BookChangingService } from '../services/bookchangingservice';

@Component({
    selector: 'booksGrid',
    templateUrl: './booksGrid.component.html'
})
export class BooksGridComponent {

    public Books: Book[] = [];

    constructor(public http: Http, public bookChangingService: BookChangingService) {
        //bookChangingService.getBooksData();
        this.http.get('/api/BooksGridAPI/Get').subscribe(result => {
            return result.json();
        });
    }

    private newAttribute: Book = {
        author: "",
        //date: "",
        id: "",
        includeToFile: false,
        libraryType: 0,
        name: "",
        publisher: ""
    };

    addFieldValue() {
        this.Books.push(this.newAttribute);
        var book: Book = {
            id: "",
            author: this.newAttribute.author,
            name: this.newAttribute.name,
            //date: new Date().toDateString(),
            includeToFile: false,
            libraryType: 0,
            publisher: this.newAttribute.publisher
        }
        this.bookChangingService.addBook(book);

        this.newAttribute = {
            author: "",
            //date: "",
            id: "",
            includeToFile: false,
            libraryType: 0,
            name: "",
            publisher: ""
        };
    }

    deleteFieldValue(index: number, id: string) {
        this.Books.splice(index, 1);
        this.bookChangingService.destroyBook(id);
    }
}