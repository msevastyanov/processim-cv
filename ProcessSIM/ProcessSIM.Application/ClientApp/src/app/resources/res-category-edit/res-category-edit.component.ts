import {Component, Inject} from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import {IDirtyCategory} from "../../models/dirtyCategory.interface";

@Component({
  selector: 'app-res-category-edit',
  templateUrl: './res-category-edit.component.html',
})
export class ResourceCategoryEditDialog {

  constructor(
    public dialogRef: MatDialogRef<ResourceCategoryEditDialog>,
    @Inject(MAT_DIALOG_DATA) public data: IDirtyCategory) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

}
