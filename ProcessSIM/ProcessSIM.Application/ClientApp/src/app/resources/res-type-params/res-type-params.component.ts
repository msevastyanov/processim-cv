import {Component, Inject, OnInit} from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA, MatDialog} from '@angular/material/dialog';
import {IResourceType} from "../../models/resourceType.interface";
import {ResourceParameterService} from "../../services/resourceParameter.service";
import {IResourceParameter} from "../../models/resourceParameter.interface";
import {MatTableDataSource} from "@angular/material/table";
import {IDirtyParameter} from "../../models/dirtyParameter.interface";
import {SnackAlertComponent} from "../../snack-alert/snack-alert.component";
import {MatSnackBar} from "@angular/material/snack-bar";
import {ConfirmDialog} from "../../confirm-dialog/confirm-dialog.component";

@Component({
  selector: 'app-res-type-params',
  templateUrl: './res-type-params.component.html',
})
export class ResourceTypeParamsDialog implements OnInit {
  resourceParameters$: IResourceParameter[] = [];

  newParam: IDirtyParameter = {
    id: -1,
    name: '',
    alias: ''
  };
  selectedParam: IResourceParameter = null;

  displayedColumns: string[] = ['name', 'alias', 'actions'];
  dataSource = new MatTableDataSource(this.resourceParameters$);

  constructor(
    private _resourceParameterService: ResourceParameterService,
    private _snackBar: MatSnackBar,
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<ResourceTypeParamsDialog>,
    @Inject(MAT_DIALOG_DATA) public data: IResourceType) {
  }

  ngOnInit(): void {
    this._resourceParameterService.getResourceParameters(this.data.id).subscribe(httpResult => {
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

  addNewParam() {
    this._resourceParameterService.addResourceParameter(this.data.id, this.newParam).subscribe(httpResult => {
      if (httpResult.status === "success") {
        this.resourceParameters$.push(httpResult.data);
        this.updateDataSource();
        this.newParam.name = '';
        this.newParam.alias = '';
      } else {
        this.openSnackBar(httpResult.message)
      }
    });
  }

  updateParam() {
    this._resourceParameterService.updateResourceParameter(this.data.id, this.selectedParam).subscribe(httpResult => {
      if (httpResult.status === "success") {
        this.resourceParameters$ = this.resourceParameters$.map(x => x.id === this.selectedParam.id ? httpResult.data : x);
        this.updateDataSource();
        this.selectedParam = null;
      } else {
        this.openSnackBar(httpResult.message)
      }
    });
  }

  setSelectedParam(param: IResourceParameter): void {
    this.selectedParam = param;
  }

  openDeleteDialog(elementId: number): void {
    const dialogRef = this.dialog.open(ConfirmDialog, {
      width: '250px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if (!result)
        return;

      this._resourceParameterService.deleteResourceParameter(elementId).subscribe(httpResult => {
        if (httpResult.status === "success") {
          this.resourceParameters$ = this.resourceParameters$.filter(x => x.id !== elementId);
          this.updateDataSource();
          this.selectedParam = null;
        } else {
          this.openSnackBar(httpResult.message)
        }
      });

    });
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
