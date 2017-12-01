import { Component, Injectable } from '@angular/core';
import { Http } from "@angular/http";
import { Periodical } from '../domain/interface/libraryentitis';
import { LibraryType } from "../Domain/Enums/LibraryType";

@Injectable()
export class NewspaperService {

    LibraryType: LibraryType;
    constructor(public http: Http) {

    }

    getNewspapersData() {
        return this.http.get('http://localhost:50209' +'/api/NewspaperGridAPI/Get');
    }

    addNewspaper(newspaper: Periodical) {
        this.http.post('http://localhost:50209' +'/api/NewspaperGridAPI/Add/', newspaper).subscribe(
            res => {
                console.log(res);
            },
            err => {
                console.log("Error occured");
            }
        );
    }

    editNewspaper(newspaper: Periodical) {
        this.http.post('http://localhost:50209' +'/api/NewspaperGridAPI/Edit/', newspaper).subscribe(
            res => {
                console.log(res);
            },
            err => {
                console.log("Error occured");
            }
        );
    }

    destroyNewspaper(id: string) {
        this.http.get('http://localhost:50209' +'/api/NewspaperGridAPI/Destroy/' + id).subscribe(result => {
            return  result.json();
        });
    }

}