import { LibraryType } from "../Enums/LibraryType";

export interface Book {
    id: string;
    includeToFile: boolean;
    name: string;
    publisher: string;
    libraryType: LibraryType;
    author: string;
    isChanged: boolean;
}

export interface Entity {
    id: string;
    includeToFile: boolean;
    name: string;
    publisher: string;
    libraryType: LibraryType;
    isChanged: boolean;
}

export interface Periodical {
    id: string;
    includeToFile: boolean;
    name: string;
    publisher: string;
    libraryType: LibraryType;
    isChanged: boolean;
}
