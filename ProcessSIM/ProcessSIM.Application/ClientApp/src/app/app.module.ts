import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import {RouterModule} from '@angular/router';

import {AppComponent} from './app.component';
import {NavMenuComponent} from './nav-menu/nav-menu.component';
import {HomeComponent} from './home/home.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from '@angular/material/button';
import {MatMenuModule} from '@angular/material/menu';
import {MatPaginatorModule} from '@angular/material/paginator';

import {ProcedureService} from './services/procedure.service';
import {ResourceService} from './services/resource.service';
import {ResourceCategoryService} from './services/resourceCategory.service';
import {ResourceTypeService} from "./services/resourceType.service";
import {ResourceParameterService} from "./services/resourceParameter.service";
import {ResourceParameterValueService} from "./services/resourceParameterValue.service";
import {SimulationService} from "./services/simulation.service";
import {SnackAlertComponent} from "./snack-alert/snack-alert.component";
import {MatCardModule} from "@angular/material/card";
import {HistoryService} from "./services/history.service";
import {AuthService} from "./services/auth.service";
import {LoginComponent} from "./login/login.component";
import {MatInputModule} from "@angular/material/input";
import {MatSnackBarModule} from "@angular/material/snack-bar";
import {AuthInterceptor} from "./interceptors/auth.interceptor";
import {ConfirmDialog} from "./confirm-dialog/confirm-dialog.component";
import {MatDialogModule} from "@angular/material/dialog";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    SnackAlertComponent,
    ConfirmDialog
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    MatInputModule,
    MatCardModule,
    MatSnackBarModule,
    MatMenuModule,
    MatPaginatorModule,
    MatDialogModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent, pathMatch: 'full'},
      {path: 'login', component: LoginComponent, pathMatch: 'full'},
      {
        path: 'simulation',
        loadChildren: './simulation/simulation.module#SimulationModule',
      },
      {
        path: 'resources',
        loadChildren: './resources/resources.module#ResourcesModule',
      },
      {
        path: 'history',
        loadChildren: './history/history.module#HistoryModule',
      },
    ]),
    BrowserAnimationsModule,
    MatIconModule,
    MatToolbarModule,
    MatButtonModule,
  ],
  entryComponents: [SnackAlertComponent, ConfirmDialog],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }, ProcedureService, ResourceService, ResourceCategoryService, ResourceTypeService, ResourceParameterService, ResourceParameterValueService, SimulationService, HistoryService, AuthService],
  bootstrap: [AppComponent]
})
export class AppModule {
}
