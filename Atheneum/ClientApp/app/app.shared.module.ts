import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';

import { MainGridComponent } from "./components/maingrid/maingrid.component";
import { BooksGridComponent } from "./components/booksgrid/booksGrid.component";
import { NewspapersGridComponent } from "./components/NewspapersGrid/newspapersGrid.component";
import { PeriodicalsGridComponent } from "./components/PeriodicalsGrid/periodicalsGrid.component";

import { BookChangingService } from "./components/services/bookchangingservice";
import { LibraryService } from "./components/Services/libraryService";
import { PeriodicalService } from "./components/Services/periodicalService";
import { NewspaperService } from "./components/Services/newspaperService";



@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,

        HomeComponent,
        MainGridComponent,
        BooksGridComponent,
        NewspapersGridComponent,
        PeriodicalsGridComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'MainGrid', component: MainGridComponent },
            { path: 'booksGrid', component: BooksGridComponent },
            { path: 'newspapersGrid', component: NewspapersGridComponent },
            { path: 'periodicalsGrid', component: PeriodicalsGridComponent },
            { path: '**', redirectTo: 'home', pathMatch: 'full' }
        ])
    ],
    providers: [BookChangingService, LibraryService, PeriodicalService, NewspaperService]

})
export class AppModuleShared {
}
