import {Component, Inject, Input} from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import {IComplexity} from "../../models/complexity.interface";

@Component({
  selector: 'app-input-complexity',
  templateUrl: './input-complexity.component.html',
})
export class InputComplexityDialog {

  constructor(
    public dialogRef: MatDialogRef<InputComplexityDialog>,
    @Inject(MAT_DIALOG_DATA) public data: IComplexity) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

}
