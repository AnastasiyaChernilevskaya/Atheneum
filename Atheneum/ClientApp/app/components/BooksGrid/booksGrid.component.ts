import { Component } from '@angular/core';
import { Http } from "@angular/http";

@Component({
    selector: 'booksGrid',
    templateUrl: './booksGrid.component.html'
})
export class BooksGridComponent {

    private newAttribute: any = {};

    addFieldValue() {
        this.Books.push(this.newAttribute)
        this.newAttribute = {};
    }

    deleteFieldValue(index: number, id: string) {
        this.Books.splice(index, 1);
        this.destroyBook(id);
    }

    public Books: Book[] = [];

    constructor(public http: Http) {
        this.getBooksData();
    }

    getBooksData() {

        this.http.get('/api/BooksGridAPI/Books').subscribe(result => {
            this.Books = result.json();
        });
    }

    destroyBook(id) {
        this.http.get('/api/BooksGridAPI/Destroy/' + id).subscribe(result => {
            this.Books = result.json();
        });
    }
}
enum LibraryType { Book = 0, Newspaper = 1, Periodical = 2, Other =3 };

export interface Book {
    ID: string;
    IncludeToFile: boolean;
    Name: string;
    Publisher: string;
    LibraryType: LibraryType;
    Author: string;
    Date: string;
}