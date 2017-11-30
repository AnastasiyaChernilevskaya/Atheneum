﻿import { Component, Injectable } from '@angular/core';
import { Http } from "@angular/http";
import { Book } from '../domain/interface/libraryentitis';
import { LibraryType } from "../Domain/Enums/LibraryType";
@Injectable()
export class BookChangingService {
    LibraryType: LibraryType;
    constructor(public http: Http) {

    }

    getBooksData() {
        return this.http.get('/api/BooksGridAPI/Get')
        //    .subscribe(result => {
        //});
    }

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

    editBook(book: Book) {
        this.http.post('/api/BooksGridAPI/Edit/', book).subscribe(
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