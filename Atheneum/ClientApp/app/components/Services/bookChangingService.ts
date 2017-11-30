import { Component } from '@angular/core';
import { Http } from "@angular/http";
import { Book } from '../domain/interface/libraryentitis';

export class BookChangingService {

    constructor(public http: Http) {

    }

    //getBooksData(): Book[] {

    //    //this.http.get('/api/BooksGridAPI/Get').subscribe(result => {
    //    //    return result.json();
    //    //});
    //}

    addBook(book: Book) {
        this.http.post('/api/BooksGridAPI/Add/', book).subscribe(
            res => {
                console.log(res);
            },
            err => {
                console.log("Error occured");
            }
        );
    }

    destroyBook(id: string) {
        this.http.get('/api/BooksGridAPI/Destroy/' + id).subscribe(result => {
            return  result.json();
        });
    }

}