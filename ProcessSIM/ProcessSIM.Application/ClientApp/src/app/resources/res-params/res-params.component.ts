import {Component, Inject, OnInit} from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA, MatDialog} from '@angular/material/dialog';
import {IResourceType} from "../../models/resourceType.interface";
import {MatTableDataSource} from "@angular/material/table";
import {SnackAlertComponent} from "../../snack-alert/snack-alert.component";
import {MatSnackBar} from "@angular/material/snack-bar";
import {IResourceParameterValue} from "../../models/resourceParameterValue.interface";
import {ResourceParameterValueService} from "../../services/resourceParameterValue.service";

@Component({
  selector: 'app-res-params',
  templateUrl: './res-params.component.html',
})
export class ResourceParamsDialog implements OnInit {
  resourceParameters$: IResourceParameterValue[] = [];

  selectedParam: IResourceParameterValue = null;

  displayedColumns: string[] = ['alias', 'value', 'actions'];
  dataSource = new MatTableDataSource(this.resourceParameters$);

  constructor(
    private _resourceParameterValueService: ResourceParameterValueService,
    private _snackBar: MatSnackBar,
    public dialogRef: MatDialogRef<ResourceParamsDialog>,
    @Inject(MAT_DIALOG_DATA) public data: IResourceType) {
  }

  ngOnInit(): void {
    this._resourceParameterValueService.getResourceParameters(this.data.id).subscribe(httpResult => {
      this.resourceParameters$ = httpResult.resParameters;
      this.updateDataSource();
    });
  }

  updateDataSource() {
    this.dataSource = new MatTableDataSource(this.resourceParameters$);
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  updateParam() {
    this._resourceParameterValueService.updateResourceParameter(this.selectedParam).subscribe(httpResult => {
      if (httpResult.status === "success") {
        this.resourceParameters$ = this.resourceParameters$.map(x => x.id === this.selectedParam.id ? httpResult.data : x);
        this.updateDataSource();
        this.selectedParam = null;
      } else {
        this.openSnackBar(httpResult.message)
      }
    });
  }

  setSelectedParam(param: IResourceParameterValue): void {
    this.selectedParam = param;
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  openSnackBar(text: string) {
    this._snackBar.openFromComponent(SnackAlertComponent, {
      data: text,
      duration: 4000,
    });
  }
}
