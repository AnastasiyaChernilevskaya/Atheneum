import { Component, Injectable } from '@angular/core';
import { Http } from "@angular/http";
import { Book } from '../domain/interface/libraryentitis';
import { LibraryType } from "../Domain/Enums/LibraryType";
@Injectable()
export class BookChangingService {
    libraryType: LibraryType;
    constructor(public http: Http) {

    }

    getBooksData() {
        return this.http.get('http://localhost:50209' +'/api/BooksGridAPI/Get')

    }

    addBook(book: Book) {
        this.http.post('http://localhost:50209' +'/api/BooksGridAPI/Add/', book).subscribe(
            res => {
                console.log(res);
            },
            err => {
                console.log("Error occured");
            }
        );
    }

    editBook(book: Book) {
        this.http.post('http://localhost:50209' +'/api/BooksGridAPI/Edit/', book).subscribe(
            res => {
                console.log(res);
            },
            err => {
                console.log("Error occured");
            }
        );
    }

    destroyBook(id: string) {
        this.http.get('http://localhost:50209' +'/api/BooksGridAPI/Destroy/' + id).subscribe(result => {
            return  result.json();
        });
    }

}