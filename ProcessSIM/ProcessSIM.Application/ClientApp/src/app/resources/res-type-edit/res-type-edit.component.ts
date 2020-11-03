import {Component, Inject} from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import {IDirtyType} from "../../models/dirtyType.interface";

@Component({
  selector: 'app-res-type-edit',
  templateUrl: './res-type-edit.component.html',
})
export class ResourceTypeEditDialog {

  constructor(
    public dialogRef: MatDialogRef<ResourceTypeEditDialog>,
    @Inject(MAT_DIALOG_DATA) public data: IDirtyType) {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
