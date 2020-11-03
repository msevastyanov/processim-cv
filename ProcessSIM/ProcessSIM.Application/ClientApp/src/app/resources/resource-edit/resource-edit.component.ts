import {Component, Inject} from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import {IDirtyResource} from "../../models/dirtyResource.interface";

@Component({
  selector: 'app-resource-edit',
  templateUrl: './resource-edit.component.html',
})
export class ResourceEditDialog {

  constructor(
    public dialogRef: MatDialogRef<ResourceEditDialog>,
    @Inject(MAT_DIALOG_DATA) public data: IDirtyResource) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

}
