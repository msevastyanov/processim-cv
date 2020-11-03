import {Component, Inject} from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
  selector: 'app-sim-data',
  templateUrl: './sim-data.component.html',
})
export class SimDataDialog {

  constructor(
    public dialogRef: MatDialogRef<SimDataDialog>,
    @Inject(MAT_DIALOG_DATA) public data: any) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

}
