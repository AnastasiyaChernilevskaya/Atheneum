import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';

import { BookChangingService } from "./components/services/bookchangingservice";
import { LibraryService } from "./components/Services/libraryService";
import { PeriodicalService } from "./components/Services/periodicalService";
import { NewspaperService } from "./components/Services/newspaperService";

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        ServerModule,
        AppModuleShared
    ],
    providers: [BookChangingService, LibraryService, PeriodicalService, NewspaperService]
})
export class AppModule {
}
