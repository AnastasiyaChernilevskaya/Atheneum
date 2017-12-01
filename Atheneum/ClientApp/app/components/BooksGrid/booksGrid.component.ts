import { Component } from '@angular/core';
import { Http } from "@angular/http";

import { Book } from '../domain/interface/libraryentitis';
import { BookChangingService } from '../services/bookchangingservice';
import { LibraryType } from "../Domain/Enums/LibraryType";

@Component({
    selector: 'booksGrid',
    templateUrl: './booksGrid.component.html',
})
export class BooksGridComponent {
    public Books: Book[] = [];

    constructor(public http: Http, public bookChangingService: BookChangingService) {
        this.bookChangingService.getBooksData().subscribe(result => {
            this.Books = result.json(); 
        });
    }

    private newAttribute: Book = {
        author: "",
        id: "",
        includeToFile: false,
        libraryType: 0,
        name: "",
        publisher: "",
        isChanged: false
    };

    addFieldValue() {
        this.Books.push(this.newAttribute);
        var book: Book = {
            id: "",
            author: this.newAttribute.author,
            name: this.newAttribute.name,
            includeToFile: this.newAttribute.includeToFile,
            libraryType: 0,
            publisher: this.newAttribute.publisher,
            isChanged: false
        }
        this.bookChangingService.addBook(book);

        this.newAttribute = {
            author: "",
            id: "",
            includeToFile: false,
            libraryType: 0,
            name: "",
            publisher: "",
            isChanged: false
        };
    }

    deleteFieldValue(index: number, id: string) {
        this.Books.splice(index, 1);
        this.bookChangingService.destroyBook(id);
    }

    editFieldValue(book: Book) {
        this.bookChangingService.editBook(book);
    }

}