import { Component, Injectable } from '@angular/core';
import { Http } from "@angular/http";
import { Entity } from '../domain/interface/libraryentitis';
import { LibraryType } from "../Domain/Enums/LibraryType";
@Injectable()
export class LibraryService {
    LibraryType: LibraryType;
    constructor(public http: Http) {

    }

    getData() {
        return this.http.get('http://localhost:50209' +'/api/MainGridAPI/Get');
    }

    addEntity(entity: Entity) {
        this.http.post('http://localhost:50209' +'/api/MainGridAPI/Add/', entity).subscribe(
            res => {
                console.log(res);
            },
            err => {
                console.log("Error occured");
            }
        );
    }

    editEntity(entity: Entity) {
        this.http.post('http://localhost:50209' +'/api/MainGridAPI/Edit/', entity).subscribe(
            res => {
                console.log(res);
            },
            err => {
                console.log("Error occured");
            }
        );
    }

    destroyEntity(id: string, type: number) {
        this.http.get('http://localhost:50209' +'/api/MainGridAPI/Destroy/' + id + '/' + type).subscribe(result => {
            return  result.json();
        });
    }

}