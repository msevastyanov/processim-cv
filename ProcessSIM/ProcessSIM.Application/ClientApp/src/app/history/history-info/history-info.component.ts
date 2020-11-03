import {Component, Inject} from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import {ISimulationResult} from "../../models/simulationResult.interface";

@Component({
  selector: 'app-history-info',
  templateUrl: './history-info.component.html',
  styleUrls: ['./history-info.component.css'],
})
export class HistoryInfoDialog {

  constructor(
    public dialogRef: MatDialogRef<HistoryInfoDialog>,
    @Inject(MAT_DIALOG_DATA) public data: ISimulationResult) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

  timeConvert(minutesData) {
    if (minutesData < 60)
      return minutesData;

    const minutes = minutesData % 60;
    const hours = (minutesData - minutes) / 60;

    return `${hours} ч ${minutes} мин`;
  }

}
