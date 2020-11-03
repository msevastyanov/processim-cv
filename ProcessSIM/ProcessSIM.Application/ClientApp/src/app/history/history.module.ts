import {NgModule} from '@angular/core';
import {RouterModule} from '@angular/router';

import {CommonModule} from '@angular/common';
import {MatCardModule} from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatDialogModule} from '@angular/material/dialog';
import {FormsModule} from "@angular/forms";
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {HistoryComponent} from "./history.component";
import {HistoryListComponent} from "./history-list/history-list.component";
import {HistoryInfoDialog} from "./history-info/history-info.component";
import {MatPaginatorModule} from "@angular/material/paginator";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: '',
        component: HistoryComponent,
        children: [
          {
            path: '',
            component: HistoryListComponent,
          }]
      },
    ]),
    MatCardModule,
    MatTableModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatTooltipModule,
    MatDialogModule,
    MatPaginatorModule,
    MatSnackBarModule,
    FormsModule
  ],
  entryComponents: [HistoryInfoDialog],
  declarations: [
    HistoryComponent,
    HistoryListComponent,
    HistoryInfoDialog
  ],
  providers: [],
})
export class HistoryModule {
}
