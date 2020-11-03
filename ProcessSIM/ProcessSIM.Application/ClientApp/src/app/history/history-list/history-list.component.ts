import {Component, OnInit, ViewChild} from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';
import {MatSnackBar} from "@angular/material/snack-bar";
import {HistoryService} from "../../services/history.service";
import {ISimulationResult} from "../../models/simulationResult.interface";
import {HistoryInfoDialog} from "../history-info/history-info.component";

@Component({
  selector: 'app-history-list',
  templateUrl: './history-list.component.html',
})
export class HistoryListComponent implements OnInit {
  historyItems$: ISimulationResult[] = [];

  displayedColumns: string[] = ['dateTime', 'name', 'author', 'duration', 'procedures', 'resources', 'actions'];
  dataSource = new MatTableDataSource(this.historyItems$);

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  constructor(private _historyService: HistoryService, public dialog: MatDialog, private _snackBar: MatSnackBar) {
  }

  ngOnInit() {
    this._historyService.getHistory().subscribe(httpResult => {
      this.historyItems$ = httpResult.historyItems;
      this.updateDataSource();
    });
  }

  updateDataSource() {
    this.dataSource = new MatTableDataSource(this.historyItems$);
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  openInfoDialog(element: ISimulationResult): void {
    const dialogRef = this.dialog.open(HistoryInfoDialog, {
      width: '1200px',
      data: element
    });

    dialogRef.afterClosed().subscribe(result => {

    });
  }

  timeConvert(minutesData) {
    if (minutesData < 60)
      return minutesData;

    const minutes = minutesData % 60;
    const hours = (minutesData - minutes) / 60;

    return `${hours} ч ${minutes} мин`;
  }
}
