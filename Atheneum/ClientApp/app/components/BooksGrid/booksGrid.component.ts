import { Component } from '@angular/core';
import { Http } from "@angular/http";

@Component({
    selector: 'booksGrid',
    templateUrl: './booksGrid.component.html'
})
export class BooksGridComponent {

    public Books: Book[] = [];

    constructor(public http: Http) {
        this.getBooksData();
    }

    private newAttribute: Book = {
        author: "",
        date: "",
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
            date: new Date().toDateString(),
            includeToFile: false,
            libraryType: 0,
            publisher: this.newAttribute.publisher
        }

        this.http.post('/api/BooksGridAPI/Add', book ).subscribe(result => {
        });
        this.newAttribute = {
            author: "",
            date: "",
            id: "",
            includeToFile: false,
            libraryType: 0,
            name: "",
            publisher: ""
        };
    }

    deleteFieldValue(index: number, id: string) {
        this.Books.splice(index, 1);
        this.destroyBook(id);
    }

    getBooksData() {

        this.http.get('/api/BooksGridAPI/Get').subscribe(result => {
            this.Books = result.json();
        });
    }

    destroyBook(id: string) {
        this.http.get('/api/BooksGridAPI/Destroy/' + id).subscribe(result => {
            this.Books = result.json();
        });
    }
}
enum LibraryType { Book = 0, Newspaper = 1, Periodical = 2, Other = 3 };

export interface Book {
    id: string;
    includeToFile: boolean;
    name: string;
    publisher: string;
    libraryType: LibraryType;
    author: string;
    date: string;
}