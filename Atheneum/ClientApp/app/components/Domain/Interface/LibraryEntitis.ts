import { LibraryType } from "../Enums/LibraryType";

export interface Book {
    id: string;
    includeToFile: boolean;
    name: string;
    publisher: string;
    libraryType: LibraryType;
    author: string;
    isChanged: boolean;
    //date: string;
}

export interface Entity {
    ID: string;
    IncludeToFile: boolean;
    Name: string;
    Publisher: string;
    LibraryType: LibraryType;
    isChanged: boolean;
}