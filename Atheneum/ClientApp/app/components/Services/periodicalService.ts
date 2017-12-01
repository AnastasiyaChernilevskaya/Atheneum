import { Component, Injectable } from '@angular/core';
import { Http } from "@angular/http";
import { Periodical } from '../domain/interface/libraryentitis';
import { LibraryType } from "../Domain/Enums/LibraryType";

@Injectable()
export class PeriodicalService {

    LibraryType: LibraryType;
    constructor(public http: Http) {

    }

    getPeriodicalData() {
        return this.http.get('/api/PeriodicalGridAPI/Get');
    }

    addPeriodical(Periodical: Periodical) {
        this.http.post('/api/PeriodicalGridAPI/Add/', Periodical).subscribe(
            res => {
                console.log(res);
            },
            err => {
                console.log("Error occured");
            }
        );
    }

    editPeriodical(Periodical: Periodical) {
        this.http.post('/api/PeriodicalGridAPI/Edit/', Periodical).subscribe(
            res => {
                console.log(res);
            },
            err => {
                console.log("Error occured");
            }
        );
    }

    destroyPeriodical(id: string) {
        this.http.get('/api/PeriodicalGridAPI/Destroy/' + id ).subscribe(result => {
            return  result.json();
        });
    }
}