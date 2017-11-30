export interface Book {
    id: string;
    includeToFile: boolean;
    name: string;
    publisher: string;
    libraryType: LibraryType;
    author: string;
    //date: string;
}

export interface Entity {
    ID: string;
    IncludeToFile: boolean;
    Name: string;
    Publisher: string;
    LibraryType: LibraryType;
    Author: string;
    Date: string;
}